Public Class PrecedenceConfig
    Public Property Version As String = "1"

    ' Tiered precedence. Earlier tier must come before later tier.
    Public Property Tiers As New List(Of PrecedenceTier)

    ' Special rule support
    Public Property AdhesionPromoterOpType As String = "AdhesionPromoter"
    Public Property SealantOpTypes As New List(Of String) From {"FaySeal", "Fay&FilletSeal", "FilletSeal"}
End Class

Public Class PrecedenceTier
    Public Property Name As String
    Public Property OpTypes As New List(Of String)
End Class