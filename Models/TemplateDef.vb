Public Class TemplateDef
    Public Property Id As String
    Public Property Name As String
    Public Property Details As String
    Public Property Codes As New List(Of String) ' list of NoteCode.Code values (ex: "*ASN0003")
End Class

Public Class TemplateLibrary
    Public Property Version As String = "1"
    Public Property Items As New List(Of TemplateDef)
End Class