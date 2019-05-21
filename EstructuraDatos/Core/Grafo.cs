using System;
using System.Collections.Generic;
using System.Drawing;

namespace Core
{
    public class Grafo
    {
        private readonly int[,] _matrizAdyacencia;
        private readonly int[] _indegree;
        private readonly int _nodos;
        private List<Vertice> _listaNodos;


        /// <summary>
        /// Lista de nodos del grafo
        /// </summary>
        public List<Vertice> ListaNodos
        {
            get { return _listaNodos; }
            set { _listaNodos = value; }
        }

        /// <summary>
        /// Crea un grafo para manejarlo con una lista de adyacencia
        /// </summary>
        public Grafo()
        {
            ListaNodos = new List<Vertice>();
        }

        /// <summary>
        /// Constructor para crear un grafo con matriz de adyacencia
        /// </summary>
        /// <param name="totalNodos"></param>
		public Grafo(int totalNodos)
        {
            _nodos = totalNodos;

            // instancia de matriz de adyacencia 
            _matrizAdyacencia = new int[_nodos, _nodos];

            // instancia del arreglo de indegree
            _indegree = new int[_nodos];
        }

        #region Metodos para trabajar el grafo con matriz de adyacencia

        /// <summary>
        /// Adiciona una arista entre dos nodos 
        /// </summary>
        /// <param name="nodoInicio">posicion inicial</param>
        /// <param name="nodoFin">posicion final</param>
        public void AdicionarArista(int nodoInicio, int nodoFin)
        {
            _matrizAdyacencia[nodoInicio, nodoFin] = 1;
        }

        /// <summary>
        /// Adiciona una arista entre dos nodos por medio de su peso
        /// </summary>
        /// <param name="nodoInicio"></param>
        /// <param name="nodoFin"></param>
        /// <param name="peso"></param>
        public void AdicionarArista(int nodoInicio, int nodoFin, int peso)
        {
            _matrizAdyacencia[nodoInicio, nodoFin] = peso;
        }

        /// <summary>
        /// Muestra la matriz de adyacencia en pantalla
        /// </summary>
        public void MostrarAdyacencia()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            for (int n = 0; n < _nodos; n++)
            {
                Console.Write("   {0}", n);
            }

            // Se agrega nueva linea
            Console.WriteLine();

            for (int n = 0; n < _nodos; n++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(n);
                for (int m = 0; m < _nodos; m++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("   {0}", _matrizAdyacencia[n, m]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Muestra el peso almacenado que tiene una arista segun las coordenadas dadas de la matriz de adyacencia
        /// </summary>
        /// <param name="fila">Posicion de la fila</param>
        /// <param name="columna">Posicion de la columna</param>
        /// <returns></returns>
        public int ObtenerAdyacencia(int fila, int columna)
        {
            return _matrizAdyacencia[fila, columna];
        }

        /// <summary>
        /// Calcula el indegree de los nodos 
        /// </summary>
        public void CalcularIndegree()
        {
            for (int n = 0; n < _nodos; n++)
            {
                for (int m = 0; m < _nodos; m++)
                {
                    if (_matrizAdyacencia[m, n] == 1)
                    {
                        _indegree[n]++;
                    }
                }
            }
        }

        /// <summary>
        /// Muestra el Indegree de todos los nodos
        /// </summary>
        public void MostrarIndegree()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int n = 0; n < _nodos; n++)
            {
                Console.WriteLine("Nodo: {0}, {1}", n, _indegree[n]);
            }
        }

        /// <summary>
        /// Encontrar nodo con indegree cero
        /// </summary>
        /// <returns>devuelve el index del nodo que tiene un indegree cero, si no encuentra ninguno devuelve -1</returns>
        public int EncontrarIndegreeCero()
        {
            bool encontrado = false;
            int n = 0;
            for (n = 0; n < _nodos; n++)
            {
                if (_indegree[n] == 0)
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                return n;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Disminuye un indigree de todos
        /// </summary>
        /// <param name="nodo"></param>
        public void DecrementaIndigree(int nodo)
        {
            _indegree[nodo] = -1;

            for (int n = 0; n < _nodos; n++)
            {
                if (_matrizAdyacencia[nodo, n] == 1)
                {
                    _indegree[n]--;
                }
            }
        }
        #endregion Metodos para trabajar el grafo con matriz de adyacencia

        #region Metodos para trabajar el grafo con una lista de adyacencia
        /// <summary>
        /// Crea un nodo apartir de su nombre y lo agrega a la lista de nodos
        /// </summary>
        /// <param name="nombre">Nombre del nodo a agregar</param>
        /// <returns>Nodo creado</returns>
        public Vertice AgregarVertice(string nombre)
        {
            Vertice nuevoNodo = new Vertice(nombre);
            ListaNodos.Add(nuevoNodo);
            return nuevoNodo;
        }

        /// <summary>
        /// Agrega un nodo a la lista de nodos
        /// </summary>
        /// <param name="nuevoNodo"></param>
        public void AgregarVertice(Vertice nuevoNodo)
        {
            ListaNodos.Add(nuevoNodo);
        }

        /// <summary>
        /// Busca un nodo por su nombre en la lista de nodos 
        /// </summary>
        /// <param name="valor">Nombre del nodo a buscar</param>
        /// <returns>Nodo encontrado</returns>
        public Vertice BuscarVertice(string valor)
        {
            return ListaNodos.Find(x => x.Nombre == valor);
        }

        /// <summary>
        /// Une dos nodos por medio de una arista(arco)
        /// </summary>
        /// <param name="nombreOrigen">Nombre del nodo origen</param>
        /// <param name="nombreDestino">Nombre del nodo destino</param>
        /// <param name="peso">Peso de la arista</param>
        /// <returns>True si la arista se agregó correctamente, false si no se agregó</returns>
        public bool AgregarArista(string nombreOrigen, string nombreDestino, int peso = 1)
        {
            Vertice nodoOrigen, nodoDestino;

            if ((nodoOrigen = ListaNodos.Find(x => x.Nombre == nombreOrigen)) == null)
            {
                throw new Exception(string.Format("El nodo {0} no existe dentro del grafo", nombreOrigen));
            }

            if ((nodoDestino = ListaNodos.Find(x => x.Nombre == nombreDestino)) == null)
            {
                throw new Exception(string.Format("El nodo {0} no existe dentro del grafo", nombreDestino));
            }

            return AgregarArista(nodoOrigen, nodoDestino, peso);
        }

        /// <summary>
        /// Crea la arista apartir de los nodos origen y destino y los agrega a la lista adyacente
        /// </summary>
        /// <param name="nodoOrigen">Nodo origen</param>
        /// <param name="nodoDestion">Nodo destino</param>
        /// <param name="peso">Peso de la arista</param>
        /// <returns>True si adicionó, False si no se</returns>
        public bool AgregarArista(Vertice nodoOrigen, Vertice nodoDestion, int peso = 1)
        {
            if (nodoOrigen.ListaAdyacencia.Find(x => x.VerticeDestino == nodoOrigen) == null)
            {
                nodoOrigen.ListaAdyacencia.Add(new Arista(nodoDestion, peso));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Metodo para dibujar un grafo
        /// </summary>
        /// <param name="g">Grafico a dibujar</param>
        public void DibujarGrafo(Graphics g)
        {
            // Dibujar las aristas
            foreach (Vertice nodo in ListaNodos)
            {
                nodo.DibujarArista(g);
            }

            // Dibujar los vertices o nodos
            foreach (Vertice nodo in ListaNodos)
            {
                nodo.DibujarVertice(g);
            }
        }

        /// <summary>
        /// Metodo para detectar si se ha posicionado sobre algun nodo y lo devuelve
        /// </summary>
        /// <returns>Nodo seleccionado</returns>
        public Vertice DetectarPunto(Point posicionMouse)
        {
            foreach (Vertice nodo in ListaNodos)
            {
                if (nodo.DetectarPunto(posicionMouse))
                {
                    return nodo;
                }
            }

            return null;
        }

        /// <summary>
        /// Reestablece el grafo al estado original
        /// </summary>
        /// <param name="g">Grafico a dibujar</param>
        public void ReestablecerGrafo(Graphics g)
        {
            foreach (Vertice nodo in ListaNodos)
            {
                nodo.ColorVertice = Color.White;
                nodo.ColorFuente = Color.Black;
                foreach (Arista arista in nodo.ListaAdyacencia)
                {
                    arista.GrosorFlecha = 1;
                    arista.ColorArista = Color.Black;
                }
            }

            DibujarGrafo(g);
        }

        /// <summary>
        /// Colorea una arista
        /// </summary>
        /// <param name="nombreNodoOrigen">Nombre del nodo origen</param>
        /// <param name="NombreNodoDestino">Nombre del nodo destino</param>
        public void ColorArista(string nombreNodoOrigen, string NombreNodoDestino)
        {
            foreach (Vertice nodo in _listaNodos)
            {
                foreach (Arista arista in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null &&
                        nodo.Nombre == nombreNodoOrigen &&
                        arista.VerticeDestino.Nombre == NombreNodoDestino)
                    {
                        arista.ColorArista = Color.Red;
                        arista.GrosorFlecha = 4;
                    }
                }
            }
        }

        public void Colorear(Vertice nodo)
        {
            nodo.ColorVertice = Color.AliceBlue;
            nodo.ColorFuente = Color.Black;
        }

        public Vertice VerticeDistanciaMinima()
        {
            int min = int.MaxValue;
            Vertice temp = null;
            foreach (Vertice nodoOrigen in _listaNodos)
            {
                if (nodoOrigen.Visitado)
                {
                    foreach (Vertice nodoDestino in _listaNodos)
                    {
                        if (!nodoDestino.Visitado)
                        {
                            foreach (Arista arista in nodoOrigen.ListaAdyacencia)
                            {
                                if (arista.VerticeDestino == nodoDestino && min > arista.Peso)
                                {
                                    min = arista.Peso;
                                    temp = nodoDestino;
                                }
                            }
                        }
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Obtiene la poscion que ocupa un nodo de la lista de adyacencia
        /// </summary>
        /// <param name="nombreNodo"></param>
        /// <returns></returns>
        public int PosicionNodo(string nombreNodo)
        {
            for (int i = 0; i < _listaNodos.Count; i++)
            {
                if (string.Compare(_listaNodos[i].Nombre, nombreNodo) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Re-dibuja las aristas que llegan a un nodo
        /// </summary>
        /// <param name="nodoDestino">Nodo al que se le van a redibujar las aristas </param>
        public void DibujarAristasEntrantes(Vertice nodoDestino)
        {
            foreach (Vertice nodo in _listaNodos)
            {
                foreach (Arista arista in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo != nodoDestino)
                    {
                        if (arista.VerticeDestino == nodoDestino)
                        {
                            arista.ColorArista = Color.Black;
                            arista.GrosorFlecha = 2;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Desmarca todos los nodos visitados
        /// </summary>
        public void DesmarcarVertices()
        {
            foreach (Vertice nodo in _listaNodos)
            {
                nodo.Visitado = false;
                nodo.Padre = null;
                nodo.DistanciaNodo = int.MaxValue;
                nodo.PesoAsignado = false;
            }
        }

        #endregion Metodos para trabajar el grafo con una lista de adyacencia
    }
}
