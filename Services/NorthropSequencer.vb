Imports System.Linq

Public Class PlanBuildResult
    Public Property Ordered As New List(Of NoteCode)
    Public Property Errors As New List(Of String)
End Class

Public Class NorthropSequencer

    Public Shared Function BuildOrderedPlan(selectedCodes As IEnumerable(Of String),
                                            allNotes As List(Of NoteCode),
                                            ruleLib As OrderRuleLibrary) As PlanBuildResult

        Dim res As New PlanBuildResult()

        Dim sel = New HashSet(Of String)(selectedCodes, StringComparer.OrdinalIgnoreCase)
        If sel.Count = 0 Then
            res.Errors.Add("No requirements selected.")
            Return res
        End If

        ' Map code -> NoteCode
        Dim noteByCode = allNotes.
            Where(Function(n) Not String.IsNullOrWhiteSpace(n.Code)).
            GroupBy(Function(n) n.Code, StringComparer.OrdinalIgnoreCase).
            ToDictionary(Function(g) g.Key, Function(g) g.First(), StringComparer.OrdinalIgnoreCase)

        ' Validate: all selected exist
        For Each c In sel
            If Not noteByCode.ContainsKey(c) Then
                res.Errors.Add("Selected code not found in library: " & c)
            End If
        Next
        If res.Errors.Count > 0 Then Return res

        ' Build adjacency + indegree for topo sort
        Dim adj As New Dictionary(Of String, HashSet(Of String))(StringComparer.OrdinalIgnoreCase)
        Dim indeg As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

        For Each c In sel
            adj(c) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            indeg(c) = 0
        Next

        ' Index rules by code
        Dim ruleByCode = ruleLib.Items.
            Where(Function(r) Not String.IsNullOrWhiteSpace(r.Code)).
            GroupBy(Function(r) r.Code, StringComparer.OrdinalIgnoreCase).
            ToDictionary(Function(g) g.Key, Function(g) g.First(), StringComparer.OrdinalIgnoreCase)

        ' Add edges from rules (only among selected codes)
        For Each c In sel
            If Not ruleByCode.ContainsKey(c) Then Continue For
            Dim r = ruleByCode(c)

            ' c must be BEFORE x  => edge c -> x
            If r.Before IsNot Nothing Then
                For Each x In r.Before
                    If sel.Contains(x) Then AddEdge(c, x, adj, indeg)
                Next
            End If

            ' c must be AFTER x => edge x -> c
            If r.After IsNot Nothing Then
                For Each x In r.After
                    If sel.Contains(x) Then AddEdge(x, c, adj, indeg)
                Next
            End If
        Next

        ' Enforce: every selected code must have a rule entry (Before/After can be empty)
        For Each c In sel
            If Not ruleByCode.ContainsKey(c) Then
                res.Errors.Add("Missing ordering rule entry for selected code: " & c)
            End If
        Next
        If res.Errors.Count > 0 Then Return res



        ' Kahn topo sort
        Dim q As New Queue(Of String)(indeg.Where(Function(kv) kv.Value = 0).Select(Function(kv) kv.Key))
        Dim orderedCodes As New List(Of String)

        While q.Count > 0
            Dim n = q.Dequeue()
            orderedCodes.Add(n)

            For Each m In adj(n)
                indeg(m) -= 1
                If indeg(m) = 0 Then q.Enqueue(m)
            Next
        End While

        If orderedCodes.Count <> sel.Count Then
            ' Cycle or unsatisfied constraints
            Dim stuck = indeg.Where(Function(kv) kv.Value > 0).Select(Function(kv) kv.Key).ToList()
            res.Errors.Add("Ordering conflict (cycle) involving: " & String.Join(", ", stuck))
            Return res
        End If

        res.Ordered = orderedCodes.Select(Function(c) noteByCode(c)).ToList()
        Return res
    End Function

    Private Shared Sub AddEdge(a As String, b As String,
                               adj As Dictionary(Of String, HashSet(Of String)),
                               indeg As Dictionary(Of String, Integer))

        If a.Equals(b, StringComparison.OrdinalIgnoreCase) Then Return
        If adj(a).Add(b) Then
            indeg(b) += 1
        End If
    End Sub

End Class