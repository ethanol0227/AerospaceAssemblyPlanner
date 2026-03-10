Public Class NoteCode
    Public Property Customer As String
    Public Property Section As String
    Public Property Type As String
    Public Property Code As String
    Public Property Title As String
    Public Property Instruction As String
    Public Property Refs As List(Of String)
    Public Property OpType As String
    Public Property RequiresOJT As Boolean
End Class

Public Class NoteLibraryRoot
    Public Property Version As String
    Public Property Count As Integer
    Public Property Items As List(Of NoteCode)
End Class