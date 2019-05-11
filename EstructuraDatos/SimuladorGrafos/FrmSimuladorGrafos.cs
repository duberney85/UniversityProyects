using Core;
using SimuladorGrafos;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        /// Instacia de la clase Vertice para crear el nodo origen
        /// </summary>
        private Vertice _nodoOrigen;
        /// <summary>
        /// Instacia de la clase Vertice para crear el nodo destino
        /// </summary>
        private Vertice _nodoDestino;
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
        private FrmAgregarVertice _ventanaVertice;

        public FrmSimulador()
        {
            InitializeComponent();
            _grafo = new Grafo();
            _nuevoNodo = null;
            _varControl = 0;
            _ventanaVertice = new FrmAgregarVertice();

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

        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_varControl)
            {
                case 1:
                    {
                        if ((_nodoDestino = _grafo.DetectarPunto(e.Location)) != null &&
                            _nodoOrigen != _nodoDestino)
                        {
                            // Se crear la arista
                            if (_grafo.AgregarArista(_nodoOrigen, _nodoDestino))
                            {
                                int distancia = 0;
                                _nodoOrigen.ListaAdyacencia.Find(
                                    x => x.VerticeDestino == _nodoDestino).Peso = distancia;
                            }
                        }
                        _varControl = 0;
                        _nodoOrigen = null;
                        _nodoDestino = null;

                        this.Pizarra.Refresh();
                        break;
                    }
                default:
                    break;
            }
        }

        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch (_varControl)
            {
                // Crear nuevo nodo
                case 2:
                    {
                        if (_nuevoNodo != null)
                        {
                            int posX = e.Location.X;
                            int posY = e.Location.Y;

                            if (posX < _nuevoNodo.Dimensiones.Width / 2)
                            {
                                posX = _nuevoNodo.Dimensiones.Width / 2;
                            }
                            else if (posX > this.Pizarra.Size.Width - _nuevoNodo.Dimensiones.Width / 2)
                            {
                                posX = this.Pizarra.Size.Width - _nuevoNodo.Dimensiones.Width / 2;
                            }

                            if (posY < _nuevoNodo.Dimensiones.Height / 2)
                            {
                                posY = _nuevoNodo.Dimensiones.Height / 2;
                            }
                            else if (posY > this.Pizarra.Size.Height - _nuevoNodo.Dimensiones.Width / 2)
                            {
                                posY = this.Pizarra.Size.Height - _nuevoNodo.Dimensiones.Width / 2;
                            }

                            _nuevoNodo.Posicion = new Point(posX, posY);
                            this.Pizarra.Refresh();
                            _nuevoNodo.DibujarVertice(this.Pizarra.CreateGraphics());
                        }
                        break;
                    }
                // Crear arista
                case 1:
                    {
                        // Dibujar arco
                        AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                        bigArrow.BaseCap = LineCap.Triangle;

                        this.Pizarra.Refresh();
                        this.Pizarra.CreateGraphics().DrawLine(
                            new Pen(Brushes.Black, 2)
                            {
                                CustomEndCap = bigArrow
                            }, _nodoOrigen.Posicion, e.Location);
                        break;
                    }
                default:
                    break;
            }
        }

        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            // Cuando se presiona el boton izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                if ((_nodoOrigen = _grafo.DetectarPunto(e.Location)) != null)
                {
                    // se cambia a 1 para indicar que se esta dibujando una arista
                    _varControl = 1;
                }

                if (_nuevoNodo != null && _nodoOrigen == null)
                {
                    _ventanaVertice.Visible = false;
                    _ventanaVertice.Control = false;
                    _grafo.AgregarVertice(_nuevoNodo);
                    _ventanaVertice.ShowDialog();

                    if (_ventanaVertice.Control)
                    {
                        if (_grafo.BuscarVertice(_ventanaVertice.txtVertice.Text) == null)
                        {
                            _nuevoNodo.Nombre = _ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            MessageBox.Show(string.Format(
                                "El Nodo {0} ya existe en el grafo",
                                _ventanaVertice.txtVertice.Text),
                                "Error nuevo Nodo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }
                    _nuevoNodo = null;
                    _varControl = 0;

                    this.Pizarra.Refresh();
                }
            }

            // Cuando se presiona el boton derecho del mouse
            if (e.Button == MouseButtons.Right)
            {
                if (_varControl == 0)
                {
                    if ((_nodoOrigen = _grafo.DetectarPunto(e.Location)) != null)
                    {
                        this.CMSCrearVertice.Text = string.Format("Nodo {0}", _nodoOrigen.Nombre);
                    }
                    else
                    {
                        this.Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                    }
                }
            }
        }
    }
}
