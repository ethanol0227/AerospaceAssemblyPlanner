Imports System.IO

Public Class MainForm

    Private _northrop As NoteLibraryRoot

    Private _pages As New List(Of UserControl)
    Private _pageIndex As Integer = 0

    Private _state As AppState

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Step list
        lstSteps.Items.Clear()
        lstSteps.Items.AddRange(New Object() {"Customer", "Template", "Inputs", "Plan", "Export"})
        lstSteps.SelectedIndex = 0

        ' Load Northrop library
        Try
            _northrop = NoteLibraryService.LoadNorthrop()
            lblStatus.Text = $"Status: Loaded Northrop ({_northrop.Items.Count} codes)"
            lblCustomer.Text = "Customer: NORTHROP"
        Catch ex As Exception
            lblStatus.Text = "Status: ERROR loading library"
            MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _state = New AppState With {
    .Customer = "NORTHROP",
    .NorthropLibrary = _northrop
}
        Dim ucTemplatePage As New UcTemplate(_state)
        AddHandler ucTemplatePage.TemplateApplied, Sub()
                                                       ' Move to Inputs page (index 2 if your order is Customer(0), Template(1), Inputs(2) ...)
                                                       ShowPage(2)
                                                   End Sub

        _pages = New List(Of UserControl) From {
    New UcCustomer(_state),
    ucTemplatePage,
    New UcInputs(_state),
    New UcPlan(_state),
    New UcExport(_state)
}

        ShowPage(0)
    End Sub

    Private Sub ShowPage(index As Integer)
        If index < 0 OrElse index >= _pages.Count Then Exit Sub

        _pageIndex = index
        lstSteps.SelectedIndex = index

        pnlContent.Controls.Clear()

        Dim page = _pages(index)
        page.Dock = DockStyle.Fill
        pnlContent.Controls.Add(page)

        btnBack.Enabled = (index > 0)
        btnNext.Enabled = (index < _pages.Count - 1)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ShowPage(_pageIndex + 1)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ShowPage(_pageIndex - 1)
    End Sub

    Private Sub lstSteps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSteps.SelectedIndexChanged
        ' Optional: allow clicking steps to jump
        If lstSteps.SelectedIndex <> _pageIndex Then
            ShowPage(lstSteps.SelectedIndex)
        End If
    End Sub

    Private Sub btnEditLibrary_Click(sender As Object, e As EventArgs) Handles btnEditLibrary.Click
        Using f As New NorthropLibraryEditorForm(_state)
            f.ShowDialog(Me)
        End Using

        ReloadNorthropLibrary()
    End Sub

    Private Sub ReloadNorthropLibrary()
        _state.NorthropLibrary = NoteLibraryService.LoadNorthrop()
        lblStatus.Text = $"Status: Loaded Northrop ({_state.NorthropLibrary.Items.Count} codes)"
    End Sub



End Class