Public Class UcCustomer

    Private ReadOnly _state As AppState

    Public Sub New(state As AppState)
        InitializeComponent()
        _state = state
    End Sub


    Private Sub UcCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblInfo.Text = $"Customer: {_state.Customer}{Environment.NewLine}Codes loaded: {_state.NorthropLibrary.Items.Count}"
    End Sub

End Class