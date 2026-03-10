Imports System.IO
Imports System.Text.Json

Public Class JsonImportService

    ' Returns "" on success, otherwise error message.
    Public Shared Function ImportJson(Of T)(pickedFile As String,
                                           appDataTargetPath As String,
                                           Optional validate As Func(Of T, String) = Nothing) As String

        If String.IsNullOrWhiteSpace(pickedFile) OrElse Not File.Exists(pickedFile) Then
            Return "Selected file does not exist."
        End If

        Try
            Dim json = File.ReadAllText(pickedFile)

            Dim opts As New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
            Dim obj = JsonSerializer.Deserialize(Of T)(json, opts)

            If obj Is Nothing Then
                Return "JSON loaded but structure is invalid (deserialized to Nothing)."
            End If

            If validate IsNot Nothing Then
                Dim msg = validate(obj)
                If Not String.IsNullOrWhiteSpace(msg) Then Return msg
            End If

            ' Backup existing target
            Dim folder = Path.GetDirectoryName(appDataTargetPath)
            Directory.CreateDirectory(folder)

            If File.Exists(appDataTargetPath) Then
                Dim backup = appDataTargetPath & ".bak_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")
                File.Copy(appDataTargetPath, backup, overwrite:=False)
            End If

            ' Write normalized JSON
            Dim outOpts As New JsonSerializerOptions With {.WriteIndented = True}
            File.WriteAllText(appDataTargetPath, JsonSerializer.Serialize(obj, outOpts))

            Return ""
        Catch ex As Exception
            Return "Import failed: " & ex.Message
        End Try
    End Function

End Class