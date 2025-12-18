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

namespace FinanceCloud;

public partial class ExpenseWindow : Window
{
    private FirestoreService _service;

    public ExpenseWindow()
    {
        InitializeComponent();
        _service = new FirestoreService();
        LoadExpenses();
    }

    private async void AddBtn_Click(object sender, RoutedEventArgs e)
    {
        var localDate = DatePicker.SelectedDate ?? DateTime.Today;

        var expense = new Expense
        {
            Amount = double.Parse(AmountBox.Text),
            Category = CategoryBox.Text,
            Description = DescriptionBox.Text,
            Date = DateTime.SpecifyKind(localDate, DateTimeKind.Utc)
        };

        await _service.AddExpense(expense);
        LoadExpenses();
    }

    private async void LoadExpenses()
    {
        var list = await _service.GetExpenses();
        ExpensesGrid.ItemsSource = list;
    }

    private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        string expenseId = button.Tag.ToString();

        var result = MessageBox.Show(
            "Ви впевнені, що хочете видалити цю витрату?",
            "Підтвердження",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (result != MessageBoxResult.Yes)
            return;

        await _service.DeleteExpense(expenseId);
        LoadExpenses();
    }
}