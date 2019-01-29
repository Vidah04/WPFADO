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

namespace BootcampWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext _context = new MyContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Please Insert Name");
            }

            var name = NameTextBox.Text;
            Supplier supplier = new Supplier();
            supplier.name = NameTextBox.Text;
            supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
            _context.Suppliers.Add(supplier);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show("Successfuly");
                NameTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void ViewNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z .]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void NameTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           CountTextBox.Text = NameTextBox.Text.Length.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SupplierdataGrid.ItemsSource = _context.Suppliers.Where(x => x.IsDelete == false).ToList();
            SuppliercomboBox.ItemsSource = _context.Suppliers.Where(x => x.IsDelete == false).ToList();
        }
        
        private void SupplierdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = SupplierdataGrid.SelectedItem;
            NameTextBox.Text = (SupplierdataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var getSupplier = Convert.ToString(SuppliercomboBox.SelectedValue);
            //SuppliercomboBox.ItemsSource = _context.Get(getSupplier);

            //object item = SupplierdataGrid.SelectedItem;
            //SuppliercomboBox.Text = (SupplierdataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
        }

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
           if (CategorycomboBox.Text == "Id")
            {
                var getData = _context.Suppliers.Where(x => x.IsDelete == false && x.Id.ToString().Contains(CategorycomboBox.Text)).ToList();
                SupplierdataGrid.ItemsSource = getData;
            }
            else if (CategorycomboBox.Text == "Name")
            {
                SupplierdataGrid.ItemsSource = _context.Suppliers.Where(x => x.IsDelete == false && x.name.ToString().Contains(CategorycomboBox.Text)).ToList();
            }
            else
            {
                DateTimeOffset parseDate = DateTime.Parse(CategorycomboBox.Text);
                SupplierdataGrid.ItemsSource = _context.Suppliers.Where(x => x.IsDelete == false && x.JoinDate <= parseDate).ToList();
            }
            //List<string> Courses = new List<string>();

            //MyContext _context = new MyContext();
           
        }


    }
}
