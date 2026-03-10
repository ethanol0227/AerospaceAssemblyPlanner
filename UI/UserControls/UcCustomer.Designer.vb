<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcCustomer
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
        lblCustomer = New Label()
        lblInfo = New Label()
        SuspendLayout()
        ' 
        ' lblCustomer
        ' 
        lblCustomer.AutoSize = True
        lblCustomer.Location = New Point(3, 0)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(59, 15)
        lblCustomer.TabIndex = 0
        lblCustomer.Text = "Customer"
        ' 
        ' lblInfo
        ' 
        lblInfo.AutoSize = True
        lblInfo.Location = New Point(3, 24)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(41, 15)
        lblInfo.TabIndex = 1
        lblInfo.Text = "Label1"
        ' 
        ' UcCustomer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblInfo)
        Controls.Add(lblCustomer)
        Name = "UcCustomer"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblInfo As Label

End Class
