using Core;
using System;
using System.Collections.Generic;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			int inicio = 0;
			int final = 0;
			// index del nodo actual
			int actual = 0;
			// va contener la informacion que indica que nodo va hacer el de inicio y final
			string dato = string.Empty;
			// Cantidad de nodos del grafo a evaluar
			int cantidadNodos = 22;
			// Crear el grafo
			Grafo grafo = CrearGrafo(cantidadNodos);

			Console.WriteLine("Ingresar el indice del nodo inicio");
			dato = Console.ReadLine();
			inicio = Convert.ToInt32(dato);

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

			Console.WriteLine();

			MostrarRuta(rutaInicial, rutaFinal);

			Console.WriteLine();

			int sumaAristas = SumarPesoAristas(rutaInicial, rutaFinal, grafo);
			Console.WriteLine("Suma total del peso de las aristas: {0}", sumaAristas);
			Console.ReadLine();
		}

		private static void MostrarRuta(List<int> rutaInicial, List<int> rutaFinal)
		{
			foreach (int posicion in rutaInicial)
			{
				Console.Write("{0}->", posicion);
			}

			foreach (int posicion in rutaFinal)
			{
				Console.Write("{0}->", posicion);
			}
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
