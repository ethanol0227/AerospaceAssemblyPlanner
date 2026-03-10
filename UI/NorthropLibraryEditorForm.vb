Imports System.ComponentModel
Imports System.Linq

Public Class NorthropLibraryEditorForm

    Private ReadOnly _state As AppState
    Private _binding As BindingList(Of NoteCode)

    Public Sub New(state As AppState)
        InitializeComponent()
        _state = state
    End Sub




    Private Sub NorthropLibraryEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPath.Text = "Editing: " & NoteLibraryService.UserJsonPath()

        ' Bind to a BindingList so edits reflect automatically
        _binding = New BindingList(Of NoteCode)(_state.NorthropLibrary.Items)
        dgvNotes.AutoGenerateColumns = True
        dgvNotes.DataSource = _binding
        OrderRuleSync.EnsureRulesExistForCodes(_binding.Select(Function(n) n.Code))
        ' Optional: make long text columns easier
        dgvNotes.Columns("Instruction").Width = 450
        dgvNotes.Columns("Title").Width = 300

        ApplyGuardRails()
    End Sub


    Private Sub btnAdminToggle_Click(sender As Object, e As EventArgs) Handles btnAdminToggle.Click
        ' Optional: add a password prompt later
        _adminMode = Not _adminMode
        btnAdminToggle.Text = If(_adminMode, "Admin Mode: ON", "Admin Mode: OFF")
        ApplyGuardRails()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _binding.Add(New NoteCode With {
            .Customer = "NORTHROP",
            .Section = "",
            .Type = "",
            .Code = "*NEWCODE",
            .Title = "",
            .Instruction = "",
            .Refs = New List(Of String),
            .OpType = "Other",
            .RequiresOJT = False
        })
        Dim newCode = _binding(_binding.Count - 1).Code
        OrderRuleSync.EnsureRulesExistForCodes(New List(Of String) From {newCode})
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Must have a current row
        If dgvNotes Is Nothing OrElse dgvNotes.CurrentRow Is Nothing Then Return
        Dim idx = dgvNotes.CurrentRow.Index
        If idx < 0 OrElse _binding Is Nothing OrElse idx >= _binding.Count Then Return

        Dim codeToDelete = _binding(idx).Code

        If MessageBox.Show($"Delete {codeToDelete}?" & Environment.NewLine &
                       "This will also remove its ordering rule definition.",
                       "Confirm Delete",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        ' Remove from the note library list
        _binding.RemoveAt(idx)

        ' Remove ordering rule entry (separate JSON) - don't crash if it fails
        Try
            If Not String.IsNullOrWhiteSpace(codeToDelete) Then
                OrderRuleSync.RemoveRulesForCodes(New List(Of String) From {codeToDelete})
            End If
        Catch ex As Exception
            MessageBox.Show("Deleted note, but failed to remove ordering rule: " & ex.Message,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' Stop here if grid has no rows left
        If dgvNotes.Rows Is Nothing OrElse dgvNotes.Rows.Count = 0 Then Return

        ' Keep selection sane without ever selecting a hidden cell
        Dim newIdx = Math.Min(idx, dgvNotes.Rows.Count - 1)
        If newIdx < 0 Then Return

        dgvNotes.ClearSelection()
        dgvNotes.Rows(newIdx).Selected = True

        Dim firstVisibleCol = dgvNotes.Columns.
        Cast(Of DataGridViewColumn)().
        FirstOrDefault(Function(c) c IsNot Nothing AndAlso c.Visible)

        If firstVisibleCol IsNot Nothing Then
            dgvNotes.CurrentCell = dgvNotes.Rows(newIdx).Cells(firstVisibleCol.Index)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateBeforeSave() Then Return

        _state.NorthropLibrary.Items = _binding.ToList()
        NoteLibraryService.SaveNorthrop(_state.NorthropLibrary)
        OrderRuleSync.EnsureRulesExistForCodes(_binding.Select(Function(n) n.Code))
        MessageBox.Show("Saved.", "Library", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnResetFactory_Click(sender As Object, e As EventArgs) Handles btnResetFactory.Click
        If MessageBox.Show("Reset Northrop library to factory version? This overwrites your edits.",
                           "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        NoteLibraryService.ResetNorthropToFactory()
        _state.NorthropLibrary = NoteLibraryService.LoadNorthrop()

        _binding = New BindingList(Of NoteCode)(_state.NorthropLibrary.Items)
        dgvNotes.DataSource = _binding
    End Sub

    Private _adminMode As Boolean = False
    Private Function Col(name As String) As DataGridViewColumn
        If dgvNotes.Columns.Contains(name) Then Return dgvNotes.Columns(name)
        Return Nothing
    End Function

    Private Sub ApplyGuardRails()

        btnEditOrdering.Enabled = _adminMode
        If dgvNotes Is Nothing OrElse dgvNotes.DataSource Is Nothing Then Return

        dgvNotes.AllowUserToAddRows = False
        dgvNotes.AllowUserToDeleteRows = False
        dgvNotes.MultiSelect = False
        dgvNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Default: read-only
        For Each c As DataGridViewColumn In dgvNotes.Columns
            c.ReadOnly = True
            c.Visible = True
        Next

        ' Hide noisy fields (normal mode)
        Dim customerCol = Col("Customer")
        If customerCol IsNot Nothing Then customerCol.Visible = False

        Dim refsCol = Col("Refs")
        If refsCol IsNot Nothing Then refsCol.Visible = _adminMode

        Dim opTypeCol = Col("OpType")
        If opTypeCol IsNot Nothing Then opTypeCol.Visible = _adminMode

        Dim sectionCol = Col("Section")
        If sectionCol IsNot Nothing Then sectionCol.Visible = _adminMode

        Dim typeCol = Col("Type")
        If typeCol IsNot Nothing Then typeCol.Visible = _adminMode

        ' Allow edits (guard-railed)
        Dim titleCol = Col("Title")
        If titleCol IsNot Nothing Then titleCol.ReadOnly = False

        Dim instrCol = Col("Instruction")
        If instrCol IsNot Nothing Then
            instrCol.ReadOnly = False
            instrCol.Width = 520
        End If

        Dim ojtCol = Col("RequiresOJT")
        If ojtCol IsNot Nothing Then
            ojtCol.ReadOnly = False
            ojtCol.Width = 90
        End If

        ' Nice widths if present
        Dim codeCol = Col("Code")
        If codeCol IsNot Nothing Then codeCol.Width = 110

        If titleCol IsNot Nothing Then titleCol.Width = 320

        ' Admin capabilities
        btnAdd.Enabled = _adminMode
        btnDelete.Enabled = _adminMode
        btnImportLibrary.Enabled = _adminMode
        btnExportLibrary.Enabled = _adminMode

        If _adminMode Then
            dgvNotes.AllowUserToAddRows = True
            dgvNotes.AllowUserToDeleteRows = True

            If sectionCol IsNot Nothing Then sectionCol.ReadOnly = False
            If typeCol IsNot Nothing Then typeCol.ReadOnly = False
            If opTypeCol IsNot Nothing Then opTypeCol.ReadOnly = False
            If refsCol IsNot Nothing Then refsCol.ReadOnly = False
        End If
    End Sub



    Private Function ValidateBeforeSave() As Boolean
        dgvNotes.EndEdit()

        Dim seen As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For i = 0 To _binding.Count - 1
            Dim n = _binding(i)

            ' Force customer
            n.Customer = "NORTHROP"

            If String.IsNullOrWhiteSpace(n.Code) Then
                MessageBox.Show($"Row {i + 1}: Code is blank.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If Not n.Code.Trim().StartsWith("*") Then
                MessageBox.Show($"Row {i + 1}: Code must start with '*'.  (ex: *ASN0003)", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If String.IsNullOrWhiteSpace(n.Title) Then
                MessageBox.Show($"Row {i + 1}: Title is blank.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If Not seen.Add(n.Code.Trim()) Then
                MessageBox.Show($"Duplicate code found: {n.Code}", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub btnEditOrdering_Click(sender As Object, e As EventArgs) Handles btnEditOrdering.Click
        If Not _adminMode Then Return

        Using f As New OrderRulesEditorForm(_binding.ToList)
            f.ShowDialog(Me)
        End Using
    End Sub

    Private Sub btnImportLibrary_Click(sender As Object, e As EventArgs) Handles btnImportLibrary.Click
        If Not _adminMode Then Return

        Using ofd As New OpenFileDialog()
            ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            ofd.Title = "Import Northrop Note Codes JSON"

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Dim err = JsonImportService.ImportJson(Of NoteLibraryRoot)(
            ofd.FileName,
            NoteLibraryService.UserJsonPath(),
            Function(root)
                If root Is Nothing Then Return "Invalid file."
                If root.Items Is Nothing OrElse root.Items.Count = 0 Then Return "Library JSON has no items."

                ' Minimal sanity checks
                If root.Items.Any(Function(n) n Is Nothing OrElse String.IsNullOrWhiteSpace(n.Code)) Then
                    Return "One or more items has a blank Code."
                End If

                ' Keep it Northrop-only for now
                If root.Items.Any(Function(n) Not String.Equals(n.Customer, "NORTHROP", StringComparison.OrdinalIgnoreCase)) Then
                    Return "Import contains non-NORTHROP items. (This app is locked to Northrop right now.)"
                End If

                Return ""
            End Function
        )

            If err <> "" Then
                MessageBox.Show(err, "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Reload into state + refresh editor grid
            _state.NorthropLibrary = NoteLibraryService.LoadNorthrop()
            _binding = New BindingList(Of NoteCode)(_state.NorthropLibrary.Items)
            dgvNotes.DataSource = _binding
            ApplyGuardRails()

            ' Ensure ordering rule entries exist for any new codes
            OrderRuleSync.EnsureRulesExistForCodes(_binding.Select(Function(n) n.Code))

            MessageBox.Show("Note codes imported successfully." & Environment.NewLine &
                        "A backup of the previous library was saved next to the AppData JSON.",
                        "Import", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub btnExportLibrary_Click(sender As Object, e As EventArgs) Handles btnExportLibrary.Click
        If Not _adminMode Then Return

        ' Make sure state is current
        Dim root = _state.NorthropLibrary
        If root Is Nothing OrElse root.Items Is Nothing OrElse root.Items.Count = 0 Then
            MessageBox.Show("Nothing to export (library is empty).", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            sfd.Title = "Export Northrop Note Codes JSON"
            sfd.FileName = "northrop_note_codes.json"

            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Try
                ' Save a clean, updated count
                root.Count = root.Items.Count

                Dim opts As New System.Text.Json.JsonSerializerOptions With {.WriteIndented = True}
                Dim json = System.Text.Json.JsonSerializer.Serialize(root, opts)
                System.IO.File.WriteAllText(sfd.FileName, json)

                MessageBox.Show("Exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Export failed: " & ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


End Class