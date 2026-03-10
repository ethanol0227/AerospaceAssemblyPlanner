<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcExport
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
        lblExport = New Label()
        SuspendLayout()
        ' 
        ' lblExport
        ' 
        lblExport.AutoSize = True
        lblExport.Location = New Point(3, 0)
        lblExport.Name = "lblExport"
        lblExport.Size = New Size(40, 15)
        lblExport.TabIndex = 0
        lblExport.Text = "export"
        ' 
        ' UcExport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblExport)
        Name = "UcExport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblExport As Label

End Class
