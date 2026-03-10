<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcPlan
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
        lblPlanStatus = New Label()
        dgvPlan = New DataGridView()
        btnRefresh = New Button()
        lstErrors = New ListBox()
        CType(dgvPlan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblPlanStatus
        ' 
        lblPlanStatus.AutoSize = True
        lblPlanStatus.Location = New Point(3, 0)
        lblPlanStatus.Name = "lblPlanStatus"
        lblPlanStatus.Size = New Size(30, 15)
        lblPlanStatus.TabIndex = 0
        lblPlanStatus.Text = "Plan"
        ' 
        ' dgvPlan
        ' 
        dgvPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPlan.Location = New Point(3, 18)
        dgvPlan.Name = "dgvPlan"
        dgvPlan.Size = New Size(650, 267)
        dgvPlan.TabIndex = 1
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(3, 291)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(371, 54)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' lstErrors
        ' 
        lstErrors.FormattingEnabled = True
        lstErrors.Location = New Point(659, 18)
        lstErrors.Name = "lstErrors"
        lstErrors.Size = New Size(650, 274)
        lstErrors.TabIndex = 3
        ' 
        ' UcPlan
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lstErrors)
        Controls.Add(btnRefresh)
        Controls.Add(dgvPlan)
        Controls.Add(lblPlanStatus)
        Name = "UcPlan"
        Size = New Size(1312, 352)
        CType(dgvPlan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblPlanStatus As Label
    Friend WithEvents dgvPlan As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lstErrors As ListBox

End Class
