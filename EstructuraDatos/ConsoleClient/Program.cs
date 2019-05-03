using Core;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			// Cantidad de comensales de una mesa
			int t = Convert.ToInt32(Console.ReadLine());
			// Platos escojidos por los comensales
			string[] vectorPlatillos = Console.ReadLine().Split(' ');
			// Tiempos que tienen disponibles los comensales para comer
			string[] vectorTiempoDisponible = Console.ReadLine().Split(' ');
			// Tiempos de los menus en el grafo
			Dictionary<string, int> tiempoMenus = new Dictionary<string, int>();
			// Ruta de cada menu
			Dictionary<string, string> rutaMenus = new Dictionary<string, string>();
			// lista de lineas para la respuesta que se va enviar al cliente
			List<string> listaLineas = new List<string>();
			//Pila para almacenar los platillos 
			Stack<string> pilaPlatillos = new Stack<string>(4);
			pilaPlatillos.Push("D");
			pilaPlatillos.Push("C");
			pilaPlatillos.Push("B");
			pilaPlatillos.Push("A");

			for (int k = 0; k <= 3; k++)
			{
				string rutaPlato = string.Empty;
				int tiempoPlatillo = ObtenerTiempoPlatillo(k, ref rutaPlato);
				string plato = pilaPlatillos.Pop();
				tiempoMenus.Add(plato, tiempoPlatillo);
				rutaMenus.Add(plato, rutaPlato);
			}

			for (int i = 0; i < vectorPlatillos.Length; i++)
			{
				int tiempoPlatillo = tiempoMenus[vectorPlatillos[i]];
				string platoSegunTiempo = ObtenerPlatilloSegunTiempo(Convert.ToInt32(vectorTiempoDisponible[i]), tiempoMenus);
				string rutaPlatilloPrincipal = rutaMenus[vectorPlatillos[i]];

				string lineaRespuesta = string.Format("Comensal {0}: {1} {2} \nRuta: {3}", i + 1, tiempoPlatillo, platoSegunTiempo, rutaPlatilloPrincipal);
				listaLineas.Add(lineaRespuesta);
			}

			MostarRespuesta(listaLineas);

			// Linea para que no se cierre la consola. 
			Console.ReadLine();
		}

		private static void MostarRespuesta(List<string> listaLineas)
		{
			Console.WriteLine();
			foreach (string linea in listaLineas)
			{
				Console.Write(linea);
				Console.WriteLine();
				Console.WriteLine();
			}
		}

		private static string ObtenerPlatilloSegunTiempo(int tiempo, Dictionary<string, int> tiempoMenus)
		{
			int tiempoMayor = 0;
			string platilloRecomendado = string.Empty;
			foreach (KeyValuePair<string, int> menu in tiempoMenus)
			{
				if (menu.Value <= tiempo && menu.Value >= tiempoMayor)
				{
					platilloRecomendado = menu.Key;
					tiempoMayor = menu.Value;
				}
			}

			if (tiempoMayor == 0)
			{
				platilloRecomendado = "null";
			}

			return platilloRecomendado;
		}

		private static int ObtenerTiempoPlatillo(int inicio, ref string ruta)
		{
			int final = 0;
			// index del nodo actual
			int actual = 0;
			// va contener la informacion que indica que nodo va hacer el de inicio y final
			string dato = string.Empty;
			// Cantidad de nodos del grafo a evaluar
			int cantidadNodos = 22;
			// Crear el grafo
			Grafo grafo = CrearGrafo(cantidadNodos);

			final = IndexSegundoRecurrido(inicio);

			// Creacion de tabla para guardar informacion que necesita el algoritmo
			// 0 - visitado
			// 1 - tiempo
			// 2 - previo
			int[,] tabla = new int[cantidadNodos, 3];

			actual = inicio;

			RecorrerGrafoDijkstra(inicio, ref actual, cantidadNodos, grafo, tabla);

			// Obtener ruta inicial
			List<int> rutaInicial = ObtenerRuta(inicio, final, tabla, true);

			actual = inicio = final;
			// Se indica el 11 como nodo final dato el grafo propuesto
			final = 11;
			RecorrerGrafoDijkstra(inicio, ref actual, cantidadNodos, grafo, tabla);

			// Obtener ruta
			List<int> rutaFinal = ObtenerRuta(inicio, final, tabla, false);

			int sumaAristas = SumarPesoAristas(rutaInicial, rutaFinal, grafo);

			ruta = MostrarRuta(rutaInicial, rutaFinal);

			return sumaAristas;
		}

		private static string MostrarRuta(List<int> rutaInicial, List<int> rutaFinal)
		{
			string ruta = string.Empty;
			foreach (int posicion in rutaInicial)
			{
				ruta += string.Format("{0}->", posicion);
			}

			foreach (int posicion in rutaFinal)
			{
				ruta += string.Format("{0}->", posicion);
			}

			return ruta;
		}

		private static int SumarPesoAristas(List<int> rutaInicial, List<int> rutaFinal, Grafo grafo)
		{
			int[] pesoAristas = new int[rutaInicial.Count + rutaFinal.Count];
			int index = 0;
			int sumaAristas = 0;
			foreach (int posicion in rutaInicial)
			{
				pesoAristas[index] = posicion;
				index++;
			}

			foreach (int posicion in rutaFinal)
			{
				pesoAristas[index] = posicion;
				index++;
			}

			for (int i = 0; i < pesoAristas.Length - 1; i++)
			{
				sumaAristas += grafo.ObtenerAdyacencia(pesoAristas[i], pesoAristas[i + 1]);
			}

			return sumaAristas;
		}

		private static List<int> ObtenerRuta(int inicio, int final, int[,] tabla, bool isAgregarInicio)
		{
			List<int> ruta = new List<int>();
			int nodo = final;
			while (nodo != inicio)
			{
				ruta.Add(nodo);
				nodo = tabla[nodo, 2];
			}
			if (isAgregarInicio)
			{
				ruta.Add(inicio);
			}

			// se reversa la lista para que la ruta de los nodos queden en orden
			ruta.Reverse();
			return ruta;
		}

		private static void RecorrerGrafoDijkstra(int inicio, ref int actual, int cantidadNodos, Grafo grafo, int[,] tabla)
		{
			// Peso de la arista
			int peso = 0;
			// Inicializar tabla, que guarda la informacion que necesita el algoritmo
			for (int n = 0; n < cantidadNodos; n++)
			{
				tabla[n, 0] = 0;
				tabla[n, 1] = int.MaxValue;
				tabla[n, 2] = 0;
			}
			tabla[inicio, 1] = 0;

			do
			{
				// Marcar nodo como visitado
				tabla[actual, 0] = 1;
				for (int columna = 0; columna < cantidadNodos; columna++)
				{
					// buscar a quien se dirige
					if (grafo.ObtenerAdyacencia(actual, columna) != 0)
					{
						// Calular el tiempo
						peso = grafo.ObtenerAdyacencia(actual, columna) + tabla[actual, 1];

						// Actualizamos el tiempo en la tabla de informacion del algoritmo
						if (peso < tabla[columna, 1])
						{
							tabla[columna, 1] = peso;

							// Se coloca la informacion del padre
							tabla[columna, 2] = actual;
						}
					}
				}

				// El nuevo actual es el nodo con el menor tiempo que no se ha visitado

				int indiceMenor = -1;
				int tiempoMenor = int.MaxValue;

				for (int x = 0; x < cantidadNodos; x++)
				{
					if (tabla[x, 1] < tiempoMenor && tabla[x, 0] == 0)
					{
						indiceMenor = x;
						tiempoMenor = tabla[x, 1];
					}
				}

				actual = indiceMenor;

			} while (actual != -1);
		}

		private static int IndexSegundoRecurrido(int indexInicial)
		{
			int index = -1;
			switch (indexInicial)
			{
				case 0:
					{
						index = 6;
						break;
					}
				case 1:
					{
						index = 12;
						break;
					}
				case 2:
					{
						index = 17;
						break;
					}
				case 3:
					{
						index = 19;
						break;
					}
				default:
					break;
			}

			return index;
		}

		private static Grafo CrearGrafo(int cantidadNodos)
		{
			Grafo grafo = new Grafo(cantidadNodos);

			grafo.AdicionarArista(0, 4, 2);
			grafo.AdicionarArista(1, 4, 2);
			grafo.AdicionarArista(2, 4, 2);
			grafo.AdicionarArista(3, 4, 2);
			grafo.AdicionarArista(4, 5, 1);
			grafo.AdicionarArista(5, 6, 4);
			grafo.AdicionarArista(5, 12, 7);
			grafo.AdicionarArista(5, 16, 10);
			grafo.AdicionarArista(5, 14, 9);
			grafo.AdicionarArista(6, 7, 6);
			grafo.AdicionarArista(7, 8, 3);
			grafo.AdicionarArista(8, 9, 2);
			grafo.AdicionarArista(9, 10, 3);
			grafo.AdicionarArista(10, 11, 2);
			grafo.AdicionarArista(12, 13, 8);
			grafo.AdicionarArista(13, 14, 3);
			grafo.AdicionarArista(13, 17, 11);
			grafo.AdicionarArista(14, 15, 1);
			grafo.AdicionarArista(14, 19, 9);
			grafo.AdicionarArista(15, 10, 1);
			grafo.AdicionarArista(16, 13, 1);
			grafo.AdicionarArista(17, 10, 6);
			grafo.AdicionarArista(18, 10, 5);
			grafo.AdicionarArista(19, 20, 8);
			grafo.AdicionarArista(20, 21, 7);
			grafo.AdicionarArista(21, 18, 6);
			return grafo;
		}

	}
}
