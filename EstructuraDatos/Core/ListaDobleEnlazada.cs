namespace Core
{
	public class NodoListaDoble
	{
		public int Dato { get; set; }
		public NodoListaDoble Anterior { get; set; }
		public NodoListaDoble Siguiente { get; set; }
	}
	public class ListaDobleEnlazada
	{
		private NodoListaDoble NodoRaiz;
		public ListaDobleEnlazada()
		{
			NodoRaiz = null;
		}

		public void InsertarInicio(int item)
		{
			NodoListaDoble nuevoNodo = new NodoListaDoble
			{
				Dato = item
			};

			if (NodoRaiz == null)
			{
				NodoRaiz = nuevoNodo;
			}
			else
			{
				nuevoNodo.Siguiente = NodoRaiz;
				NodoRaiz.Anterior = nuevoNodo;
				NodoRaiz = nuevoNodo;
			}
		}

		public void InsertarFinal(int item)
		{
			NodoListaDoble nodoNuevo = new NodoListaDoble
			{
				Dato = item
			};

			if (NodoRaiz == null)
			{
				NodoRaiz = nodoNuevo;
			}
			else
			{
				// Nodo para recorrer la lista
				NodoListaDoble nodoPuntero = NodoRaiz;
				while (nodoPuntero.Siguiente != null)
				{
					nodoPuntero = nodoPuntero.Siguiente;
				}

				nodoPuntero.Siguiente = nodoNuevo;
				nodoNuevo.Anterior = nodoPuntero;
				nodoPuntero = nodoNuevo;
			}
		}

		public void InsertarPosicion(int posicion, int item)
		{
			if (posicion == 1)
			{
				InsertarInicio(item);
			}
			else
			{
				NodoListaDoble nodoPuntero = NodoRaiz;
				for (int indice = 1; indice <= posicion - 1; indice++)
				{
					if (nodoPuntero.Siguiente == null)
					{
						break;
					}
					else
					{
						nodoPuntero = nodoPuntero.Siguiente;
					}
				}

				// Si se cumple esta condicion es porque el insert se hara en la cola
				if (nodoPuntero.Siguiente == null)
				{
					InsertarFinal(item);
				}
				else
				{
					NodoListaDoble nodoNuevo = new NodoListaDoble
					{
						Dato = item
					};
					NodoListaDoble Aux = nodoPuntero.Siguiente;
					nodoPuntero.Siguiente = nodoNuevo;
					nodoNuevo.Anterior = nodoPuntero;
					nodoNuevo.Siguiente = Aux;
					Aux.Anterior = nodoNuevo;
				}

			}

		}
	
		public void Ordenar()
		{
			if (NodoRaiz != null && NodoRaiz.Siguiente != null)
			{
				NodoListaDoble nodoPuntero = NodoRaiz;
				NodoListaDoble nodoPunteroSiguiente = nodoPuntero.Siguiente;
				while (nodoPuntero.Siguiente != null)
				{
					if (nodoPuntero.Dato < nodoPunteroSiguiente.Dato)
					{
						if (nodoPunteroSiguiente.Siguiente != null)
						{
							nodoPunteroSiguiente = nodoPunteroSiguiente.Siguiente;
						}
						else
						{
							nodoPuntero = nodoPuntero.Siguiente;
							nodoPunteroSiguiente = nodoPuntero.Siguiente;
						}
					}
					else
					{
						int aux = nodoPuntero.Dato;
						nodoPuntero.Dato = nodoPunteroSiguiente.Dato;
						nodoPunteroSiguiente.Dato = aux;
						if (nodoPunteroSiguiente.Siguiente != null)
						{
							nodoPunteroSiguiente = nodoPunteroSiguiente.Siguiente;
						}
						else
						{
							nodoPuntero = nodoPuntero.Siguiente;
							nodoPunteroSiguiente = nodoPuntero.Siguiente;
						}
						//NodoListaDoble aux = nodoPunteroSiguiente.Siguiente;
						//nodoPuntero.Siguiente = aux;
						//nodoPuntero.Anterior = nodoPunteroSiguiente;
						//nodoPunteroSiguiente.Siguiente = nodoPuntero;
						//nodoPunteroSiguiente.Anterior = nodoPuntero.Anterior;
						//nodoPunteroSiguiente = aux;
					}
				}
			}
		}
		
		public void Invertir()
		{
			NodoListaDoble nodoAux = null;
			NodoListaDoble nodoPuntero = NodoRaiz;

			while (nodoPuntero != null)
			{
				nodoAux = nodoPuntero.Anterior;
				nodoPuntero.Anterior = nodoPuntero.Siguiente;

				nodoPuntero.Siguiente = nodoAux;
				nodoPuntero = nodoPuntero.Anterior;
			}

			if (nodoAux != null)
			{
				NodoRaiz = nodoAux.Anterior;
			}
		}

		public int CantidadNodos()
		{
			int cantidad = 0;
			while (NodoRaiz.Siguiente != null)
			{
				NodoRaiz = NodoRaiz.Siguiente;
				cantidad++;
			}

			return cantidad;
		}

		public int EsListaPalindroma()
		{
			int palindroma = 1;
			NodoListaDoble nodoPuntero, nodoCola;
			nodoPuntero = nodoCola = NodoRaiz;
			while(nodoCola.Siguiente != null)
			{
				nodoCola = nodoCola.Siguiente;
			}

			while (nodoPuntero != nodoCola)
			{
				if(nodoPuntero.Dato == nodoCola.Dato)
				{ 
					nodoPuntero = nodoPuntero.Siguiente;
					nodoCola = nodoCola.Anterior;
				}
				else
				{
					palindroma = 0;
					break;
				}
			}

			return palindroma;
		}
	}
}
