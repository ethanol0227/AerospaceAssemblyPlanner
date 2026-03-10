Imports System.IO
Imports System.Text.Json

Public Class TemplateStore

    Private Shared Function TemplatePath() As String
        Dim folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "AerospaceAssemblyPlanner"
        )
        Directory.CreateDirectory(folder)
        Return Path.Combine(folder, "northrop_templates.json")
    End Function

    Public Shared Function LoadTemplates() As TemplateLibrary
        Dim p = TemplatePath()

        If Not File.Exists(p) Then
            Return New TemplateLibrary With {.Items = New List(Of TemplateDef)()}
        End If

        Dim json = File.ReadAllText(p)
        Dim opts As New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
        Dim tmplib = JsonSerializer.Deserialize(Of TemplateLibrary)(json, opts)

        If tmplib Is Nothing OrElse tmplib.Items Is Nothing Then
            Return New TemplateLibrary With {.Items = New List(Of TemplateDef)()}
        End If

        Return tmplib
    End Function

    Public Shared Sub SaveTemplates(tmplib As TemplateLibrary)
        Dim p = TemplatePath()
        Dim opts As New JsonSerializerOptions With {.WriteIndented = True}
        Dim json = JsonSerializer.Serialize(tmplib, opts)
        File.WriteAllText(p, json)
    End Sub

End Class