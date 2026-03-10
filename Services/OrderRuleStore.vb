Imports System.IO
Imports System.Text.Json

Public Class OrderRuleStore

    Private Shared Function RulePath() As String
        Dim folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "AerospaceAssemblyPlanner"
        )
        Directory.CreateDirectory(folder)
        Return Path.Combine(folder, "northrop_order_rules.json")
    End Function

    Public Shared Function LoadRules() As OrderRuleLibrary
        Dim p = RulePath()
        If Not File.Exists(p) Then
            Return New OrderRuleLibrary()
        End If

        Dim json = File.ReadAllText(p)
        Dim opts As New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}

        Dim ruleLib = JsonSerializer.Deserialize(Of OrderRuleLibrary)(json, opts)
        If ruleLib Is Nothing OrElse ruleLib.Items Is Nothing Then
            Return New OrderRuleLibrary()
        End If

        Return ruleLib
    End Function

    Public Shared Sub SaveRules(ruleLib As OrderRuleLibrary)
        Dim p = RulePath()
        Dim opts As New JsonSerializerOptions With {.WriteIndented = True}
        File.WriteAllText(p, JsonSerializer.Serialize(ruleLib, opts))
    End Sub

    Public Shared Function PathOnDisk() As String
        Return RulePath()
    End Function

End Class