Imports System.IO
Imports System.Text.Json

Public Class NoteLibraryService

    Private Shared Function ShippedJsonPath() As String
        ' This is the JSON you included as Content (Copy Always) in the output folder
        Return Path.Combine(Application.StartupPath, "northrop_note_codes.json")
    End Function

    Public Shared Function UserJsonPath() As String
        Dim folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "AerospaceAssemblyPlanner"
        )
        Directory.CreateDirectory(folder)
        Return Path.Combine(folder, "northrop_note_codes.json")
    End Function

    Public Shared Sub EnsureUserCopyExists()
        Dim userPath = UserJsonPath()
        If File.Exists(userPath) Then Return

        Dim shipped = ShippedJsonPath()
        If Not File.Exists(shipped) Then
            Throw New FileNotFoundException("Shipped Northrop JSON not found at: " & shipped)
        End If

        File.Copy(shipped, userPath, overwrite:=False)
    End Sub

    Public Shared Function LoadNorthrop() As NoteLibraryRoot
        EnsureUserCopyExists()

        Dim path = UserJsonPath()
        Dim json = File.ReadAllText(path)

        Dim opts As New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
        Dim root = JsonSerializer.Deserialize(Of NoteLibraryRoot)(json, opts)

        If root Is Nothing OrElse root.Items Is Nothing Then
            Throw New Exception("Failed to load Northrop library JSON (invalid structure).")
        End If

        Return root
    End Function

    Public Shared Sub SaveNorthrop(root As NoteLibraryRoot)
        Dim path = UserJsonPath()

        root.Count = If(root.Items Is Nothing, 0, root.Items.Count)

        Dim opts As New JsonSerializerOptions With {
            .WriteIndented = True
        }

        Dim json = JsonSerializer.Serialize(root, opts)
        File.WriteAllText(path, json)
    End Sub

    Public Shared Sub ResetNorthropToFactory()
        Dim shipped = ShippedJsonPath()
        Dim userPath = UserJsonPath()
        If Not File.Exists(shipped) Then
            Throw New FileNotFoundException("Shipped Northrop JSON not found at: " & shipped)
        End If
        File.Copy(shipped, userPath, overwrite:=True)
    End Sub

End Class