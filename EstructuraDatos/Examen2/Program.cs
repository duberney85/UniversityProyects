using Core;
using System;

namespace Practica
{
	class Program
	{
		static void Main(string[] args)
		{
			EjercicioPalindromo();
			EjercicioConjuntos();
		}

		static void EjercicioPalindromo()
		{
			int t = Convert.ToInt32(Console.ReadLine());
			int totalInteracciones = 0;
			while (t > 0)
			{
				Console.WriteLine();
				totalInteracciones++;
				Console.Write(string.Format("Interaccion {0}", totalInteracciones));
				Console.WriteLine();
				t--;
				int n = Convert.ToInt32(Console.ReadLine());
				string[] vectorLista = Console.ReadLine().Split(' ');
				ListaDobleEnlazada listaPalindroma = new ListaDobleEnlazada();
				for (int i = 0; i < vectorLista.Length; i++)
				{
					if (!string.IsNullOrEmpty(vectorLista[i]))
					{
						listaPalindroma.InsertarFinal(int.Parse(vectorLista[i]));
					}
				}
				int p = listaPalindroma.EsListaPalindroma();
				string respuesta = string.Empty;
				if (p == 1)
				{
					respuesta = "La lista es palindroma";
				}
				else
				{
					respuesta = "La lista no es palindroma";
				}

				Console.Write(respuesta);
				Console.WriteLine();
			}
			Console.ReadLine();
		}

		static void EjercicioConjuntos()
		{
			Console.Write("Ingrese la primera lista");
			Console.WriteLine();
			string[] vectorLista = Console.ReadLine().Split(' ');


			ListaEnlazada listaSimetrica = new ListaEnlazada();
			for (int i = 0; i < vectorLista.Length; i++)
			{
				if (!string.IsNullOrEmpty(vectorLista[i]))
				{
					listaSimetrica.InsertarFinal(int.Parse(vectorLista[i]));
				}
			}
			Console.WriteLine();
			Console.Write("Ingrese la segunda lista");
			Console.WriteLine();

			vectorLista = Console.ReadLine().Split(' ');

			for (int i = 0; i < vectorLista.Length; i++)
			{
				if (!string.IsNullOrEmpty(vectorLista[i]))
				{
					listaSimetrica.InsertarFinal(int.Parse(vectorLista[i]));
				}
			}

			listaSimetrica.Ordenar();
			ListaEnlazada listaSimetricaFinal = listaSimetrica.ObtenerDiferencia();
			if (listaSimetrica != null)
			{
				Console.Write("La diferencia simetrica es: ");
				Console.WriteLine();
				listaSimetricaFinal.MostrarLista();
			}
			else
			{
				Console.Write("La union de las listas: ");
				Console.WriteLine();
				listaSimetrica.MostrarLista();
			}
			Console.ReadLine();
		}
	}
}
