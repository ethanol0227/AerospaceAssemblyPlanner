Imports System.Linq

Public Class OrderRulesEditorForm
    Private _isReady As Boolean = False
    Private ReadOnly _allNotes As List(Of NoteCode)

    Private _ruleLib As OrderRuleLibrary
    Private _ruleByCode As Dictionary(Of String, OrderRule)

    Private _selectedCode As String = ""

    Public Sub New(allNotes As List(Of NoteCode))
        InitializeComponent()
        _allNotes = If(allNotes, New List(Of NoteCode)())
    End Sub

    Private Sub OrderRulesEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblRulesPath.Text = "Rules file: " & OrderRuleStore.PathOnDisk()

        _ruleLib = OrderRuleStore.LoadRules()
        _ruleByCode = _ruleLib.Items.
        Where(Function(r) Not String.IsNullOrWhiteSpace(r.Code)).
        GroupBy(Function(r) r.Code, StringComparer.OrdinalIgnoreCase).
        ToDictionary(Function(g) g.Key, Function(g) g.First(), StringComparer.OrdinalIgnoreCase)

        OrderRuleSync.EnsureRulesExistForCodes(_allNotes.Select(Function(n) n.Code))

        _ruleLib = OrderRuleStore.LoadRules()
        _ruleByCode = _ruleLib.Items.
        Where(Function(r) Not String.IsNullOrWhiteSpace(r.Code)).
        GroupBy(Function(r) r.Code, StringComparer.OrdinalIgnoreCase).
        ToDictionary(Function(g) g.Key, Function(g) g.First(), StringComparer.OrdinalIgnoreCase)

        _isReady = True
        BindCodeList()
        RefreshAllMatches()
    End Sub

    ' -------------------------
    ' Left code list + search
    ' -------------------------
    Private Sub txtCodeSearch_TextChanged(sender As Object, e As EventArgs) Handles txtCodeSearch.TextChanged
        If Not _isReady Then Return
        BindCodeList()
    End Sub

    Private Sub BindCodeList()
        If _allNotes Is Nothing Then Return
        Dim term = (If(txtCodeSearch.Text, "")).Trim()

        Dim codes = _allNotes.
            Where(Function(n) Not String.IsNullOrWhiteSpace(n.Code)).
            Select(Function(n) n.Code).
            Distinct(StringComparer.OrdinalIgnoreCase)

        If term <> "" Then
            codes = codes.Where(Function(c) c.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
        End If

        Dim list = codes.OrderBy(Function(c) c).ToList()

        lstCodes.DataSource = Nothing
        lstCodes.DataSource = list
    End Sub

    Private Sub lstCodes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCodes.SelectedIndexChanged
        Dim c = TryCast(lstCodes.SelectedItem, String)
        If String.IsNullOrWhiteSpace(c) Then Return

        _selectedCode = c
        lblSelectedCode.Text = "Selected: " & _selectedCode
        LoadRuleForSelectedCode()
    End Sub

    ' -------------------------
    ' Rule display/edit
    ' -------------------------
    Private Function GetOrCreateRule(code As String) As OrderRule
        If _ruleByCode.ContainsKey(code) Then Return _ruleByCode(code)

        Dim r As New OrderRule With {.Code = code}
        _ruleLib.Items.Add(r)
        _ruleByCode(code) = r
        Return r
    End Function

    Private Sub LoadRuleForSelectedCode()
        If String.IsNullOrWhiteSpace(_selectedCode) Then Return

        Dim r = GetOrCreateRule(_selectedCode)

        lstBefore.DataSource = Nothing
        lstAfter.DataSource = Nothing

        lstBefore.DataSource = (If(r.Before, New List(Of String)())).
            Distinct(StringComparer.OrdinalIgnoreCase).
            OrderBy(Function(x) x).
            ToList()

        lstAfter.DataSource = (If(r.After, New List(Of String)())).
            Distinct(StringComparer.OrdinalIgnoreCase).
            OrderBy(Function(x) x).
            ToList()
    End Sub

    ' -------------------------
    ' Search to add edges
    ' -------------------------
    Private Sub txtAllSearch_TextChanged(sender As Object, e As EventArgs) Handles txtAllSearch.TextChanged
        If Not _isReady Then Return
        RefreshAllMatches()
    End Sub

    Private Sub RefreshAllMatches()
        If _allNotes Is Nothing Then Return
        Dim term = (If(txtAllSearch.Text, "")).Trim()

        Dim allCodes = _allNotes.
            Where(Function(n) Not String.IsNullOrWhiteSpace(n.Code)).
            Select(Function(n) n.Code).
            Distinct(StringComparer.OrdinalIgnoreCase)

        If Not String.IsNullOrWhiteSpace(term) Then
            allCodes = allCodes.Where(Function(c) c.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
        End If

        ' Don’t show the selected code itself
        If Not String.IsNullOrWhiteSpace(_selectedCode) Then
            allCodes = allCodes.Where(Function(c) Not c.Equals(_selectedCode, StringComparison.OrdinalIgnoreCase))
        End If

        lstAllMatches.DataSource = Nothing
        lstAllMatches.DataSource = allCodes.OrderBy(Function(c) c).Take(200).ToList()
    End Sub

    Private Function SelectedMatchCode() As String
        Return TryCast(lstAllMatches.SelectedItem, String)
    End Function

    ' -------------------------
    ' Add/Remove BEFORE
    ' -------------------------
    Private Sub btnAddBefore_Click(sender As Object, e As EventArgs) Handles btnAddBefore.Click
        If String.IsNullOrWhiteSpace(_selectedCode) Then Return
        Dim target = SelectedMatchCode()
        If String.IsNullOrWhiteSpace(target) Then Return
        If target.Equals(_selectedCode, StringComparison.OrdinalIgnoreCase) Then Return

        Dim r = GetOrCreateRule(_selectedCode)
        If r.Before Is Nothing Then r.Before = New List(Of String)()

        If Not r.Before.Any(Function(x) x.Equals(target, StringComparison.OrdinalIgnoreCase)) Then
            r.Before.Add(target)
        End If

        LoadRuleForSelectedCode()
    End Sub

    Private Sub btnRemoveBefore_Click(sender As Object, e As EventArgs) Handles btnRemoveBefore.Click
        If String.IsNullOrWhiteSpace(_selectedCode) Then Return
        Dim removeCode = TryCast(lstBefore.SelectedItem, String)
        If String.IsNullOrWhiteSpace(removeCode) Then Return

        Dim r = GetOrCreateRule(_selectedCode)
        If r.Before Is Nothing Then Return

        r.Before = r.Before.Where(Function(x) Not x.Equals(removeCode, StringComparison.OrdinalIgnoreCase)).ToList()
        LoadRuleForSelectedCode()
    End Sub

    ' -------------------------
    ' Add/Remove AFTER
    ' -------------------------
    Private Sub btnAddAfter_Click(sender As Object, e As EventArgs) Handles btnAddAfter.Click
        If String.IsNullOrWhiteSpace(_selectedCode) Then Return
        Dim target = SelectedMatchCode()
        If String.IsNullOrWhiteSpace(target) Then Return
        If target.Equals(_selectedCode, StringComparison.OrdinalIgnoreCase) Then Return

        Dim r = GetOrCreateRule(_selectedCode)
        If r.After Is Nothing Then r.After = New List(Of String)()

        If Not r.After.Any(Function(x) x.Equals(target, StringComparison.OrdinalIgnoreCase)) Then
            r.After.Add(target)
        End If

        LoadRuleForSelectedCode()
    End Sub

    Private Sub btnRemoveAfter_Click(sender As Object, e As EventArgs) Handles btnRemoveAfter.Click
        If String.IsNullOrWhiteSpace(_selectedCode) Then Return
        Dim removeCode = TryCast(lstAfter.SelectedItem, String)
        If String.IsNullOrWhiteSpace(removeCode) Then Return

        Dim r = GetOrCreateRule(_selectedCode)
        If r.After Is Nothing Then Return

        r.After = r.After.Where(Function(x) Not x.Equals(removeCode, StringComparison.OrdinalIgnoreCase)).ToList()
        LoadRuleForSelectedCode()
    End Sub

    ' -------------------------
    ' Save / close
    ' -------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Final cleanup: ensure no dupes / no self refs
        For Each r In _ruleLib.Items
            If String.IsNullOrWhiteSpace(r.Code) Then Continue For

            If r.Before Is Nothing Then r.Before = New List(Of String)()
            If r.After Is Nothing Then r.After = New List(Of String)()

            r.Before = r.Before.
                Where(Function(x) Not String.IsNullOrWhiteSpace(x) AndAlso Not x.Equals(r.Code, StringComparison.OrdinalIgnoreCase)).
                Distinct(StringComparer.OrdinalIgnoreCase).ToList()

            r.After = r.After.
                Where(Function(x) Not String.IsNullOrWhiteSpace(x) AndAlso Not x.Equals(r.Code, StringComparison.OrdinalIgnoreCase)).
                Distinct(StringComparer.OrdinalIgnoreCase).ToList()
        Next

        OrderRuleStore.SaveRules(_ruleLib)
        MessageBox.Show("Saved ordering rules.", "Rules", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class