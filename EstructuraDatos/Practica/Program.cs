using Core;
using System;

namespace Practica
{
	class Program
	{
		static void Main(string[] args)
		{
			int t = Convert.ToInt32(Console.ReadLine());
			while (t > 0)
			{
				t--;
				//int n = Convert.ToInt32(Console.ReadLine());
				string[] vectorLista = Console.ReadLine().Split(' ');
				Lista lista = new Lista();

				for (int i = 0; i < vectorLista.Length; i++)
				{
					if (!string.IsNullOrEmpty(vectorLista[i]))
					{
						lista.InsertarFinal(int.Parse(vectorLista[i]));
					}
				}
				//n = Convert.ToInt32(Console.ReadLine());
				vectorLista = Console.ReadLine().Split(' ');
				for (int i = 0; i < vectorLista.Length; i++)
				{
					lista.InsertarFinal(int.Parse(vectorLista[i]));
				}

				lista.InsertarNodoPosicion(14, 3);
				lista.InsertarInicio(0);
				lista.MostrarLista();
				lista.EliminarNodoCabeza();
				lista.MostrarLista();
				lista.EliminarNodoCola();
				lista.MostrarLista();
				Console.ReadLine();
			}
		}
	}
}
