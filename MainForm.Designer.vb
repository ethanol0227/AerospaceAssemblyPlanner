<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlLeft = New Panel()
        btnEditLibrary = New Button()
        lstSteps = New ListBox()
        lblCustomer = New Label()
        pnlContent = New Panel()
        pnlBottom = New Panel()
        btnNext = New Button()
        lblStatus = New Label()
        btnBack = New Button()
        pnlLeft.SuspendLayout()
        pnlBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.Controls.Add(btnEditLibrary)
        pnlLeft.Controls.Add(lstSteps)
        pnlLeft.Controls.Add(lblCustomer)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(260, 761)
        pnlLeft.TabIndex = 0
        ' 
        ' btnEditLibrary
        ' 
        btnEditLibrary.Location = New Point(3, 118)
        btnEditLibrary.Name = "btnEditLibrary"
        btnEditLibrary.Size = New Size(251, 23)
        btnEditLibrary.TabIndex = 2
        btnEditLibrary.Text = "Edit Northrop Library"
        btnEditLibrary.UseVisualStyleBackColor = True
        ' 
        ' lstSteps
        ' 
        lstSteps.FormattingEnabled = True
        lstSteps.Items.AddRange(New Object() {"Customer", "Template", "Inputs", "Plan", "Export"})
        lstSteps.Location = New Point(3, 18)
        lstSteps.Name = "lstSteps"
        lstSteps.Size = New Size(120, 94)
        lstSteps.TabIndex = 1
        ' 
        ' lblCustomer
        ' 
        lblCustomer.AutoSize = True
        lblCustomer.Dock = DockStyle.Fill
        lblCustomer.Location = New Point(0, 0)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(100, 15)
        lblCustomer.TabIndex = 0
        lblCustomer.Text = "Customer: (none)"
        ' 
        ' pnlContent
        ' 
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(260, 0)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1452, 761)
        pnlContent.TabIndex = 1
        ' 
        ' pnlBottom
        ' 
        pnlBottom.Controls.Add(btnNext)
        pnlBottom.Controls.Add(lblStatus)
        pnlBottom.Controls.Add(btnBack)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(260, 701)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(1452, 60)
        pnlBottom.TabIndex = 0
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(737, 3)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(175, 53)
        btnNext.TabIndex = 1
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(3, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(104, 15)
        lblStatus.TabIndex = 2
        lblStatus.Text = "Status: Not loaded"
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(551, 3)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(175, 54)
        btnBack.TabIndex = 0
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1712, 761)
        Controls.Add(pnlBottom)
        Controls.Add(pnlContent)
        Controls.Add(pnlLeft)
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Advanced F&R Assembly Planner"
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlBottom.ResumeLayout(False)
        pnlBottom.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lstSteps As ListBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnEditLibrary As Button

End Class
