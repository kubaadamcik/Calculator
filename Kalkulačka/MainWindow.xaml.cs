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


		public int? Number
		{
			get { return _number; }
			set 
			{
				_number = value;

				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		private int? _firstNumber;

		private char? _currentAction;

		private bool _showingResult = false;

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
			if (Number == null || _showingResult == true)
			{
				Number = number;

				_showingResult = false;
			}
			else
			{
				Number = int.Parse(Number.ToString() + number.ToString());
			}
		}

		private void Button_Do_Action(object sender, RoutedEventArgs eventArgs)
		{
			Button? tlacitko = sender as Button;
			char action;

			if (tlacitko != null && char.TryParse(tlacitko.Content.ToString(), out action))
			{
				_currentAction = action;
				_firstNumber = Number;
				Number = null;
			}
		}

		private void Button_Calculate(object sender, RoutedEventArgs eventArgs)
		{
			Calculate(_firstNumber, Number, _currentAction);

			_firstNumber = null;
			_currentAction = null;
		}

		private void Button_Delete(object sender, RoutedEventArgs e)
		{
			Number = null;
			_firstNumber = null;
			_currentAction = null;
			_showingResult = false;
		}

		private void Calculate(int? first_number, int? second_number, char? action)
		{
			switch (action.ToString())
			{
				case "*":
					Number = first_number * second_number;

					_showingResult = true;
					break;
				case "/":
					if (second_number != 0)
					{ 
						Number = first_number / second_number;
                        _showingResult = true;
                    }
					else
					{
						MessageBox.Show("Nelze dělit nulou", "Dělení nulou", MessageBoxButton.OK, MessageBoxImage.Error);
					}

					break;
				case "+":
					Number = first_number + second_number;

					_showingResult = true;
					break;
				case "-":
					Number = first_number - second_number;

					_showingResult = true;
					break;
				default:
					MessageBox.Show("Něco se pokazilo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					break;
			}
		}
	}
}