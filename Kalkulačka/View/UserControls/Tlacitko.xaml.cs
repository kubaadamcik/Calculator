using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Kalkulačka.View.UserControls
{
	/// <summary>
	/// Interakční logika pro Tlacitko.xaml
	/// </summary>
	/// 
	public partial class Tlacitko : UserControl
	{
		public Tlacitko()
		{
			InitializeComponent();
		}

		private int _num;

		public int num
		{
			get { return _num; }
			set { _num = value; }
		}

		private void btnCislo_Click(object sender, RoutedEventArgs e)
		{

        }
    }
}
