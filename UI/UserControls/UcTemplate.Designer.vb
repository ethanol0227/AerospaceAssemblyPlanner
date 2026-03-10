<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcTemplate
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
        lblTemplateTitle = New Label()
        lstTemplates = New ListBox()
        btnApplyTemplate = New Button()
        txtTemplateDetails = New TextBox()
        lblSelected = New Label()
        SuspendLayout()
        ' 
        ' lblTemplateTitle
        ' 
        lblTemplateTitle.AutoSize = True
        lblTemplateTitle.Dock = DockStyle.Top
        lblTemplateTitle.Font = New Font("Segoe UI", 14F)
        lblTemplateTitle.Location = New Point(300, 0)
        lblTemplateTitle.Name = "lblTemplateTitle"
        lblTemplateTitle.Size = New Size(88, 25)
        lblTemplateTitle.TabIndex = 0
        lblTemplateTitle.Text = "Template"
        lblTemplateTitle.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lstTemplates
        ' 
        lstTemplates.Dock = DockStyle.Left
        lstTemplates.FormattingEnabled = True
        lstTemplates.Location = New Point(0, 0)
        lstTemplates.Name = "lstTemplates"
        lstTemplates.Size = New Size(300, 490)
        lstTemplates.TabIndex = 1
        ' 
        ' btnApplyTemplate
        ' 
        btnApplyTemplate.Location = New Point(326, 391)
        btnApplyTemplate.Name = "btnApplyTemplate"
        btnApplyTemplate.Size = New Size(321, 63)
        btnApplyTemplate.TabIndex = 2
        btnApplyTemplate.Text = "Apply Template"
        btnApplyTemplate.UseVisualStyleBackColor = True
        ' 
        ' txtTemplateDetails
        ' 
        txtTemplateDetails.Location = New Point(306, 34)
        txtTemplateDetails.Multiline = True
        txtTemplateDetails.Name = "txtTemplateDetails"
        txtTemplateDetails.ReadOnly = True
        txtTemplateDetails.ScrollBars = ScrollBars.Vertical
        txtTemplateDetails.Size = New Size(366, 351)
        txtTemplateDetails.TabIndex = 3
        ' 
        ' lblSelected
        ' 
        lblSelected.AutoSize = True
        lblSelected.Location = New Point(560, 7)
        lblSelected.Name = "lblSelected"
        lblSelected.Size = New Size(41, 15)
        lblSelected.TabIndex = 4
        lblSelected.Text = "Label1"
        ' 
        ' UcTemplate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblSelected)
        Controls.Add(txtTemplateDetails)
        Controls.Add(btnApplyTemplate)
        Controls.Add(lblTemplateTitle)
        Controls.Add(lstTemplates)
        Name = "UcTemplate"
        Size = New Size(675, 490)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTemplateTitle As Label
    Friend WithEvents lstTemplates As ListBox
    Friend WithEvents btnApplyTemplate As Button
    Friend WithEvents txtTemplateDetails As TextBox
    Friend WithEvents lblSelected As Label

End Class
