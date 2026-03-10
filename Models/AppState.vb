Imports System.Linq

Public Class AppState
    Public Property Customer As String = "NORTHROP"
    Public Property NorthropLibrary As NoteLibraryRoot

    ' User choices / workflow state
    Public Property SelectedTemplate As String = ""
    Public Property SelectedCodes As New List(Of String)
    Public Property SelectedTemplateId As String = ""
    Public Property SelectedTemplateName As String = ""

    ' Starter inputs driven by template
    Public Property WetInstall As Boolean = True
    Public Property NeedsSealant As Boolean = True


End Class