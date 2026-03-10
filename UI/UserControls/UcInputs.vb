Imports System.ComponentModel
Imports System.Linq

Public Class UcInputs

    Private _isReady As Boolean = False

    Private ReadOnly _state As AppState

    Private _allNotes As List(Of NoteCode)
    Private _allView As BindingList(Of NoteCode)
    Private _selectedView As BindingList(Of NoteCode)

    Private _templates As TemplateLibrary
    Private _bestMatch As TemplateMatchResult

    Public Sub New(state As AppState)
        InitializeComponent()
        _state = state
    End Sub

    Private Sub UcInputs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _allNotes = _state.NorthropLibrary.Items
        _templates = TemplateStore.LoadTemplates()

        Dim selectedNotes = _allNotes.
            Where(Function(n) _state.SelectedCodes.Contains(n.Code, StringComparer.OrdinalIgnoreCase)).
            ToList()

        _selectedView = New BindingList(Of NoteCode)(selectedNotes)
        ApplySearchFilter("") ' builds _allView
        _isReady = True
        BindGrids()
        RefreshSuggestion()
    End Sub

    Private Sub BindGrids()
        ' All codes
        dgvAllCodes.AutoGenerateColumns = True
        dgvAllCodes.DataSource = _allView
        dgvAllCodes.ReadOnly = True
        dgvAllCodes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllCodes.MultiSelect = False

        ' Selected
        dgvSelected.AutoGenerateColumns = True
        dgvSelected.DataSource = _selectedView
        dgvSelected.ReadOnly = True
        dgvSelected.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSelected.MultiSelect = False

        HideColumns(dgvAllCodes)
        HideColumns(dgvSelected)
    End Sub

    Private Sub HideColumns(grid As DataGridView)
        If grid Is Nothing OrElse grid.Columns Is Nothing Then Return

        If grid.Columns.Contains("Instruction") Then grid.Columns("Instruction").Visible = False
        If grid.Columns.Contains("Refs") Then grid.Columns("Refs").Visible = False
        If grid.Columns.Contains("Customer") Then grid.Columns("Customer").Visible = False

        If grid.Columns.Contains("Code") Then grid.Columns("Code").Width = 110
        If grid.Columns.Contains("Title") Then grid.Columns("Title").Width = 420
        If grid.Columns.Contains("Section") Then grid.Columns("Section").Width = 160
        If grid.Columns.Contains("OpType") Then grid.Columns("OpType").Width = 140
    End Sub

    ' ---- Search / filter ----
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If Not _isReady Then Return
        ApplySearchFilter(txtSearch.Text)
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        If Not _isReady Then
            txtSearch.Text = ""
            Return
        End If
        txtSearch.Text = ""
        ApplySearchFilter("")
    End Sub

    Private Sub chkHideSelected_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideSelected.CheckedChanged
        If Not _isReady Then Return
        ApplySearchFilter(txtSearch.Text)
    End Sub

    Private Sub ApplySearchFilter(term As String)

        If _allNotes Is Nothing Then
            _allNotes = New List(Of NoteCode)()
        End If


        term = If(term, "").Trim()

        Dim filtered = _allNotes.AsEnumerable()

        If term <> "" Then
            filtered = filtered.Where(Function(n)
                                          Return (If(n.Code, "")).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 _
                                              OrElse (If(n.Title, "")).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 _
                                              OrElse (If(n.Section, "")).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 _
                                              OrElse (If(n.OpType, "")).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
                                      End Function)
        End If

        If chkHideSelected.Checked Then
            Dim selectedSet = New HashSet(Of String)(_selectedView.Select(Function(x) x.Code), StringComparer.OrdinalIgnoreCase)
            filtered = filtered.Where(Function(n) Not selectedSet.Contains(n.Code))
        End If

        _allView = New BindingList(Of NoteCode)(filtered.ToList())
        dgvAllCodes.DataSource = _allView
        HideColumns(dgvAllCodes)
    End Sub

    ' ---- Add / remove ----
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddCurrentFromAll()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        RemoveCurrentFromSelected()
    End Sub

    Private Sub dgvAllCodes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAllCodes.CellDoubleClick
        AddCurrentFromAll()
    End Sub

    Private Sub dgvSelected_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelected.CellDoubleClick
        RemoveCurrentFromSelected()
    End Sub

    Private Sub AddCurrentFromAll()
        Dim n = CurrentNote(dgvAllCodes)
        If n Is Nothing Then Return

        If _selectedView.Any(Function(x) x.Code.Equals(n.Code, StringComparison.OrdinalIgnoreCase)) Then Return

        _selectedView.Add(n)
        SyncSelectedCodesToState()
        ApplySearchFilter(txtSearch.Text) ' refresh hide-selected behavior
        RefreshSuggestion()
    End Sub

    Private Sub RemoveCurrentFromSelected()
        Dim n = CurrentNote(dgvSelected)
        If n Is Nothing Then Return

        Dim idx = _selectedView.ToList().FindIndex(Function(x) x.Code.Equals(n.Code, StringComparison.OrdinalIgnoreCase))
        If idx >= 0 Then _selectedView.RemoveAt(idx)

        SyncSelectedCodesToState()
        ApplySearchFilter(txtSearch.Text)
        RefreshSuggestion()
    End Sub

    Private Function CurrentNote(grid As DataGridView) As NoteCode
        If grid Is Nothing OrElse grid.CurrentRow Is Nothing Then Return Nothing
        Return TryCast(grid.CurrentRow.DataBoundItem, NoteCode)
    End Function

    Private Sub SyncSelectedCodesToState()
        _state.SelectedCodes = _selectedView.
            Select(Function(x) x.Code).
            Distinct(StringComparer.OrdinalIgnoreCase).
            ToList()
    End Sub

    ' ---- Clear selected ----
    Private Sub btnClearSelected_Click(sender As Object, e As EventArgs) Handles btnClearSelected.Click
        If MessageBox.Show("Clear all selected requirements?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        _selectedView.Clear()
        SyncSelectedCodesToState()
        ApplySearchFilter(txtSearch.Text)
        RefreshSuggestion()
    End Sub

    ' ---- Template suggestion ----
    Private Sub RefreshSuggestion()
        If _state.SelectedCodes.Count = 0 Then
            lblSuggestion.Text = "Select requirements to get a template suggestion."
            btnApplySuggested.Enabled = False
            btnSaveAsTemplate.Enabled = False
            Return
        End If

        btnSaveAsTemplate.Enabled = True

        _bestMatch = TemplateMatcher.GetBestMatch(_state.SelectedCodes, _templates.Items)

        If _bestMatch Is Nothing Then
            lblSuggestion.Text = "No templates exist yet for this set. You can save this as a new template."
            btnApplySuggested.Enabled = False
            Return
        End If

        Dim pct = CInt(Math.Round(_bestMatch.Score * 100))
        lblSuggestion.Text = $"Suggested template: {_bestMatch.Template.Name} (match {pct}%)"

        btnApplySuggested.Enabled = (_bestMatch.Score >= 0.6)
    End Sub

    Private Sub btnApplySuggested_Click(sender As Object, e As EventArgs) Handles btnApplySuggested.Click
        If _bestMatch Is Nothing Then Return

        _state.SelectedTemplateId = _bestMatch.Template.Id
        _state.SelectedTemplateName = _bestMatch.Template.Name

        _state.SelectedCodes = _bestMatch.Template.Codes.Distinct(StringComparer.OrdinalIgnoreCase).ToList()

        Dim selectedNotes = _allNotes.Where(Function(n) _state.SelectedCodes.Contains(n.Code, StringComparer.OrdinalIgnoreCase)).ToList()
        _selectedView = New BindingList(Of NoteCode)(selectedNotes)
        dgvSelected.DataSource = _selectedView
        HideColumns(dgvSelected)

        ApplySearchFilter(txtSearch.Text)
        RefreshSuggestion()

        MessageBox.Show("Applied suggested template: " & _state.SelectedTemplateName)
    End Sub

    Private Sub btnSaveAsTemplate_Click(sender As Object, e As EventArgs) Handles btnSaveAsTemplate.Click
        If _state.SelectedCodes.Count = 0 Then Return

        Dim name = InputBox("Template name:", "Save Template", "New Template - Northrop").Trim()
        If name = "" Then Return

        Dim id = "USR_" & New String(name.Where(Function(ch) Char.IsLetterOrDigit(ch)).ToArray()).ToUpperInvariant()
        If id.Length > 40 Then id = id.Substring(0, 40)

        Dim baseId = id
        Dim suffix = 1
        While _templates.Items.Any(Function(t) t.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
            suffix += 1
            id = baseId & "_" & suffix.ToString()
        End While

        Dim tNew As New TemplateDef With {
            .id = id,
            .name = name,
            .Details = "User-created template from Requirements page.",
            .Codes = _state.SelectedCodes.Distinct(StringComparer.OrdinalIgnoreCase).ToList()
        }

        _templates.Items.Add(tNew)
        TemplateStore.SaveTemplates(_templates)

        RefreshSuggestion()
        MessageBox.Show("Saved template: " & tNew.Name)
    End Sub

    Private Sub dgvAllCodes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAllCodes.SelectionChanged
        If Not _isReady Then Return
        Dim n = CurrentNote(dgvAllCodes)
        ShowPreview(n)
    End Sub

    Private Sub dgvSelected_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSelected.SelectionChanged
        If Not _isReady Then Return
        Dim n = CurrentNote(dgvSelected)
        ShowPreview(n)
    End Sub

    Private Sub ShowPreview(n As NoteCode)
        If txtPreview Is Nothing Then Return
        If n Is Nothing Then
            txtPreview.Text = ""
            Return
        End If

        txtPreview.Text =
            $"{n.Code}  |  {n.Section}  |  {n.OpType}{Environment.NewLine}" &
            $"{n.Title}{Environment.NewLine}{Environment.NewLine}" &
            $"{n.Instruction}"
    End Sub
    Private Sub btnQuickAdd_Click(sender As Object, e As EventArgs) Handles btnQuickAdd.Click
        If Not _isReady Then Return

        Dim code = (If(txtQuickAdd.Text, "")).Trim()
        If code = "" Then Return
        If Not code.StartsWith("*") Then code = "*" & code

        Dim n = _allNotes.FirstOrDefault(Function(x) x.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
        If n Is Nothing Then
            MessageBox.Show("Code not found: " & code)
            Return
        End If

        If _selectedView.Any(Function(x) x.Code.Equals(n.Code, StringComparison.OrdinalIgnoreCase)) Then Return

        _selectedView.Add(n)
        SyncSelectedCodesToState()
        ApplySearchFilter(txtSearch.Text)
        RefreshSuggestion()

        txtQuickAdd.Text = ""
    End Sub
End Class