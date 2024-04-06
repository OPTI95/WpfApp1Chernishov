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
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        private Product product;
        private bool isEditing;
        public ProductAddWindow()
        {
            InitializeComponent();
            if (product != null)
            {
                this.product = product;
                isEditing = true;
                LoadProductData();
            }
            else
            {
                this.product = new Product();
                isEditing = false;
            }
             void LoadProductData()
            {
                nameTextBox.Text = product.Name;
                categoryTextBox.Text = product.Category;
                quantityTextBox.Text = product.Quantity.ToString();
                priceTextBox.Text = product.Price.ToString();
            }

             void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                if (ValidateInput())
                {
                    // Заполнение объекта товара данными из полей ввода
                    product.Name = nameTextBox.Text;
                    product.Category = categoryTextBox.Text;
                    product.Quantity = int.Parse(quantityTextBox.Text);
                    product.Price = decimal.Parse(priceTextBox.Text);

                    if (isEditing)
                    {
                        // Логика для редактирования товара
                        // Например, обновление товара в базе данных
                        // ProductService.UpdateProduct(product);
                    }
                    else
                    {
                        // Логика для добавления нового товара
                        // Например, добавление товара в базу данных
                        // ProductService.AddProduct(product);
                    }

                    // Закрытие окна
                    Close();
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields with valid data.");
                }
            }

             bool ValidateInput()
            {
                // Проверка корректности введенных данных
                if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(categoryTextBox.Text) ||
                    !int.TryParse(quantityTextBox.Text, out _) ||
                    !decimal.TryParse(priceTextBox.Text, out _))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
