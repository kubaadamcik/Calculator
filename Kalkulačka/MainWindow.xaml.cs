using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulačka
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public MainWindow()
		{
			DataContext = this;
			InitializeComponent();
		}

		private int? _number;

		public event PropertyChangedEventHandler? PropertyChanged;

		public int? Number
		{
			get { return _number; }
			set 
			{
				_number = value;

				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button? tlacitko = sender as Button;
			int cislice;

			if (tlacitko != null)
			{
				if (int.TryParse(tlacitko.Content.ToString(), out cislice))
				{
					AddNumber(cislice);
				}
			}
		}

		private void AddNumber(int number)
		{
			if (Number == null)
			{
				Number = number;
			}
			else
			{
				Number = int.Parse(Number.ToString() + number.ToString());
			}
		}
	}
}