Imports System.Linq

Public Class TemplateMatchResult
    Public Property Template As TemplateDef
    Public Property Score As Double
End Class

Public Class TemplateMatcher

    Public Shared Function GetBestMatch(selectedCodes As IEnumerable(Of String), templates As IEnumerable(Of TemplateDef)) As TemplateMatchResult
        Dim sel = New HashSet(Of String)(selectedCodes, StringComparer.OrdinalIgnoreCase)
        If sel.Count = 0 Then Return Nothing

        Dim best As TemplateMatchResult = Nothing

        For Each t In templates
            Dim tset = New HashSet(Of String)(t.Codes, StringComparer.OrdinalIgnoreCase)
            If tset.Count = 0 Then Continue For

            Dim inter = sel.Intersect(tset, StringComparer.OrdinalIgnoreCase).Count()
            Dim union = sel.Union(tset, StringComparer.OrdinalIgnoreCase).Count()
            Dim score = If(union = 0, 0, inter / union)

            If best Is Nothing OrElse score > best.Score Then
                best = New TemplateMatchResult With {.Template = t, .Score = score}
            End If
        Next

        Return best
    End Function

End Class