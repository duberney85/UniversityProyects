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
        public string Nombre;
        /// <summary>
        /// Lista de adyacencia de los nodos
        /// </summary>
        public List<Arista> ListaAdyacencia;
        readonly Dictionary<string, short> _banderas;
        readonly Dictionary<string, short> _banderasPredeterminado;
        #endregion Atributos

        #region Propiedades
        //Tamaño del nodo
        private static int size = 35;
        private int radio;
        private Color colorVertice;
        /// <summary>
        /// Color definido para el nodo
        /// </summary>
        public Color ColorVertice
        {
            get { return colorVertice; }
            set { colorVertice = value; }
        }

        private Color colorFuente;
        /// <summary>
        /// Color definido para la fuente del nombre del nodo
        /// </summary>
        public Color ColorFuente
        {
            get { return colorFuente; }
            set { colorFuente = value; }
        }

        private Point posicion;
        /// <summary>
        /// Donde se dibujara el nodo
        /// </summary>
        public Point Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        private Size dimensiones;
        /// <summary>
        /// Dimensiones algo y ancho del nodo
        /// </summary>
        public Size Dimensiones
        {
            get { return dimensiones; }
            set
            {
                radio = value.Width / 2;
                dimensiones = value;
            }
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
            Nombre = nombre;
            ListaAdyacencia = new List<Arista>();
            _banderas = new Dictionary<string, short>();
            _banderasPredeterminado = new Dictionary<string, short>();
            ColorFuente = Color.Green;
            Dimensiones = new Size(size, size);
            ColorFuente = Color.White;
        }

        /// <summary>
        /// Dibuja un vertice o nodo
        /// </summary>
        /// <param name="g">Grafico que se va agregar</param>
        public void DibujarVertice(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(ColorVertice);

            // Se define donde se va dibujar el nodo 
            Rectangle areaNodo = new Rectangle(
                Posicion.X - radio,
                Posicion.Y - radio,
                Dimensiones.Width, Dimensiones.Height);

            // Rellena el interior de una elipse de finida por un rectangulo
            g.FillEllipse(solidBrush, areaNodo);

            StringFormat formatoTexto = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Dibuja la cadena de texto especificada en la ubicación especificada
            g.DrawString(
                Nombre,
                new Font("Times New Roman", 14),
                new SolidBrush(ColorFuente),
                Posicion.X,
                Posicion.Y,
                formatoTexto);

            // Dibuja una elipse especificada por una estructura Rectangle
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);

            // Libera el recurso utilizado
            g.Dispose();
        }

        /// <summary>
        /// Dibuja una arista o arco
        /// </summary>
        /// <param name="g"></param>
        public void DibujarArista(Graphics g)
        {
            float distancia;
            int diferenciaX, diferenciaY;

            foreach (Arista arista in ListaAdyacencia)
            {
                diferenciaX = Posicion.X - arista.VerticeDestino.Posicion.X;
                diferenciaY = Posicion.Y - arista.VerticeDestino.Posicion.Y;
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
                Posicion,
                new Point(
                    arista.VerticeDestino.Posicion.X + (int)(radio * diferenciaX / distancia),
                    arista.VerticeDestino.Posicion.Y + (int)(radio * diferenciaY / distancia))
                );

                g.DrawString(
                    arista.Peso.ToString(),
                    new Font("Times New Roman", 12),
                    new SolidBrush(Color.White),
                    Posicion.X - (int)((diferenciaX / 3)),
                    Posicion.Y - (int)((diferenciaY / 3)),
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
                Posicion.X - Dimensiones.Width / 2,
                Posicion.Y - Dimensiones.Height / 2,
                Dimensiones.Width,
                Dimensiones.Height));
            bool esVisible = posicion.IsVisible(punto);
            posicion.Dispose();

            return esVisible;
        }

        public override string ToString()
        {
            return Nombre;
        }


    }
}
