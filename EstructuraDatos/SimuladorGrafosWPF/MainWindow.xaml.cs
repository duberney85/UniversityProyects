using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Business business;
		public MainWindow()
		{
			InitializeComponent();
			business = new Business();
		}

		private void BtnEjercicio1_Click(object sender, RoutedEventArgs e)
		{
			//business.EjercicioPila();
			business.Examen1Colas();
		}
	}
}
