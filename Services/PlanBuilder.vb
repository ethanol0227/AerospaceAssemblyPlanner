Public Class PlanBuilder

    Public Shared Function Build(state As AppState) As List(Of NoteCode)
        Dim notes = state.NorthropLibrary.Items

        Select Case state.SelectedTemplate
            Case "Wet Install (Starter)"
                ' Super simple starter: just show the first matching items by OpType
                Dim prep = notes.FirstOrDefault(Function(n) n.OpType = "SurfacePrep")
                Dim promoter = notes.FirstOrDefault(Function(n) n.OpType = "AdhesionPromoter")
                Dim install = notes.FirstOrDefault(Function(n) n.OpType = "WetInstall")

                Dim result As New List(Of NoteCode)
                If prep IsNot Nothing Then result.Add(prep)
                If promoter IsNot Nothing Then result.Add(promoter)
                If install IsNot Nothing Then result.Add(install)
                Return result

            Case "Surface Prep Only"
                Return notes.Where(Function(n) n.OpType = "SurfacePrep").Take(1).ToList()

            Case Else
                Return New List(Of NoteCode)
        End Select
    End Function

End Class