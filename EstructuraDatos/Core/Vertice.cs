using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Core
{
    /// <summary>
    /// Clase que contiene la definicion de un vertice o nodo
    /// </summary>
    public class Vertice
    {
        #region Atributos
        private string _nombre;
        private readonly Dictionary<string, short> _banderas;
        private readonly Dictionary<string, short> _banderasPredeterminado;
        private List<Arista> _listaAdyacencia;
        private static int _size = 35;
        private int _radio;
        private Color _colorVertice;
        private Point _posicion;
        private Size _dimensiones;
        private Color _colorFuente;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Color definido para el nodo
        /// </summary>
        public Color ColorVertice
        {
            get { return _colorVertice; }
            set { _colorVertice = value; }
        }

        /// <summary>
        /// Color definido para la fuente del nombre del nodo
        /// </summary>
        public Color ColorFuente
        {
            get { return _colorFuente; }
            set { _colorFuente = value; }
        }

        /// <summary>
        /// Donde se dibujara el nodo
        /// </summary>
        public Point Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        /// <summary>
        /// Dimensiones algo y ancho del nodo
        /// </summary>
        public Size Dimensiones
        {
            get { return _dimensiones; }
            set
            {
                _radio = value.Width / 2;
                _dimensiones = value;
            }
        }
        /// <summary>
        /// Nombre del nodo
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Lista de adyacencia de los nodos
        /// </summary>
        public List<Arista> ListaAdyacencia
        {
            get { return _listaAdyacencia; }
            set { _listaAdyacencia = value; }
        }

        private int _distanciaNodo;
        private bool _visitado;
        private Vertice _padre;
        private bool _pesoAsignado;

        /// <summary>
        /// Variable que se usa en el algoritmo de Dijkstra
        /// </summary>
        public bool PesoAsignado
        {
            get { return _pesoAsignado; }
            set { _pesoAsignado = value; }
        }

        /// <summary>
        /// Indentifica el nodo antecesor en los recorridos
        /// </summary>
        public Vertice Padre
        {
            get { return _padre; }
            set { _padre = value; }
        }

        /// <summary>
        /// Marca como visitado el nodo en un recorrido
        /// </summary>
        public bool Visitado
        {
            get { return _visitado; }
            set { _visitado = value; }
        }

        /// <summary>
        /// Guarda la distancia que hay entre el nodo inicio en el algoritmo de Dijkstra
        /// </summary>
        public int DistanciaNodo
        {
            get { return _distanciaNodo; }
            set { _distanciaNodo = value; }
        }
        #endregion Propiedades

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Vertice()
            : this("")
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del nodo</param>
        public Vertice(string nombre)
        {
            _nombre = nombre;
            _listaAdyacencia = new List<Arista>();
            _banderas = new Dictionary<string, short>();
            _banderasPredeterminado = new Dictionary<string, short>();
            _colorVertice = Color.FromArgb(51, 204, 255);
            _colorFuente = Color.Black;
            _dimensiones = new Size(_size, _size);
            _visitado = false;
        }

        /// <summary>
        /// Dibuja un vertice o nodo
        /// </summary>
        /// <param name="g">Grafico que se va agregar</param>
        public void DibujarVertice(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(_colorVertice);

            // Se define donde se va dibujar el nodo 
            Rectangle areaNodo = new Rectangle(
                _posicion.X - _radio,
                _posicion.Y - _radio,
                _dimensiones.Width, _dimensiones.Height);

            // Rellena el interior de una elipse de finida por un rectangulo
            g.FillEllipse(solidBrush, areaNodo);

            StringFormat formatoTexto = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Dibuja la cadena de texto especificada en la ubicación especificada
            g.DrawString(
                _nombre,
                new Font("Times New Roman", 14),
                new SolidBrush(_colorFuente),
                _posicion.X,
                _posicion.Y,
                formatoTexto);

            // Dibuja una elipse especificada por una estructura Rectangle
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);

            // Libera el recurso utilizado
            solidBrush.Dispose();
        }

        /// <summary>
        /// Dibuja una arista o arco
        /// </summary>
        /// <param name="g"></param>
        public void DibujarArista(Graphics g)
        {
            float distancia;
            int diferenciaX, diferenciaY;

            foreach (Arista arista in _listaAdyacencia)
            {
                diferenciaX = _posicion.X - arista.VerticeDestino.Posicion.X;
                diferenciaY = _posicion.Y - arista.VerticeDestino.Posicion.Y;
                distancia = (float)Math.Sqrt((diferenciaX * diferenciaX + diferenciaY * diferenciaY));

                // Representa un extremo de línea ajustable en forma de flecha
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true)
                {
                    BaseCap = LineCap.Triangle
                };

                // Dibuja una línea que conecta dos estructuras
                g.DrawLine(new Pen(new SolidBrush(arista.ColorArista), arista.GrosorFlecha)
                {
                    CustomEndCap = bigArrow,
                    Alignment = PenAlignment.Center
                },
                _posicion,
                new Point(
                    arista.VerticeDestino.Posicion.X + (int)(_radio * diferenciaX / distancia),
                    arista.VerticeDestino.Posicion.Y + (int)(_radio * diferenciaY / distancia))
                );

                g.DrawString(
                    arista.Peso.ToString(),
                    new Font("Times New Roman", 12),
                    new SolidBrush(Color.White),
                    _posicion.X - (int)((diferenciaX / 3)),
                    _posicion.Y - (int)((diferenciaY / 3)),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    }
                );
            }
        }

        /// <summary>
        /// Detecta la posicion en el panel donde se dibujara el nodo
        /// </summary>
        /// <param name="punto">Punto donde esta ubicado el mouse</param>
        /// <returns></returns>
        public bool DetectarPunto(Point punto)
        {
            GraphicsPath posicion = new GraphicsPath();
            posicion.AddEllipse(new Rectangle(
                _posicion.X - _dimensiones.Width / 2,
                _posicion.Y - _dimensiones.Height / 2,
                _dimensiones.Width,
                _dimensiones.Height));
            bool esVisible = posicion.IsVisible(punto);
            posicion.Dispose();

            return esVisible;
        }

        public override string ToString()
        {
            return _nombre;
        }

        public void Colorear(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(Color.GreenYellow);
            // Definir donde dibujar el nodo
            Rectangle areaNodo = new Rectangle(
                _posicion.X - _radio,
                _posicion.Y - _radio,
                _dimensiones.Width,
                _dimensiones.Height);
            g.FillEllipse(solidBrush, areaNodo);
            g.DrawString(
                _nombre,
                new Font("Times New Roman", 14),
                new SolidBrush(_colorFuente),
                _posicion.X,
                _posicion.Y,
                new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);
            g.Dispose();
        }


    }
}
