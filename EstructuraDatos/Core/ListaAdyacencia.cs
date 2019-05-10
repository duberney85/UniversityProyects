namespace Core
{
    public class ListaAdyacencia
    {
        private Vertice _verticeRaiz;
        private ListaAdyacencia _subListaAdyacencia;
        private int _peso;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ListaAdyacencia()
        {
            Vertice = null;
            SubListaAdyacencia = null;
            Peso = 0;
        }

        /// <summary>
        /// Constructor que recibe instancia de una lista adyacente 
        /// </summary>
        /// <param name="listaAdyacencia">Instacia de una lista adyacente</param>
        public ListaAdyacencia(ListaAdyacencia listaAdyacencia)
        {
            if (listaAdyacencia != null)
            {
                Vertice = listaAdyacencia.Vertice;
                SubListaAdyacencia = listaAdyacencia.SubListaAdyacencia;
                Peso = listaAdyacencia.Peso;
            }
        }

        /// <summary>
        /// Constructor que recibe un vertice, una lista de adyacencia y su peso
        /// </summary>
        /// <param name="vertice">Nuevo vertice</param>
        /// <param name="subListaAdyacencia">Nueva lista</param>
        /// <param name="peso">peso o valor</param>
        public ListaAdyacencia(Vertice vertice, ListaAdyacencia subListaAdyacencia, int peso)
        {
            _verticeRaiz = vertice;
            _subListaAdyacencia = subListaAdyacencia;
            _peso = peso;
        }

        public Vertice Vertice
        {
            get { return _verticeRaiz; }
            set { _verticeRaiz = value; }
        }
        public ListaAdyacencia SubListaAdyacencia
        {
            get { return _subListaAdyacencia; }
            set { _subListaAdyacencia = value; }
        }
        public int Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        /// <summary>
        /// Verifica si la lista esta vacia
        /// </summary>
        /// <returns></returns>
        public bool EsVacia()
        {
            return _verticeRaiz == null;
        }

        /// <summary>
        /// Agrega un nuevo vertice
        /// </summary>
        /// <param name="nuevoVertice">Vertice a agregar</param>
        /// <param name="peso">valor o peso de la arista</param>
        public void AgregarVertice(Vertice nuevoVertice, int peso)
        {
            if(nuevoVertice!=null)
            {
                if(_verticeRaiz==null)
                {
                    _verticeRaiz = new Vertice(nuevoVertice.Nombre);
                    _peso = peso;
                    _subListaAdyacencia = new ListaAdyacencia();
                }
                else
                {
                    if(!ExisteElemento(nuevoVertice))
                    {
                        _subListaAdyacencia.AgregarVertice(nuevoVertice, peso);
                    }
                }
            }
        }

        /// <summary>
        /// Busca un nodo en la lista de adyacencia
        /// </summary>
        /// <param name="vertice">Nodo a buscar</param>
        /// <returns></returns>
        public bool ExisteElemento(Vertice vertice)
        {
            if (_verticeRaiz != null && _verticeRaiz != null)
            {
                return (_verticeRaiz.Equals(vertice) || _subListaAdyacencia.ExisteElemento(vertice));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un vertice existente
        /// </summary>
        /// <param name="verticeEliminar">Vertice a eliminar</param>
        public void EliminarVertice(Vertice verticeEliminar)
        {
            if(_verticeRaiz != null)
            {
                if(_verticeRaiz.Equals(verticeEliminar))
                {
                    _verticeRaiz = _subListaAdyacencia._verticeRaiz;
                    _subListaAdyacencia = _subListaAdyacencia._subListaAdyacencia;
                }
                else
                {
                    _subListaAdyacencia.EliminarVertice(verticeEliminar);
                }
            }
        }

        /// <summary>
        /// Obtiene la cantidad de nodos
        /// </summary>
        /// <returns></returns>
        public int NumeroVertices()
        {
            if(_verticeRaiz != null)
            {
                return 1 + _subListaAdyacencia.NumeroVertices();
            }
            else
            {
                return 0;
            }
        }

        public object LesimoVertice(int posicion)
        {
            if(posicion>0 && posicion <= NumeroVertices())
            {
                if(posicion == 1)
                {
                    return _verticeRaiz;
                }
                else
                {
                    return _subListaAdyacencia.LesimoVertice(posicion - 1);
                }
            }
            else
            {
                return null;
            }
        }

        public object LesimoElementoPeso(int posicion)
        {
            if (posicion > 0 && posicion <= NumeroVertices())
            {
                if(posicion == 1)
                {
                    return _peso;
                }
                else
                {
                    return _subListaAdyacencia.LesimoElementoPeso(posicion - 1);
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Ubica la posicion que ocupa un nodo en la lista de adyacencia
        /// </summary>
        /// <param name="vertice">Nodo que se va buscar</param>
        /// <returns></returns>
        public int PosicionElemento(Vertice vertice)
        {
            if(_verticeRaiz != null || ExisteElemento(vertice))
            {
                if (_verticeRaiz.Equals(vertice))
                {
                    return 1;
                }
                else
                {
                    return 1 + _subListaAdyacencia.PosicionElemento(vertice);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
