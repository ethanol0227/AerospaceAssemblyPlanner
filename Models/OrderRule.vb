Public Class OrderRule
    Public Property Code As String                      ' ex "*ASN0003"
    Public Property Before As New List(Of String)        ' codes that this must be before
    Public Property After As New List(Of String)         ' codes that this must be after
End Class

Public Class OrderRuleLibrary
    Public Property Version As String = "1"
    Public Property Items As New List(Of OrderRule)
End Class