Imports System.Linq

Public Class OrderRuleSync

    ' Ensures: every note code has a corresponding OrderRule entry in the separate JSON
    Public Shared Sub EnsureRulesExistForCodes(noteCodes As IEnumerable(Of String))
        Dim ruleLib = OrderRuleStore.LoadRules()

        Dim existing = New HashSet(Of String)(
            ruleLib.Items.Select(Function(r) r.Code),
            StringComparer.OrdinalIgnoreCase
        )

        Dim changed As Boolean = False

        For Each c In noteCodes
            If String.IsNullOrWhiteSpace(c) Then Continue For
            If existing.Contains(c) Then Continue For

            ruleLib.Items.Add(New OrderRule With {
                .Code = c,
                .Before = New List(Of String)(),
                .After = New List(Of String)()
            })

            existing.Add(c)
            changed = True
        Next

        If changed Then
            OrderRuleStore.SaveRules(ruleLib)
        End If
    End Sub

    ' Optional: call this if you allow deleting codes in admin mode
    Public Shared Sub RemoveRulesForCodes(noteCodes As IEnumerable(Of String))
        Dim ruleLib = OrderRuleStore.LoadRules()
        Dim toRemove = New HashSet(Of String)(noteCodes, StringComparer.OrdinalIgnoreCase)

        Dim beforeCount = ruleLib.Items.Count
        ruleLib.Items = ruleLib.Items.Where(Function(r) Not toRemove.Contains(r.Code)).ToList()

        If ruleLib.Items.Count <> beforeCount Then
            OrderRuleStore.SaveRules(ruleLib)
        End If
    End Sub

End Class