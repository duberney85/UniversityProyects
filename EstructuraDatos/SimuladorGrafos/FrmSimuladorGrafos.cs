using Core;
using SimuladorGrafos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
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
        /// <summary>
        /// Ventana para agregar las aristas
        /// </summary>
        private frmAgregarArista _ventanaArista;
        /// <summary>
        /// Lista de nodos utilizados en una ruta
        /// </summary>
        private List<Vertice> _nodosRuta;
        /// <summary>
        /// Lista de nodos ordenados apartir del nodo origen
        /// </summary>
        private List<Vertice> _nodosOrdenados;
        /// <summary>
        /// guarda el numero de nodos del grafo
        /// </summary>
        private int _numeroNodos = 0;
        private bool _buscarRuta = false, _nuevoVertice = false, _nuevaArista = false;
        /// <summary>
        /// Variables que controlan los recorridos
        /// </summary>
        private bool _profundidad = false, _anchura = false, _nodoEncontrado = false;
        /// <summary>
        /// Cola utilizada para recorrer el grafo en anchura
        /// </summary>
        private Queue _colaAnchura;
        /// <summary>
        /// Nombre de los nodos a ubicar
        /// </summary>
        private string _nombreNodoOrigen, _nombreNodoDestino;
        /// <summary>
        /// Distancia entre nodo origen y destino
        /// </summary>
        private int _distancia = 0;
        private int _totalNodos;
        /// <summary>
        /// Vector padres nodo
        /// </summary>
        int[] _nodoPadre;
        /// <summary>
        /// Vector para comparar los nodos ya visitados
        /// </summary>
        bool[] _visitados;


        public FrmSimulador()
        {
            InitializeComponent();
            _grafo = new Grafo();
            _nuevoNodo = null;
            _varControl = 0;
            _ventanaVertice = new FrmAgregarVertice();
            _ventanaArista = new frmAgregarArista();
            _nodosRuta = new List<Vertice>();
            _nodosOrdenados = new List<Vertice>();
            _colaAnchura = new Queue();
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }

        /// <summary>
        /// Calcula las matrices iniciales de distancia y nodos
        /// </summary>
        private void calcularMatricesIniciales()
        {
            _nodosRuta = new List<Vertice>();
            _totalNodos = _grafo.ListaNodos.Count;
            _nodoPadre = new int[_totalNodos];
            _visitados = new bool[_totalNodos];
            // Calcular la matriz inicial de distancia
            for (int i = 0; i < _totalNodos; i++)
            {
                List<int> filaDistancia = new List<int>();
                for (int k = 0; k < _totalNodos; k++)
                {
                    // si el origen = al destino
                    if (i == k)
                    {
                        filaDistancia.Add(0);
                    }
                    else
                    {
                        // Buscar si existe la relacion i,k si existe se obtiene la distancia 
                        int distancia = -1;
                        for (int j = 0; j < _grafo.ListaNodos[i].ListaAdyacencia.Count; j++)
                        {
                            if (_grafo.ListaNodos[i].ListaAdyacencia[j].VerticeDestino ==
                                _grafo.ListaNodos[k])
                            {
                                distancia = _grafo.ListaNodos[i].ListaAdyacencia[j].Peso;
                            }
                        }
                        filaDistancia.Add(distancia);
                    }
                }
            }
        }

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                _grafo.DibujarGrafo(e.Graphics);
                if (_nuevoVertice)
                {
                    cbVertices.Items.Clear();
                    cbVertices.SelectedIndex = -1;
                    cbNodoPartida.Items.Clear();
                    cbNodoPartida.SelectedIndex = -1;
                    foreach (Vertice nodo in _grafo.ListaNodos)
                    {
                        cbVertices.Items.Add(nodo.Nombre);
                        cbNodoPartida.Items.Add(nodo.Nombre);
                    }
                    _nuevoVertice = false;
                }
                if (_nuevaArista)
                {
                    cbAristas.Items.Clear();
                    cbAristas.SelectedIndex = -1;
                    foreach (Vertice nodo in _grafo.ListaNodos)
                    {
                        foreach (Arista arista in nodo.ListaAdyacencia)
                        {
                            cbAristas.Items.Add(
                                string.Format(
                                    "({0},{1}) peso: {2}",
                                    nodo.Nombre,
                                    arista.VerticeDestino.Nombre,
                                    arista.Peso
                                 )
                            );
                        }
                    }
                    _nuevaArista = false;
                }
                if (_buscarRuta)
                {
                    foreach (Vertice nodo in _nodosRuta)
                    {
                        nodo.Colorear(e.Graphics);
                        Thread.Sleep(1000);
                        nodo.DibujarVertice(e.Graphics);
                    }
                    _buscarRuta = false;
                }
                if (_profundidad)
                {
                    // Ordenar nodos desde el que indica el usuario
                    OrdenarNodos();
                    foreach (Vertice nodo in _nodosOrdenados)
                    {
                        if (!nodo.Visitado)
                        {
                            RecorridoProfundidad(nodo, e.Graphics);
                        }
                    }
                    _profundidad = false;
                    // Reestablecer los valores
                    foreach (Vertice nodo in _grafo.ListaNodos)
                    {
                        nodo.Visitado = false;
                    }
                }
                if (_anchura)
                {
                    _distancia = 0;
                    // Ordenar los nodos desde el que indica el usuario
                    _colaAnchura = new Queue();
                    OrdenarNodos();
                    foreach (Vertice nodo in _nodosOrdenados)
                    {
                        if (!nodo.Visitado && !_nodoEncontrado)
                        {
                            RecorridoAnchura(nodo, e.Graphics, _nombreNodoDestino);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Ordenar los nodos del grafo
        /// </summary>
        private void OrdenarNodos()
        {
            _nodosOrdenados = new List<Vertice>();
            bool est = false;
            foreach (Vertice nodo in _grafo.ListaNodos)
            {
                if (nodo.Nombre == _nombreNodoOrigen)
                {
                    _nodosOrdenados.Add(nodo);
                    est = true;
                }
                else if (est)
                {
                    _nodosOrdenados.Add(nodo);
                }
            }
            foreach (Vertice nodo in _grafo.ListaNodos)
            {
                if (nodo.Nombre == _nombreNodoOrigen)
                {
                    est = false;
                    break;
                }
                else if (est)
                {
                    _nodosOrdenados.Add(nodo);
                }
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
                // Dibujar arista
                case 1:
                    {
                        if ((_nodoDestino = _grafo.DetectarPunto(e.Location)) != null &&
                            _nodoOrigen != _nodoDestino)
                        {
                            _ventanaArista.Visible = false;
                            _ventanaArista.Control = false;
                            _ventanaArista.ShowDialog();
                            if (_ventanaArista.Control)
                            {
                                // Se crear la arista
                                if (_grafo.AgregarArista(_nodoOrigen, _nodoDestino))
                                {
                                    int distancia = 0;
                                    _nodoOrigen.ListaAdyacencia.Find(
                                        x => x.VerticeDestino == _nodoDestino).Peso = distancia;
                                }
                                _nuevaArista = true;
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
                // Creando nuevo nodo
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
                        // Dibujar arista
                        AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                        bigArrow.BaseCap = LineCap.Triangle;

                        this.Pizarra.Refresh();
                        this.Pizarra.CreateGraphics().DrawLine(
                            new Pen(Brushes.Black, 2)
                            {
                                CustomEndCap = bigArrow
                            },
                            _nodoOrigen.Posicion, e.Location);
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
                    _ventanaVertice.ShowDialog();
                    _numeroNodos = _grafo.ListaNodos.Count;
                    if (_ventanaVertice.Control)
                    {
                        if (_grafo.BuscarVertice(_ventanaVertice.Dato) == null)
                        {
                            _grafo.AgregarVertice(_nuevoNodo);
                            _nuevoNodo.Nombre = _ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            this.lblRespuesta.Text = string.Format("El nodo {0} ya existe en el grafo", _ventanaVertice.Dato);
                            this.lblRespuesta.ForeColor = Color.Red;
                        }
                    }
                    _nuevoNodo = null;
                    _nuevoVertice = true;
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

        private void btnEliminarVertice_Click(object sender, EventArgs e)
        {
            if (cbVertices.SelectedIndex > -1)
            {
                foreach (Vertice nodo in _grafo.ListaNodos)
                {
                    if (nodo.Nombre == cbVertices.SelectedItem.ToString())
                    {
                        _grafo.ListaNodos.Remove(nodo);
                        //Borrar aristas que tenga el nodo eliminado
                        nodo.ListaAdyacencia = new List<Arista>();
                        break;
                    }
                }
                foreach (Vertice nodo in _grafo.ListaNodos)
                {
                    foreach (Arista arista in nodo.ListaAdyacencia)
                    {
                        if (arista.VerticeDestino.Nombre == cbVertices.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arista);
                            break;
                        }
                    }
                }
                _nuevaArista = true;
                _nuevoVertice = true;
                cbVertices.SelectedIndex = -1;
                this.Pizarra.Refresh();
            }
            else
            {
                this.lblRespuesta.Text = "Seleccione un nodo";
                this.lblRespuesta.ForeColor = Color.Red;
            }
        }

        private void btnEliminarArista_Click(object sender, EventArgs e)
        {
            if (cbAristas.SelectedIndex > -1)
            {
                foreach (Vertice nodo in _grafo.ListaNodos)
                {
                    foreach (Arista arista in nodo.ListaAdyacencia)
                    {
                        if (string.Format("({0},{1}) peso: {2}",
                            nodo.Nombre, arista.VerticeDestino.Nombre, arista.Peso) ==
                            cbAristas.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arista);
                        }
                    }
                }
                _nuevoVertice = true;
                _nuevaArista = true;
                cbAristas.SelectedIndex = -1;
                this.Pizarra.Refresh();
            }
            else
            {
                lblRespuesta.Text = "Seleccione una arista";
                lblRespuesta.ForeColor = Color.Red;
            }
        }

        private void btnRecorridoProfundidad_Click(object sender, EventArgs e)
        {
            if (cbNodoPartida.SelectedIndex > -1)
            {
                _profundidad = true;
                _nombreNodoOrigen = cbNodoPartida.SelectedItem.ToString();
                this.Pizarra.Refresh();
                cbNodoPartida.SelectedIndex = -1;
            }
            else
            {
                lblRespuesta.Text = "Seleccione un nodo de partida";
                lblRespuesta.ForeColor = Color.Red;
            }
        }

        private void btnRecorridoAnchura_Click(object sender, EventArgs e)
        {
            if (cbNodoPartida.SelectedIndex > -1)
            {
                _anchura = true;
                _nombreNodoOrigen = cbNodoPartida.SelectedItem.ToString();
                this.Pizarra.Refresh();
                cbNodoPartida.SelectedIndex = -1;
            }
            else
            {
                lblRespuesta.Text = "Seleccione un nodo de partida";
                lblRespuesta.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Recorrido del grafo en profundidad 
        /// </summary>
        /// <param name="nodo">Nodo donde se inicia el recorrido</param>
        /// <param name="g">Grafico del grafo</param>
        private void RecorridoProfundidad(Vertice nodo, Graphics g)
        {
            nodo.Visitado = true;
            nodo.Colorear(g);
            Thread.Sleep(1000);
            nodo.DibujarVertice(g);
            foreach (Arista aristaAdyacente in nodo.ListaAdyacencia)
            {
                if (!aristaAdyacente.VerticeDestino.Visitado)
                {
                    RecorridoProfundidad(aristaAdyacente.VerticeDestino, g);
                }
            }
        }

        /// <summary>
        /// Recorre el grafo en anchura
        /// </summary>
        /// <param name="nodo">Nodo donde inicia el recorrido</param>
        /// <param name="g">Grafico del grafo</param>
        /// <param name="nombreDestino">Nombre del nodo destino</param>
        private void RecorridoAnchura(Vertice nodo, Graphics g, string nombreDestino)
        {
            nodo.Visitado = true;
            _colaAnchura.Enqueue(nodo);
            nodo.Colorear(g);
            Thread.Sleep(1000);
            nodo.DibujarVertice(g);
            if (nodo.Nombre == nombreDestino)
            {
                _nodoEncontrado = true;
                return;
            }
            while (_colaAnchura.Count > 0)
            {
                Vertice nodoAux = (Vertice)_colaAnchura.Dequeue();
                foreach (Arista arista in nodoAux.ListaAdyacencia)
                {
                    if (!arista.VerticeDestino.Visitado)
                    {
                        if (!_nodoEncontrado)
                        {
                            arista.VerticeDestino.Visitado = true;
                            arista.VerticeDestino.Colorear(g);
                            Thread.Sleep(1000);
                            arista.VerticeDestino.DibujarVertice(g);
                            if (!string.IsNullOrEmpty(nombreDestino))
                            {
                                _distancia += arista.Peso;
                            }
                            _colaAnchura.Enqueue(arista.VerticeDestino);

                            if (arista.VerticeDestino.Nombre == nombreDestino)
                            {
                                _nodoEncontrado = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void btnBuscarNodo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNodoBuscar.Text.Trim()))
            {
                if (_grafo.BuscarVertice(txtNodoBuscar.Text) != null)
                {
                    lblRespuesta.Text = string.Format("Si se encuentra el vértice {0}", txtNodoBuscar.Text);
                    lblRespuesta.ForeColor = Color.Blue;
                }
                else
                {
                    lblRespuesta.Text = string.Format("No se encuentra el vértice {0}", txtNodoBuscar.Text);
                    lblRespuesta.ForeColor = Color.Red;
                }
            }
        }
    }
}
