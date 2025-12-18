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

    public partial class IncomeWindow : Window
    {
        private FirestoreService _service;

        public IncomeWindow()
        {
            InitializeComponent();
            _service = new FirestoreService();
            LoadIncomes();
        }

        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var income = new Income
            {
                Amount = double.Parse(AmountBox.Text),
                Source = SourceBox.Text,
                Description = DescriptionBox.Text,
                Date = DatePicker.SelectedDate ?? DateTime.Today
            };

            await _service.AddIncome(income);
            LoadIncomes();
        }

        private async void LoadIncomes()
        {
            IncomeGrid.ItemsSource = await _service.GetIncomes();
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var id = (sender as Button).Tag.ToString();

            var result = MessageBox.Show(
                "Видалити цей дохід?",
                "Підтвердження",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            await _service.DeleteIncome(id);
            LoadIncomes();
        }
    }
}
