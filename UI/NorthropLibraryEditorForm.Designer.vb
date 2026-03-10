<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NorthropLibraryEditorForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        dgvNotes = New DataGridView()
        btnSave = New Button()
        btnAdd = New Button()
        btnDelete = New Button()
        btnResetFactory = New Button()
        Panel1 = New Panel()
        btnImportLibrary = New Button()
        btnEditOrdering = New Button()
        btnAdminToggle = New Button()
        lblPath = New Label()
        btnExportLibrary = New Button()
        CType(dgvNotes, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvNotes
        ' 
        dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvNotes.Dock = DockStyle.Fill
        dgvNotes.Location = New Point(0, 0)
        dgvNotes.Name = "dgvNotes"
        dgvNotes.Size = New Size(1571, 588)
        dgvNotes.TabIndex = 0
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(3, 3)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(128, 23)
        btnSave.TabIndex = 1
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(137, 3)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(128, 23)
        btnAdd.TabIndex = 2
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(271, 3)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(128, 23)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnResetFactory
        ' 
        btnResetFactory.Location = New Point(405, 3)
        btnResetFactory.Name = "btnResetFactory"
        btnResetFactory.Size = New Size(128, 23)
        btnResetFactory.TabIndex = 4
        btnResetFactory.Text = "ResetFactory"
        btnResetFactory.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnExportLibrary)
        Panel1.Controls.Add(btnImportLibrary)
        Panel1.Controls.Add(btnEditOrdering)
        Panel1.Controls.Add(btnAdminToggle)
        Panel1.Controls.Add(lblPath)
        Panel1.Controls.Add(btnSave)
        Panel1.Controls.Add(btnResetFactory)
        Panel1.Controls.Add(btnAdd)
        Panel1.Controls.Add(btnDelete)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1571, 31)
        Panel1.TabIndex = 6
        ' 
        ' btnImportLibrary
        ' 
        btnImportLibrary.Location = New Point(1100, 5)
        btnImportLibrary.Name = "btnImportLibrary"
        btnImportLibrary.Size = New Size(152, 23)
        btnImportLibrary.TabIndex = 8
        btnImportLibrary.Text = "Import Note Codes JSON"
        btnImportLibrary.UseVisualStyleBackColor = True
        ' 
        ' btnEditOrdering
        ' 
        btnEditOrdering.Location = New Point(1258, 5)
        btnEditOrdering.Name = "btnEditOrdering"
        btnEditOrdering.Size = New Size(152, 23)
        btnEditOrdering.TabIndex = 7
        btnEditOrdering.Text = "Edit Ordering…"
        btnEditOrdering.UseVisualStyleBackColor = True
        ' 
        ' btnAdminToggle
        ' 
        btnAdminToggle.Location = New Point(1416, 5)
        btnAdminToggle.Name = "btnAdminToggle"
        btnAdminToggle.Size = New Size(152, 23)
        btnAdminToggle.TabIndex = 6
        btnAdminToggle.Text = "Admin Mode: OFF"
        btnAdminToggle.UseVisualStyleBackColor = True
        ' 
        ' lblPath
        ' 
        lblPath.AutoSize = True
        lblPath.Location = New Point(539, 7)
        lblPath.Name = "lblPath"
        lblPath.Size = New Size(41, 15)
        lblPath.TabIndex = 5
        lblPath.Text = "Label1"
        ' 
        ' btnExportLibrary
        ' 
        btnExportLibrary.Location = New Point(942, 5)
        btnExportLibrary.Name = "btnExportLibrary"
        btnExportLibrary.Size = New Size(152, 23)
        btnExportLibrary.TabIndex = 9
        btnExportLibrary.Text = "Export Note Codes JSON"
        btnExportLibrary.UseVisualStyleBackColor = True
        ' 
        ' NorthropLibraryEditorForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1571, 588)
        Controls.Add(Panel1)
        Controls.Add(dgvNotes)
        Name = "NorthropLibraryEditorForm"
        Text = "Northrop Library Editor"
        CType(dgvNotes, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvNotes As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnResetFactory As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPath As Label
    Friend WithEvents btnAdminToggle As Button
    Friend WithEvents btnEditOrdering As Button
    Friend WithEvents btnImportLibrary As Button
    Friend WithEvents btnExportLibrary As Button
End Class
