<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderRulesEditorForm
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
        txtCodeSearch = New TextBox()
        lstCodes = New ListBox()
        lblSelectedCode = New Label()
        txtAllSearch = New TextBox()
        lstAllMatches = New ListBox()
        Label1 = New Label()
        lstBefore = New ListBox()
        btnAddBefore = New Button()
        btnRemoveBefore = New Button()
        Label2 = New Label()
        lstAfter = New ListBox()
        btnRemoveAfter = New Button()
        btnAddAfter = New Button()
        btnClose = New Button()
        btnSave = New Button()
        lblRulesPath = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' txtCodeSearch
        ' 
        txtCodeSearch.Location = New Point(111, 443)
        txtCodeSearch.Name = "txtCodeSearch"
        txtCodeSearch.Size = New Size(121, 23)
        txtCodeSearch.TabIndex = 0
        ' 
        ' lstCodes
        ' 
        lstCodes.FormattingEnabled = True
        lstCodes.Location = New Point(12, 12)
        lstCodes.Name = "lstCodes"
        lstCodes.Size = New Size(220, 424)
        lstCodes.TabIndex = 1
        ' 
        ' lblSelectedCode
        ' 
        lblSelectedCode.AutoSize = True
        lblSelectedCode.Location = New Point(100, 475)
        lblSelectedCode.Name = "lblSelectedCode"
        lblSelectedCode.Size = New Size(79, 15)
        lblSelectedCode.TabIndex = 2
        lblSelectedCode.Text = "SelectedCode"
        ' 
        ' txtAllSearch
        ' 
        txtAllSearch.Location = New Point(306, 12)
        txtAllSearch.Name = "txtAllSearch"
        txtAllSearch.Size = New Size(152, 23)
        txtAllSearch.TabIndex = 3
        ' 
        ' lstAllMatches
        ' 
        lstAllMatches.FormattingEnabled = True
        lstAllMatches.Location = New Point(238, 42)
        lstAllMatches.Name = "lstAllMatches"
        lstAllMatches.Size = New Size(220, 394)
        lstAllMatches.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 14F)
        Label1.Location = New Point(464, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(220, 23)
        Label1.TabIndex = 5
        Label1.Text = "Must be BEFORE"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lstBefore
        ' 
        lstBefore.FormattingEnabled = True
        lstBefore.Location = New Point(464, 42)
        lstBefore.Name = "lstBefore"
        lstBefore.Size = New Size(220, 394)
        lstBefore.TabIndex = 6
        ' 
        ' btnAddBefore
        ' 
        btnAddBefore.Location = New Point(464, 442)
        btnAddBefore.Name = "btnAddBefore"
        btnAddBefore.Size = New Size(220, 23)
        btnAddBefore.TabIndex = 7
        btnAddBefore.Text = "AddBefore"
        btnAddBefore.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveBefore
        ' 
        btnRemoveBefore.Location = New Point(464, 471)
        btnRemoveBefore.Name = "btnRemoveBefore"
        btnRemoveBefore.Size = New Size(220, 23)
        btnRemoveBefore.TabIndex = 8
        btnRemoveBefore.Text = "RemoveBefore"
        btnRemoveBefore.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Segoe UI", 14F)
        Label2.Location = New Point(690, 12)
        Label2.Name = "Label2"
        Label2.Size = New Size(220, 23)
        Label2.TabIndex = 9
        Label2.Text = "Must be AFTER"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lstAfter
        ' 
        lstAfter.FormattingEnabled = True
        lstAfter.Location = New Point(690, 42)
        lstAfter.Name = "lstAfter"
        lstAfter.Size = New Size(220, 394)
        lstAfter.TabIndex = 10
        ' 
        ' btnRemoveAfter
        ' 
        btnRemoveAfter.Location = New Point(690, 471)
        btnRemoveAfter.Name = "btnRemoveAfter"
        btnRemoveAfter.Size = New Size(220, 23)
        btnRemoveAfter.TabIndex = 12
        btnRemoveAfter.Text = "RemoveAfter"
        btnRemoveAfter.UseVisualStyleBackColor = True
        ' 
        ' btnAddAfter
        ' 
        btnAddAfter.Location = New Point(690, 442)
        btnAddAfter.Name = "btnAddAfter"
        btnAddAfter.Size = New Size(220, 23)
        btnAddAfter.TabIndex = 11
        btnAddAfter.Text = "AddAfter"
        btnAddAfter.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(238, 471)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(220, 23)
        btnClose.TabIndex = 14
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(238, 442)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(220, 23)
        btnSave.TabIndex = 13
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lblRulesPath
        ' 
        lblRulesPath.AutoSize = True
        lblRulesPath.Location = New Point(12, 497)
        lblRulesPath.Name = "lblRulesPath"
        lblRulesPath.Size = New Size(23, 15)
        lblRulesPath.TabIndex = 15
        lblRulesPath.Text = "file"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 475)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 15)
        Label3.TabIndex = 16
        Label3.Text = "SelectedCode:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 446)
        Label4.Name = "Label4"
        Label4.Size = New Size(93, 15)
        Label4.TabIndex = 17
        Label4.Text = "Search to Select:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(238, 15)
        Label5.Name = "Label5"
        Label5.Size = New Size(62, 15)
        Label5.TabIndex = 18
        Label5.Text = "Search All:"
        ' 
        ' OrderRulesEditorForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(921, 521)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(lblRulesPath)
        Controls.Add(btnClose)
        Controls.Add(btnSave)
        Controls.Add(btnRemoveAfter)
        Controls.Add(btnAddAfter)
        Controls.Add(lstAfter)
        Controls.Add(Label2)
        Controls.Add(btnRemoveBefore)
        Controls.Add(btnAddBefore)
        Controls.Add(lstBefore)
        Controls.Add(Label1)
        Controls.Add(lstAllMatches)
        Controls.Add(txtAllSearch)
        Controls.Add(lblSelectedCode)
        Controls.Add(lstCodes)
        Controls.Add(txtCodeSearch)
        Name = "OrderRulesEditorForm"
        Text = "Pre & Post Rules Editor"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCodeSearch As TextBox
    Friend WithEvents lstCodes As ListBox
    Friend WithEvents lblSelectedCode As Label
    Friend WithEvents txtAllSearch As TextBox
    Friend WithEvents lstAllMatches As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lstBefore As ListBox
    Friend WithEvents btnAddBefore As Button
    Friend WithEvents btnRemoveBefore As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lstAfter As ListBox
    Friend WithEvents btnRemoveAfter As Button
    Friend WithEvents btnAddAfter As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblRulesPath As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
