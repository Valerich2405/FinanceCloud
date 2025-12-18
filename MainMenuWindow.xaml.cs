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
using System.Windows.Shapes;

namespace FinanceCloud
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void Expenses_Click(object sender, RoutedEventArgs e)
        {
            var window = new ExpenseWindow();
            window.Show();
            this.Close();
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            var window = new IncomeWindow();
            window.Show();
            this.Close();
        }
    }
}
