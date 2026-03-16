<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MAIN
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
        TextBox1 = New TextBox()
        NGC = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button8 = New Button()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = SystemColors.Control
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Font = New Font("SF Movie Poster", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(264, 12)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(252, 61)
        TextBox1.TabIndex = 0
        TextBox1.Text = "WELCOME, " & vbCrLf & "PLEASE SELECT A CUSTOMER"
        TextBox1.TextAlign = HorizontalAlignment.Center
        ' 
        ' NGC
        ' 
        NGC.Location = New Point(264, 79)
        NGC.Name = "NGC"
        NGC.Size = New Size(178, 33)
        NGC.TabIndex = 1
        NGC.Text = "NGC (Northrop Grumman)"
        NGC.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(264, 118)
        Button2.Name = "Button2"
        Button2.Size = New Size(107, 33)
        Button2.TabIndex = 2
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(264, 157)
        Button3.Name = "Button3"
        Button3.Size = New Size(107, 33)
        Button3.TabIndex = 3
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(264, 196)
        Button4.Name = "Button4"
        Button4.Size = New Size(107, 33)
        Button4.TabIndex = 4
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(264, 235)
        Button5.Name = "Button5"
        Button5.Size = New Size(107, 33)
        Button5.TabIndex = 5
        Button5.Text = "Button5"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(264, 274)
        Button6.Name = "Button6"
        Button6.Size = New Size(107, 33)
        Button6.TabIndex = 6
        Button6.Text = "Button6"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(264, 313)
        Button7.Name = "Button7"
        Button7.Size = New Size(107, 33)
        Button7.TabIndex = 7
        Button7.Text = "Button7"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(264, 352)
        Button8.Name = "Button8"
        Button8.Size = New Size(107, 33)
        Button8.TabIndex = 8
        Button8.Text = "Button8"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' MAIN
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button8)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(NGC)
        Controls.Add(TextBox1)
        Name = "MAIN"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents NGC As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button

End Class
