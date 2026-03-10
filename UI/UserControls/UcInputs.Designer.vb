<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcInputs
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        lblSuggestion = New Label()
        txtSearch = New TextBox()
        btnClearSearch = New Button()
        chkHideSelected = New CheckBox()
        dgvAllCodes = New DataGridView()
        btnAdd = New Button()
        btnRemove = New Button()
        dgvSelected = New DataGridView()
        btnClearSelected = New Button()
        btnSaveAsTemplate = New Button()
        btnApplySuggested = New Button()
        txtPreview = New TextBox()
        txtQuickAdd = New TextBox()
        btnQuickAdd = New Button()
        CType(dgvAllCodes, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvSelected, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblSuggestion
        ' 
        lblSuggestion.AutoSize = True
        lblSuggestion.Location = New Point(469, 498)
        lblSuggestion.Name = "lblSuggestion"
        lblSuggestion.Size = New Size(66, 15)
        lblSuggestion.TabIndex = 0
        lblSuggestion.Text = "Suggestion"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(3, 3)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(269, 23)
        txtSearch.TabIndex = 1
        txtSearch.Text = "Search"
        ' 
        ' btnClearSearch
        ' 
        btnClearSearch.Location = New Point(278, 3)
        btnClearSearch.Name = "btnClearSearch"
        btnClearSearch.Size = New Size(100, 23)
        btnClearSearch.TabIndex = 2
        btnClearSearch.Text = "ClearSearch"
        btnClearSearch.UseVisualStyleBackColor = True
        ' 
        ' chkHideSelected
        ' 
        chkHideSelected.AutoSize = True
        chkHideSelected.Location = New Point(384, 7)
        chkHideSelected.Name = "chkHideSelected"
        chkHideSelected.Size = New Size(95, 19)
        chkHideSelected.TabIndex = 3
        chkHideSelected.Text = "HideSelected"
        chkHideSelected.UseVisualStyleBackColor = True
        ' 
        ' dgvAllCodes
        ' 
        dgvAllCodes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAllCodes.Location = New Point(3, 32)
        dgvAllCodes.MultiSelect = False
        dgvAllCodes.Name = "dgvAllCodes"
        dgvAllCodes.ReadOnly = True
        dgvAllCodes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllCodes.Size = New Size(460, 567)
        dgvAllCodes.TabIndex = 4
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(469, 62)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(514, 23)
        btnAdd.TabIndex = 5
        btnAdd.Text = "Add >>"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnRemove
        ' 
        btnRemove.Location = New Point(469, 33)
        btnRemove.Name = "btnRemove"
        btnRemove.Size = New Size(514, 23)
        btnRemove.TabIndex = 6
        btnRemove.Text = "<< Remove"
        btnRemove.UseVisualStyleBackColor = True
        ' 
        ' dgvSelected
        ' 
        dgvSelected.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSelected.Location = New Point(989, 32)
        dgvSelected.MultiSelect = False
        dgvSelected.Name = "dgvSelected"
        dgvSelected.ReadOnly = True
        dgvSelected.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSelected.Size = New Size(460, 567)
        dgvSelected.TabIndex = 7
        ' 
        ' btnClearSelected
        ' 
        btnClearSelected.Location = New Point(469, 574)
        btnClearSelected.Name = "btnClearSelected"
        btnClearSelected.Size = New Size(514, 23)
        btnClearSelected.TabIndex = 8
        btnClearSelected.Text = "ClearSelected"
        btnClearSelected.UseVisualStyleBackColor = True
        ' 
        ' btnSaveAsTemplate
        ' 
        btnSaveAsTemplate.Location = New Point(469, 545)
        btnSaveAsTemplate.Name = "btnSaveAsTemplate"
        btnSaveAsTemplate.Size = New Size(514, 23)
        btnSaveAsTemplate.TabIndex = 9
        btnSaveAsTemplate.Text = "SaveAsTemplate"
        btnSaveAsTemplate.UseVisualStyleBackColor = True
        ' 
        ' btnApplySuggested
        ' 
        btnApplySuggested.Location = New Point(469, 516)
        btnApplySuggested.Name = "btnApplySuggested"
        btnApplySuggested.Size = New Size(514, 23)
        btnApplySuggested.TabIndex = 10
        btnApplySuggested.Text = "ApplySuggested"
        btnApplySuggested.UseVisualStyleBackColor = True
        ' 
        ' txtPreview
        ' 
        txtPreview.Location = New Point(469, 91)
        txtPreview.Multiline = True
        txtPreview.Name = "txtPreview"
        txtPreview.ReadOnly = True
        txtPreview.ScrollBars = ScrollBars.Vertical
        txtPreview.Size = New Size(514, 404)
        txtPreview.TabIndex = 11
        ' 
        ' txtQuickAdd
        ' 
        txtQuickAdd.Location = New Point(989, 5)
        txtQuickAdd.Name = "txtQuickAdd"
        txtQuickAdd.Size = New Size(308, 23)
        txtQuickAdd.TabIndex = 12
        ' 
        ' btnQuickAdd
        ' 
        btnQuickAdd.Location = New Point(1303, 5)
        btnQuickAdd.Name = "btnQuickAdd"
        btnQuickAdd.Size = New Size(146, 23)
        btnQuickAdd.TabIndex = 13
        btnQuickAdd.Text = "Add"
        btnQuickAdd.UseVisualStyleBackColor = True
        ' 
        ' UcInputs
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnQuickAdd)
        Controls.Add(txtQuickAdd)
        Controls.Add(txtPreview)
        Controls.Add(btnApplySuggested)
        Controls.Add(btnSaveAsTemplate)
        Controls.Add(btnClearSelected)
        Controls.Add(dgvSelected)
        Controls.Add(btnRemove)
        Controls.Add(btnAdd)
        Controls.Add(dgvAllCodes)
        Controls.Add(chkHideSelected)
        Controls.Add(btnClearSearch)
        Controls.Add(txtSearch)
        Controls.Add(lblSuggestion)
        Name = "UcInputs"
        Size = New Size(1452, 602)
        CType(dgvAllCodes, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvSelected, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblSuggestion As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClearSearch As Button
    Friend WithEvents chkHideSelected As CheckBox
    Friend WithEvents dgvAllCodes As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents dgvSelected As DataGridView
    Friend WithEvents btnClearSelected As Button
    Friend WithEvents btnSaveAsTemplate As Button
    Friend WithEvents btnApplySuggested As Button
    Friend WithEvents txtPreview As TextBox
    Friend WithEvents txtQuickAdd As TextBox
    Friend WithEvents btnQuickAdd As Button

End Class
