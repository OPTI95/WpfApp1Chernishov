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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListTovar.xaml
    /// </summary>
    public partial class ListTovar : Window
    {
        private List<Product> products;

        public ListTovar()
        {
            InitializeComponent();
            LoadProducts();
            PopulateManufacturerComboBox();
        }
        private void LoadProducts()
        {
            // Загрузка товаров из базы данных или другого источника
            // Пример загрузки данных для демонстрации
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Category = "Category 1", Quantity = 10, Unit = "kg", Manufacturer = "Manufacturer A", Price = 10.99m, InStock = true },
                new Product { Id = 2, Name = "Product 2", Category = "Category 2", Quantity = 5, Unit = "pcs", Manufacturer = "Manufacturer B", Price = 5.49m, InStock = false },
                // Добавьте остальные товары
            };

            RefreshListView();
        }

        private void RefreshListView()
        {
            // Отображение товаров в ListView
            productsListView.ItemsSource = products;
        }

        private void PopulateManufacturerComboBox()
        {
            // Заполнение выпадающего списка производителей
            var manufacturers = products.Select(p => p.Manufacturer).Distinct().ToList();
            manufacturers.Insert(0, "All Manufacturers");
            manufacturerComboBox.ItemsSource = manufacturers;
            manufacturerComboBox.SelectedIndex = 0;
        }

        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            // Логика поиска товаров
            string searchText = searchTextBox.Text.ToLower();
            productsListView.ItemsSource = products.Where(p =>
                p.Name.ToLower().Contains(searchText) ||
                p.Category.ToLower().Contains(searchText) ||
                p.Manufacturer.ToLower().Contains(searchText));
        }

        private void ManufacturerComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Логика фильтрации по производителю
            string selectedManufacturer = manufacturerComboBox.SelectedItem as string;
            if (selectedManufacturer == "All Manufacturers")
            {
                RefreshListView();
            }
            else
            {
                productsListView.ItemsSource = products.Where(p => p.Manufacturer == selectedManufacturer);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика удаления товара
            Product selectedProduct = productsListView.SelectedItem as Product;
            if (selectedProduct != null)
            {
                // Реализуйте проверку наличия товара в заказах и дополнительных товарах перед удалением
                products.Remove(selectedProduct);
                RefreshListView();
            }
            else
            {
                MessageBox.Show("Please select a product to remove.");
            }
        }
    }
}

