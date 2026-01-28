<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHome
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
        Me.txtrole = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtrole
        '
        Me.txtrole.AutoSize = True
        Me.txtrole.Font = New System.Drawing.Font("Minecraft", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrole.Location = New System.Drawing.Point(210, 254)
        Me.txtrole.Name = "txtrole"
        Me.txtrole.Size = New System.Drawing.Size(380, 39)
        Me.txtrole.TabIndex = 1
        Me.txtrole.Text = "Anda tidak dikenali!"
        Me.txtrole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(801, 547)
        Me.Controls.Add(Me.txtrole)
        Me.Name = "FrmHome"
        Me.Text = "FrmHome"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtrole As System.Windows.Forms.Label
End Class
