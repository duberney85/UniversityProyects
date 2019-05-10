using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Core
{
	public class Business
	{
		string[] vector;
		const string rutaArchivoPruebas = @"D:\Proyectos\Test\Pruebas\TextoPrueba.txt";

		public void CrearEjercicio()
		{
			int t = Convert.ToInt32(Console.ReadLine());
			while (t > 0)
			{
				t--;
				int n = Convert.ToInt32(Console.ReadLine());
				vector = new string[n * 2];
				vector = Console.ReadLine().Split(' ');
				int mayor = 0;
				for (int i = 0; i < vector.Length; i = i + 2)
				{
					int pies = int.Parse(vector[i]) * 12;
					int suma = pies + int.Parse(vector[i + 1]);
					if (suma > mayor)
					{
						mayor = suma;
					}
				}
				Console.WriteLine(mayor);
			}
		}

		public void EjercicioPila()
		{

			int t = 1;// Convert.ToInt32(Console.ReadLine());
			while (t > 0)
			{
				t--;
				string line = "12224";// Console.ReadLine();
				string[] charArr = Regex.Split(line, string.Empty);
				Stack p = new Stack(charArr.Length);
				string aux = string.Empty;
				for (int i = 0; i < charArr.Length; i++)
				{
					if (aux != charArr[i])
					{
						aux = charArr[i];

						p.Push(charArr[i]);
					}
					else
					{
						aux = charArr[i];

					}
				}

				p.PrintStack();

			}
		}

		public void Examen1Colas()
		{
			// numero de casos de prueba, solo lo capturo para cumplir con el dato de entrada.
			int n = Convert.ToInt32(Console.ReadLine());
			string line = "8 9 6 7 7 7 6 9 8 10";
			string[] edadMorsas = line.Split(' '); // Console.ReadLine().Split(' ');
			string resultado = string.Empty;
			for (int i = 0; i < edadMorsas.Length; i++)
			{
				int valorMenor = Convert.ToInt32(edadMorsas[i]);
				int contarHastaMenor = 0;
				int index = 0;
				for (int k = i + 1; k < edadMorsas.Length; k++)
				{
					index++;
					if (Convert.ToInt32(edadMorsas[k]) <= valorMenor && valorMenor != Convert.ToInt32(edadMorsas[k]))
					{
						contarHastaMenor = index;
						valorMenor = Convert.ToInt32(edadMorsas[k]);
					}
				}

				if (contarHastaMenor > 0)
				{
					contarHastaMenor--;
				}
				else
				{
					contarHastaMenor--;
				}

				resultado += contarHastaMenor + " ";
			}
			Console.WriteLine(resultado);
		}

		public void MostrarResultado(Queue colaMostrar)
		{
				
		}

		public void CrearEjercicioQuiz()
		{
			int t = Convert.ToInt32(Console.ReadLine());
			while (t > 0)
			{
				vector = Console.ReadLine().Split(' ');
				for (int i = 0; i < vector.Length; i++)
				{
					for (int k = 0; k < vector.Length - 1; k++)
					{
						if (int.Parse(vector[k]) > int.Parse(vector[k + 1]))
						{
							string aux = vector[k + 1];
							vector[k + 1] = vector[k];
							vector[k] = aux;
						}
					}
				}
				t--;
				Console.WriteLine(vector[1]);
			}
		}

		public void TestLocal()
		{
			string[] lineas = File.ReadAllLines(rutaArchivoPruebas);
			if (lineas != null && lineas.Length > 0)
			{
				int index = 0;
				int t = Convert.ToInt32(lineas[index]);
				while (t > 0)
				{
					t--;
					index++;
					string[] vector = lineas[index].Split(' ');

					for (int i = 0; i < vector.Length; i = i + 2)
					{
						int pies = int.Parse(vector[i]) * 12;
						int suma = pies + int.Parse(vector[i + 1]);
						//	if (suma > mayor)
						//	{
						//		mayor = suma;
						//	}
						//}

						//Console.WriteLine(mayor);

					}
				}
			}

		}



		public class Stack
		{
			private readonly string[] ele;
			private int top;
			private readonly int max;
			public Stack(int size)
			{
				ele = new string[size];//Maximum size of Stack 
				top = -1;
				max = size;
			}

			public void Push(string item)
			{
				if (top == max - 1)
				{
					Console.WriteLine("Stack Overflow");
					return;
				}
				else
				{
					ele[++top] = item;
				}
			}

			public string Pop()
			{
				if (top == -1)
				{
					Console.WriteLine("Stack is Empty");
					return "-1";
				}
				else
				{
					Console.WriteLine("{0} popped from stack ", ele[top]);
					return ele[top--];
				}
			}

			public void PrintStack()
			{
				if (top == -1)
				{
					Console.WriteLine("Stack is Empty");
					return;
				}
				else
				{
					string resultado = string.Empty;
					for (int i = 0; i <= top; i++)
					{
						resultado += ele[i];
					}
					//Console.WriteLine("{0} pushed into stack", ele[i]);
					Console.WriteLine(resultado);
				}
			}
		}

		public class Queue
		{
			private readonly int[] ele;
			private int front;
			private int rear;
			private readonly int max;

			public Queue(int size)
			{
				ele = new int[size];
				front = 0;
				rear = -1;
				max = size;
			}

			// Function to add an item to the queue.  
			// It changes rear and size 
			public void Enqueue(int item)
			{
				if (rear == max - 1)
				{
					Console.WriteLine("Queue Overflow");
					return;
				}
				else
				{
					ele[++rear] = item;
				}

			}

			// Function to remove an item from queue.  
			// It changes front and size 
			public int Dequeue()
			{
				if (front == rear + 1)
				{
					Console.WriteLine("Queue is Empty");
					return -1;
				}
				else
				{
					Console.WriteLine(ele[front] + " dequeued from queue");
					int p = ele[front++];
					Console.WriteLine();
					Console.WriteLine("Front item is {0}", ele[front]);
					Console.WriteLine("Rear item is {0} ", ele[rear]);
					return p;
				}

			}

			// Function to print queue.  
			public void PrintQueue()
			{
				if (front == rear + 1)
				{
					Console.WriteLine("Queue is Empty");
					return;
				}
				else
				{
					for (int i = front; i <= rear; i++)
					{
						Console.WriteLine(ele[i] + " enqueued to queue");
					}
				}

			}
		}
	}
}


