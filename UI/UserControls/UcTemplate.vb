Imports System.ComponentModel
Public Class UcTemplate

    Private ReadOnly _state As AppState

    ' Optional: MainForm can subscribe to this to auto-advance
    Public Event TemplateApplied()

    Private Class TemplateDef
        Public Property Id As String
        Public Property Name As String
        Public Property Details As String
        Public Property WetInstall As Boolean
        Public Property NeedsSealant As Boolean

        Public Overrides Function ToString() As String
            ' This is what shows in the ListBox
            Return Name
        End Function
    End Class

    Private _templates As BindingList(Of TemplateDef)

    Public Sub New(state As AppState)
        InitializeComponent()
        _state = state
    End Sub

    Private Sub UcTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildTemplateList()

        lstTemplates.DataSource = _templates
        lstTemplates.DisplayMember = "Name"

        ' Restore previous selection if any
        If Not String.IsNullOrWhiteSpace(_state.SelectedTemplateId) Then
            Dim match = _templates.FirstOrDefault(Function(t) t.Id = _state.SelectedTemplateId)
            If match IsNot Nothing Then
                lstTemplates.SelectedItem = match
            End If
        Else
            ' Default selection
            If _templates.Count > 0 Then lstTemplates.SelectedIndex = 0
        End If

        ShowSelectedTemplateDetails()
        UpdateSelectedLabel()
    End Sub

    Private Sub BuildTemplateList()
        _templates = New BindingList(Of TemplateDef) From {
            New TemplateDef With {
                .Id = "FASTENER_WET_SEAL",
                .Name = "Fastener Install (Wet) + Sealant",
                .Details =
                    "For installs where sealant is applied during installation (wet install) and sealing steps are expected." & Environment.NewLine &
                    "- Typically includes surface prep + promoter + wet install steps" & Environment.NewLine &
                    "- Later we’ll auto-add fay seal / fillet seal / torque verify based on inputs",
                .WetInstall = True,
                .NeedsSealant = True
            },
            New TemplateDef With {
                .Id = "FASTENER_DRY_NOSEAL",
                .Name = "Fastener Install (Dry) - No Sealant",
                .Details =
                    "For installs with no sealant application." & Environment.NewLine &
                    "- Typically includes surface prep + dry install steps" & Environment.NewLine &
                    "- Later we’ll add torque/thread protrusion verifications if required",
                .WetInstall = False,
                .NeedsSealant = False
            },
            New TemplateDef With {
                .Id = "SURFACE_PREP_ONLY",
                .Name = "Surface Prep Only",
                .Details =
                    "Only the Northrop surface cleaning / preparation steps." & Environment.NewLine &
                    "- Useful for rework, prep-only travelers, or pre-seal prep stages",
                .WetInstall = False,
                .NeedsSealant = False
            }
        }
    End Sub

    Private Sub lstTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTemplates.SelectedIndexChanged
        ShowSelectedTemplateDetails()
    End Sub

    Private Sub ShowSelectedTemplateDetails()
        Dim t = TryCast(lstTemplates.SelectedItem, TemplateDef)
        If t Is Nothing Then
            lblTemplateTitle.Text = "Select a template"
            txtTemplateDetails.Text = ""
            Return
        End If

        lblTemplateTitle.Text = t.Name
        txtTemplateDetails.Text = t.Details
    End Sub

    Private Sub btnApplyTemplate_Click(sender As Object, e As EventArgs) Handles btnApplyTemplate.Click
        Dim t = TryCast(lstTemplates.SelectedItem, TemplateDef)
        If t Is Nothing Then
            MessageBox.Show("Pick a template first.", "Template", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Commit into AppState (this is the whole point of this page)
        _state.SelectedTemplateId = t.Id
        _state.SelectedTemplateName = t.Name
        _state.WetInstall = t.WetInstall
        _state.NeedsSealant = t.NeedsSealant

        UpdateSelectedLabel()

        ' Optional: tell MainForm “template is applied”
        RaiseEvent TemplateApplied()
    End Sub

    Private Sub UpdateSelectedLabel()
        If lblSelected Is Nothing Then Return ' if you didn't add it, no problem

        If String.IsNullOrWhiteSpace(_state.SelectedTemplateName) Then
            lblSelected.Text = "Selected: (none)"
        Else
            lblSelected.Text = "Selected: " & _state.SelectedTemplateName
        End If
    End Sub

End Class


