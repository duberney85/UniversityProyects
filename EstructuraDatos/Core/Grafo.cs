using System;

namespace Core
{
	public class Grafo
	{
		private readonly int[,] _matrizAdyacencia;
		private readonly int[] _indegree;
		private readonly int _nodos;

		public Grafo(int totalNodos)
		{
			_nodos = totalNodos;

			// instancia de matriz de adyacencia 
			_matrizAdyacencia = new int[_nodos, _nodos];

			// instancia del arreglo de indegree
			_indegree = new int[_nodos];
		}

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
	}
}
