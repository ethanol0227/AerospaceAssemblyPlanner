Imports System.Linq

Public Class UcPlan

    Private ReadOnly _state As AppState

    Public Sub New(state As AppState)
        InitializeComponent()
        _state = state
    End Sub

    Private Sub UcPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshPlan()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshPlan()
    End Sub

    Private Sub RefreshPlan()
        Dim rules = OrderRuleStore.LoadRules()

        Dim result = NorthropSequencer.BuildOrderedPlan(
        _state.SelectedCodes,
        _state.NorthropLibrary.Items,
        rules
    )

        lstErrors.Items.Clear()

        If result.Errors.Count > 0 Then
            lblPlanStatus.Text = "BLOCKED: Fix errors below."
            dgvPlan.DataSource = Nothing

            For Each e In result.Errors
                lstErrors.Items.Add(e)
            Next

            Return
        End If

        lblPlanStatus.Text = "OK: Ordered " & result.Ordered.Count & " steps."

        dgvPlan.AutoGenerateColumns = True
        dgvPlan.DataSource = result.Ordered.Select(Function(n) New With {
        .Code = n.Code,
        .Title = n.Title,
        .Section = n.Section,
        .OpType = n.OpType,
        .RequiresOJT = n.RequiresOJT
    }).ToList()
    End Sub

End Class