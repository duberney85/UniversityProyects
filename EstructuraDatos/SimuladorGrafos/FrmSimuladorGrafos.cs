using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador
{
	public partial class FrmSimulador : Form
	{
        /// <summary>
        /// Instancia de la clase grafo
        /// </summary>
        private Grafo _grafo;
        /// <summary>
        /// Instancia de la clase Vertice para crear un nuevo nodo
        /// </summary>
        private Vertice _nuevoNodo;
        /// <summary>
        /// Instacia de la clase Vertice para crear el nodo origin
        /// </summary>
        private Vertice _nodoOrigen;
        /// <summary>
        /// Instacia de la clase Vertice para crear el nodo destino
        /// </summary>
        private Vertice _nodoDestiono;
        /// <summary>
        /// Variable para determinar el estado en la pizarra
        /// 0: Sin accion
        /// 1: Dibujando
        /// 2: Nuevo vertice
        /// </summary>
        private int _varControl = 0;
        /// <summary>
        /// Ventana para agregar los vertices
        /// </summary>
        private Vertice _ventanaVertice;

		public FrmSimulador()
		{
			InitializeComponent();
            _grafo = new Grafo();
            _nuevoNodo = null;
            _varControl = 0;
            _ventanaVertice = new Vertice();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | 
                ControlStyles.OptimizedDoubleBuffer, 
                true);
		}

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                _grafo.DibujarGrafo(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// El evento "MouseLeve" ocurre cuando el mouse ya no se encuentra en la parte visible de la pizarra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            this.Pizarra.Refresh();
        }

        private void NuevoVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _nuevoNodo = new Vertice();
            _varControl = 2;
        }
    }
}
