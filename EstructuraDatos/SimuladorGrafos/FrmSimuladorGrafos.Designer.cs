namespace Simulador
{
	partial class FrmSimulador
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NuevoVerticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSCrearVertice.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pizarra
            // 
            this.Pizarra.Location = new System.Drawing.Point(12, 74);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(776, 364);
            this.Pizarra.TabIndex = 0;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(289, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(178, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Simulador de grafos";
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoVerticeToolStripMenuItem});
            this.CMSCrearVertice.Name = "contextMenuStrip1";
            this.CMSCrearVertice.Size = new System.Drawing.Size(181, 48);
            // 
            // NuevoVerticeToolStripMenuItem
            // 
            this.NuevoVerticeToolStripMenuItem.Name = "NuevoVerticeToolStripMenuItem";
            this.NuevoVerticeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NuevoVerticeToolStripMenuItem.Text = "Nuevo Vértice";
            this.NuevoVerticeToolStripMenuItem.Click += new System.EventHandler(this.NuevoVerticeToolStripMenuItem_Click);
            // 
            // FrmSimulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Pizarra);
            this.Name = "FrmSimulador";
            this.Text = "Simulador de grafos";
            this.CMSCrearVertice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel Pizarra;
		private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem NuevoVerticeToolStripMenuItem;
    }
}

