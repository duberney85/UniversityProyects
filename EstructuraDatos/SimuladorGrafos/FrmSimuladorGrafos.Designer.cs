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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarArista = new System.Windows.Forms.Button();
            this.cbAristas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarVertice = new System.Windows.Forms.Button();
            this.cbVertices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRecorridoAnchura = new System.Windows.Forms.Button();
            this.btnRecorridoProfundidad = new System.Windows.Forms.Button();
            this.cbNodoPartida = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarNodo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDistancia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.txtNodoBuscar = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEliminarEtiqueta = new System.Windows.Forms.Button();
            this.cbListaEtiquetas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCrearEtiqueta = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreEtiqueta = new System.Windows.Forms.TextBox();
            this.CMSCrearVertice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pizarra
            // 
            this.Pizarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pizarra.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Pizarra.Location = new System.Drawing.Point(349, 74);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(823, 637);
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
            this.CMSCrearVertice.Size = new System.Drawing.Size(148, 26);
            // 
            // NuevoVerticeToolStripMenuItem
            // 
            this.NuevoVerticeToolStripMenuItem.Name = "NuevoVerticeToolStripMenuItem";
            this.NuevoVerticeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.NuevoVerticeToolStripMenuItem.Text = "Nuevo Vértice";
            this.NuevoVerticeToolStripMenuItem.Click += new System.EventHandler(this.NuevoVerticeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarArista);
            this.groupBox1.Controls.Add(this.cbAristas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEliminarVertice);
            this.groupBox1.Controls.Add(this.cbVertices);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliminar nodos y aristas";
            // 
            // btnEliminarArista
            // 
            this.btnEliminarArista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArista.Location = new System.Drawing.Point(226, 52);
            this.btnEliminarArista.Name = "btnEliminarArista";
            this.btnEliminarArista.Size = new System.Drawing.Size(99, 23);
            this.btnEliminarArista.TabIndex = 5;
            this.btnEliminarArista.Text = "Eliminar";
            this.btnEliminarArista.UseVisualStyleBackColor = true;
            this.btnEliminarArista.Click += new System.EventHandler(this.btnEliminarArista_Click);
            // 
            // cbAristas
            // 
            this.cbAristas.FormattingEnabled = true;
            this.cbAristas.Location = new System.Drawing.Point(55, 52);
            this.cbAristas.Name = "cbAristas";
            this.cbAristas.Size = new System.Drawing.Size(163, 23);
            this.cbAristas.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Arista:";
            // 
            // btnEliminarVertice
            // 
            this.btnEliminarVertice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarVertice.Location = new System.Drawing.Point(226, 23);
            this.btnEliminarVertice.Name = "btnEliminarVertice";
            this.btnEliminarVertice.Size = new System.Drawing.Size(99, 23);
            this.btnEliminarVertice.TabIndex = 2;
            this.btnEliminarVertice.Text = "Eliminar";
            this.btnEliminarVertice.UseVisualStyleBackColor = true;
            this.btnEliminarVertice.Click += new System.EventHandler(this.btnEliminarVertice_Click);
            // 
            // cbVertices
            // 
            this.cbVertices.FormattingEnabled = true;
            this.cbVertices.Location = new System.Drawing.Point(55, 23);
            this.cbVertices.Name = "cbVertices";
            this.cbVertices.Size = new System.Drawing.Size(163, 23);
            this.cbVertices.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vértice:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRecorridoAnchura);
            this.groupBox2.Controls.Add(this.btnRecorridoProfundidad);
            this.groupBox2.Controls.Add(this.cbNodoPartida);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recorridos";
            // 
            // btnRecorridoAnchura
            // 
            this.btnRecorridoAnchura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecorridoAnchura.Location = new System.Drawing.Point(213, 72);
            this.btnRecorridoAnchura.Name = "btnRecorridoAnchura";
            this.btnRecorridoAnchura.Size = new System.Drawing.Size(106, 25);
            this.btnRecorridoAnchura.TabIndex = 8;
            this.btnRecorridoAnchura.Text = "Anchura";
            this.btnRecorridoAnchura.UseVisualStyleBackColor = true;
            this.btnRecorridoAnchura.Click += new System.EventHandler(this.btnRecorridoAnchura_Click);
            // 
            // btnRecorridoProfundidad
            // 
            this.btnRecorridoProfundidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecorridoProfundidad.Location = new System.Drawing.Point(9, 72);
            this.btnRecorridoProfundidad.Name = "btnRecorridoProfundidad";
            this.btnRecorridoProfundidad.Size = new System.Drawing.Size(106, 25);
            this.btnRecorridoProfundidad.TabIndex = 7;
            this.btnRecorridoProfundidad.Text = "Profundidad";
            this.btnRecorridoProfundidad.UseVisualStyleBackColor = true;
            this.btnRecorridoProfundidad.Click += new System.EventHandler(this.btnRecorridoProfundidad_Click);
            // 
            // cbNodoPartida
            // 
            this.cbNodoPartida.FormattingEnabled = true;
            this.cbNodoPartida.Location = new System.Drawing.Point(121, 29);
            this.cbNodoPartida.Name = "cbNodoPartida";
            this.cbNodoPartida.Size = new System.Drawing.Size(198, 23);
            this.cbNodoPartida.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nodo de partida:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscarNodo);
            this.groupBox3.Controls.Add(this.txtNodoBuscar);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 87);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar Nodo";
            // 
            // btnBuscarNodo
            // 
            this.btnBuscarNodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarNodo.Location = new System.Drawing.Point(158, 32);
            this.btnBuscarNodo.Name = "btnBuscarNodo";
            this.btnBuscarNodo.Size = new System.Drawing.Size(90, 27);
            this.btnBuscarNodo.TabIndex = 9;
            this.btnBuscarNodo.Text = "Buscar";
            this.btnBuscarNodo.UseVisualStyleBackColor = true;
            this.btnBuscarNodo.Click += new System.EventHandler(this.btnBuscarNodo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vértice:";
            // 
            // btnDistancia
            // 
            this.btnDistancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistancia.Location = new System.Drawing.Point(80, 483);
            this.btnDistancia.Name = "btnDistancia";
            this.btnDistancia.Size = new System.Drawing.Size(84, 28);
            this.btnDistancia.TabIndex = 5;
            this.btnDistancia.Text = "Distancia";
            this.btnDistancia.UseVisualStyleBackColor = true;
            this.btnDistancia.Click += new System.EventHandler(this.btnDistancia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(642, 724);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Click derecho para crear un Nodo";
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(510, 39);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(0, 20);
            this.lblRespuesta.TabIndex = 7;
            // 
            // txtNodoBuscar
            // 
            this.txtNodoBuscar.Location = new System.Drawing.Point(65, 35);
            this.txtNodoBuscar.Name = "txtNodoBuscar";
            this.txtNodoBuscar.Size = new System.Drawing.Size(87, 21);
            this.txtNodoBuscar.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNombreEtiqueta);
            this.groupBox4.Controls.Add(this.btnEliminarEtiqueta);
            this.groupBox4.Controls.Add(this.cbListaEtiquetas);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnCrearEtiqueta);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(12, 374);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 85);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Crear y eliminar etiquetas";
            // 
            // btnEliminarEtiqueta
            // 
            this.btnEliminarEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarEtiqueta.Location = new System.Drawing.Point(258, 51);
            this.btnEliminarEtiqueta.Name = "btnEliminarEtiqueta";
            this.btnEliminarEtiqueta.Size = new System.Drawing.Size(67, 23);
            this.btnEliminarEtiqueta.TabIndex = 5;
            this.btnEliminarEtiqueta.Text = "Eliminar";
            this.btnEliminarEtiqueta.UseVisualStyleBackColor = true;
            // 
            // cbListaEtiquetas
            // 
            this.cbListaEtiquetas.FormattingEnabled = true;
            this.cbListaEtiquetas.Location = new System.Drawing.Point(121, 52);
            this.cbListaEtiquetas.Name = "cbListaEtiquetas";
            this.cbListaEtiquetas.Size = new System.Drawing.Size(131, 23);
            this.cbListaEtiquetas.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Lista etiquetas:";
            // 
            // btnCrearEtiqueta
            // 
            this.btnCrearEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearEtiqueta.Location = new System.Drawing.Point(258, 22);
            this.btnCrearEtiqueta.Name = "btnCrearEtiqueta";
            this.btnCrearEtiqueta.Size = new System.Drawing.Size(67, 23);
            this.btnCrearEtiqueta.TabIndex = 2;
            this.btnCrearEtiqueta.Text = "Crear";
            this.btnCrearEtiqueta.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nombre etiqueta:";
            // 
            // txtNombreEtiqueta
            // 
            this.txtNombreEtiqueta.Location = new System.Drawing.Point(121, 24);
            this.txtNombreEtiqueta.Name = "txtNombreEtiqueta";
            this.txtNombreEtiqueta.Size = new System.Drawing.Size(131, 21);
            this.txtNombreEtiqueta.TabIndex = 6;
            // 
            // FrmSimulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDistancia);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Pizarra);
            this.Name = "FrmSimulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de grafos";
            this.CMSCrearVertice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel Pizarra;
		private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem NuevoVerticeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminarArista;
        private System.Windows.Forms.ComboBox cbAristas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarVertice;
        private System.Windows.Forms.ComboBox cbVertices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRecorridoAnchura;
        private System.Windows.Forms.Button btnRecorridoProfundidad;
        private System.Windows.Forms.ComboBox cbNodoPartida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscarNodo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDistancia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.TextBox txtNodoBuscar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNombreEtiqueta;
        private System.Windows.Forms.Button btnEliminarEtiqueta;
        private System.Windows.Forms.ComboBox cbListaEtiquetas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCrearEtiqueta;
        private System.Windows.Forms.Label label7;
    }
}

