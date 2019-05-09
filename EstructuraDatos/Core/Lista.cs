using System;

namespace Core
{
	public class Nodo
	{
		// almacena el valor del nodo
		public int Dato { get; set; }
		// atributo que señala al siguiente nodo, clase auto referenciada
		public Nodo Siguiente { get; set; }
	}
	public class Lista
	{
		// Cabeza de la lista
		public Nodo nodoCabeza;

		public Lista()
		{
			nodoCabeza = null;
		}

		public void InsertarOrdenado(int item)
		{
			Nodo nodoAnterior;
			// Nodo temporal que todavia no pertenece a la lista
			Nodo nodoNuevo = new Nodo
			{
				// Se almacena en el atributo dato el valor que viene en item
				Dato = item,
				// Se hace que el apuntador señale a null 
				Siguiente = null
			};

			// Verifica si la lista esta vacia 
			if (nodoCabeza == null)
			{
				// Hacemos que nodo sea parte de la lista, se hace la cabeza
				nodoCabeza = nodoNuevo;
			}
			else
			{
				nodoAnterior = nodoCabeza;
				while (nodoAnterior.Siguiente != null && nodoAnterior.Siguiente.Dato <= item)
				{
					nodoAnterior = nodoAnterior.Siguiente;
				}

				if (nodoAnterior.Dato > nodoNuevo.Dato)
				{
					Nodo aux = nodoAnterior;
					nodoAnterior = nodoNuevo;
					nodoNuevo.Siguiente = aux;
				}
				else
				{
					nodoAnterior.Siguiente = nodoNuevo;
				}
			}
		}

		/// <summary>
		/// Inserta un elemento al final de la lista
		/// </summary>
		/// <param name="item">Elemento a insertar</param>
		public void InsertarFinal(int item)
		{
			// Nodo temporal que todavia no pertenece a la lista
			Nodo nodoNuevo = new Nodo
			{
				// Se almacena en el atributo dato el valor que viene en item
				Dato = item,
				// Se hace que el apuntador señale a null 
				Siguiente = null
			};

			// Verifica si la lista esta vacia 
			if (nodoCabeza == null)
			{
				// Hacemos que nodo sea parte de la lista, se hace la cabeza
				nodoCabeza = nodoNuevo;
			}
			else
			{
				// se utiliza este nodo para recorrer la lista, asi la cabeza no se mueve
				Nodo nodoPuntero;
				// Situamos a puntero señalando al mismo nodo que inicio
				nodoPuntero = nodoCabeza;
				while (nodoPuntero.Siguiente != null)
				{
					// Se desplaza por todos los nodos de la lista
					nodoPuntero = nodoPuntero.Siguiente;
				}
				// hacemos que el ultimo nodo señale al auxiliar
				nodoPuntero.Siguiente = nodoNuevo;
			}
		}

		/// <summary>
		/// Inserta un elemento al inicio de la lista
		/// </summary>
		/// <param name="item">Elemento a insertar</param>
		public void InsertarInicio(int item)
		{
			// Nodo temporal que despues es agrega a la lista
			Nodo nodoNuevo = new Nodo
			{
				Dato = item,
				Siguiente = null
			};

			// Verifica si la lista esta vacia 
			if (nodoCabeza == null)
			{
				// Hacemos que nodo sea parte de la lista, se hace la cabeza
				nodoCabeza = nodoNuevo;
			}
			else
			{
				// guarda la antigua cabeza
				Nodo nodoPuntero = nodoCabeza;
				// el nuevo nodo ahora es la cabeza
				nodoCabeza = nodoNuevo;
				// a este punto la cabeza esta rota, por eso se debe asignar la referencia a la antigua cabeza
				// que quedó guarda en nodoPuntero, con esto ya queda la lista unida nuevamente.
				nodoCabeza.Siguiente = nodoPuntero;
			}
		}

		/// <summary>
		/// Elimina el nodo cabeza
		/// </summary>
		public void EliminarNodoCabeza()
		{
			if (nodoCabeza == null)
			{
				Console.WriteLine("Lista vacia, no se puede eliminar el elemento");
			}
			else
			{
				// se hace avanzar una nueva posicion a cabeza para que la segunda posicion sea ahora cabeza
				nodoCabeza = nodoCabeza.Siguiente;
			}
		}

		/// <summary>
		/// Elimina el nodo cola
		/// </summary>
		public void EliminarNodoCola()
		{
			if (nodoCabeza == null)
			{
				Console.WriteLine("Lista vacia, no se puede eliminar el elemento");
			}
			else
			{
				// se requieren dos punteros
				Nodo nodoPunteroAnterior, nodoPunteroPosterior;
				// se inician ambos punteros con el nodo cabeza
				nodoPunteroAnterior = nodoPunteroPosterior = nodoCabeza;

				// mientras nodoPunteroPosterior no señale a null, significa que no se ha llegado al final
				while (nodoPunteroPosterior.Siguiente != null)
				{
					// el punteroAnterior sera el punteroPosterior antes que 
					// el puntero posterior avance al siguiente nodo
					nodoPunteroAnterior = nodoPunteroPosterior;
					nodoPunteroPosterior = nodoPunteroPosterior.Siguiente;
				}

				// punteroAnterior ya tiene el ultimo elemento, por que antes que punteroPosterior avanzara
				// se asigno a punteroAnterior y cuando punteroPosterior es null es porque ya no hay nodos
				nodoPunteroAnterior.Siguiente = null;
			}
		}

		/// <summary>
		/// Inserta un elemento en una posicion especifica de la lista
		/// </summary>
		/// <param name="item">elemento a insertar</param>
		/// <param name="posicion">posicion donde se va insertar</param>
		public void InsertarNodoPosicion(int item, int posicion)
		{
			// Nodo que se va insertar cuando se encuentre la posicion donde se debe insertar
			Nodo nodoNuevo = new Nodo
			{
				Dato = item,
				Siguiente = null
			};

			if (nodoCabeza == null)
			{
				Console.WriteLine("Lista vacia, no se puede eliminar el elemento");
			}
			else
			{
				Nodo nodoPuntero;
				// puntero inicia en la cabeza para recorrer toda la lista
				nodoPuntero = nodoCabeza;

				// si posicion es 1 se inserta en la cabeza
				if (posicion == 1)
				{
					InsertarInicio(item);
				}
				else
				{
					// solo me interesa avansar hasta el nodo con el indice dado
					for (int i = 1; i < posicion - 1; i++)
					{
						nodoPuntero = nodoPuntero.Siguiente;
						if (nodoPuntero.Siguiente == null)
						{
							// si el ciclo no ha terminado y ya se llegó al final de la lista se rompe el ciclo
							break;
						}
					}

					// apuntador de ayuda
					Nodo nodoPunteroAuxiliar;
					// a quien señalaba el puntero ahí se ubicará el punteroAuxiliar
					nodoPunteroAuxiliar = nodoPuntero.Siguiente;
					// puntero ahora apuntará al nuevo nodo
					nodoPuntero.Siguiente = nodoNuevo;
					// el nuevo nodo recien ingresado señalará a punteroAuxiliar
					nodoNuevo.Siguiente = nodoPunteroAuxiliar;
					// con las ultimas cuatro lineas es como cortar la lista y volverla unir con el nuevo elemento
				}
			}
		}

		/// <summary>
		/// Obtiene el nodo que esta en la cola
		/// </summary>
		/// <returns>retorna el nodo que se encontro en la cola</returns>
		public Nodo ObtenerNodoCola()
		{
			if (nodoCabeza == null)
			{
				Console.WriteLine("Lista vacia, no hay ultimo nodo!");
				return null;
			}
			else
			{
				// se requieren dos punteros
				Nodo nodoPunteroAnterior, nodoPunteroPosterior;
				// se inician ambos punteros con el nodo cabeza
				nodoPunteroAnterior = nodoPunteroPosterior = nodoCabeza;

				// mientras nodoPunteroPosterior no señale a null, significa que no se ha llegado al final
				while (nodoPunteroPosterior.Siguiente != null)
				{
					// el punteroAnterior sera el punteroPosterior antes que 
					// el puntero posterior avance al siguiente nodo
					nodoPunteroAnterior = nodoPunteroPosterior;
					nodoPunteroPosterior = nodoPunteroPosterior.Siguiente;
				}

				// punteroAnterior ya tiene el ultimo elemento, por que antes que punteroPosterior avanzara
				// se asigno a punteroAnterior y cuando punteroPosterior es null es porque ya no hay nodos
				return nodoPunteroAnterior.Siguiente;
			}
		}

		public void Ordenar()
		{
			if (nodoCabeza != null && nodoCabeza.Siguiente != null)
			{
				Nodo nodoPuntero = nodoCabeza;
				Nodo nodoPunteroSiguiente = nodoPuntero.Siguiente;
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
					}
				}
			}
		}

		public Lista ObtenerDiferencia()
		{
			Nodo nodoPuntero = nodoCabeza;
			Lista listaDirencia = new Lista();
			while (nodoPuntero != null)
			{
				if (nodoPuntero.Siguiente != null)
				{
					if (nodoPuntero.Dato != nodoPuntero.Siguiente.Dato)
					{
						listaDirencia.InsertarFinal(nodoPuntero.Dato);
						nodoPuntero = nodoPuntero.Siguiente;
					}
					else
					{
						nodoPuntero = nodoPuntero.Siguiente.Siguiente;
					}
				}
				else
				{
					listaDirencia.InsertarFinal(nodoPuntero.Dato);
					nodoPuntero = nodoPuntero.Siguiente;
				}
			}

			return listaDirencia;
		}

		/// <summary>
		/// Mostrar la lista
		/// </summary>
		public void MostrarLista()
		{
			if (nodoCabeza == null)
			{
				Console.WriteLine("Lista vacia, no se puede eliminar el elemento");
			}
			else
			{
				Nodo puntero;
				// Se inica el puntero con el nodo cabeza
				puntero = nodoCabeza;
				// Se imprime el primer dato
				Console.Write("{0} -> \t", puntero.Dato);
				while (puntero.Siguiente != null)
				{
					// Se avanza al siguiente nodo
					puntero = puntero.Siguiente;
					// se imprime con Write para que no salte a la siguiente linea
					Console.Write("{0} -> \t", puntero.Dato);
				}
			}
			Console.WriteLine();
		}
	}
}
