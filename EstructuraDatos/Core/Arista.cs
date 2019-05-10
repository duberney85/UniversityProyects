using System.Drawing;

namespace Core
{
    /// <summary>
    /// Clase que contine la definicion de una arista o arco
    /// </summary>
    public class Arista
    {
        private Vertice _verticeDestino;
        private Color _colorArista;
        private float _grosorFlecha;
        private int _peso;

        /// <summary>
        /// Vertice destino
        /// </summary>
        public Vertice VerticeDestino
        {
            get { return _verticeDestino; }
            set { _verticeDestino = value; }
        }

        /// <summary>
        /// Color de la arista
        /// </summary>
        public Color ColorArista
        {
            get { return _colorArista; }
            set { _colorArista = value; }
        }

        /// <summary>
        /// Grosor de la fecha de la arista
        /// </summary>
        public float GrosorFlecha
        {
            get { return _grosorFlecha; }
            set { _grosorFlecha = value; }
        }

        /// <summary>
        /// Valor de cada arista
        /// </summary>
        public int Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="destino"></param>
        public Arista(Vertice destino) :
            this(destino, 1)
        {
            _verticeDestino = destino;
        }
        /// <summary>
        /// Constructor que crea una arista al nodo destino
        /// </summary>
        /// <param name="destino">Nodo destino</param>
        /// <param name="peso">Peso de la arista</param>
        public Arista(Vertice destino, int peso)
        {
            _verticeDestino = destino;
            _peso = peso;
            _grosorFlecha = 2;
            _colorArista = Color.Red;
        }
    }
}