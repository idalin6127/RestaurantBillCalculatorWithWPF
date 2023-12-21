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
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace LAB3
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        private const decimal TaxRate = 0.13m;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMenuItems();
            InitializeComboBoxItems();
            menuItemsDataGrid.ItemsSource = MenuItems;

            // 将下拉菜单的 SelectionChanged 事件与处理函数链接
            cmbBeverage.SelectionChanged += ComboBox_SelectionChanged;
            cmbAppetizer.SelectionChanged += ComboBox_SelectionChanged;
            cmbMainCourse.SelectionChanged += ComboBox_SelectionChanged;
            cmbDessert.SelectionChanged += ComboBox_SelectionChanged;

            // 将 DataGrid 的 CellEditEnding 事件与处理函数链接
            menuItemsDataGrid.CellEditEnding += menuItemsDataGrid_CellEditEnding;
        }

        private void InitializeMenuItems()
        {
            // 初始化菜单项数据
            MenuItems = new ObservableCollection<MenuItem>
            {
                // 请将菜单项数据添加在此处...
            new MenuItem { Name = "Soda", Category = "Beverage", Price = 1.95m, Quantity = 0 },
            new MenuItem { Name = "Tea", Category = "Beverage", Price = 1.5m, Quantity = 0 },
            new MenuItem { Name = "Coffee", Category = "Beverage", Price = 1.25m, Quantity = 0 },
            new MenuItem { Name = "Mineral Water", Category = "Beverage", Price = 2.95m, Quantity = 0 },
            new MenuItem { Name = "Juice", Category = "Beverage", Price = 2.5m, Quantity = 0 },
            new MenuItem { Name = "Milk", Category = "Beverage", Price = 1.5m, Quantity = 0 },

            new MenuItem { Name = "Buffalo Wings", Category = "Appetizer", Price = 5.95m, Quantity = 0 },
            new MenuItem { Name = "Buffalo Fingers", Category = "Appetizer", Price = 6.95m, Quantity = 0 },
            new MenuItem { Name = "Potato Skins", Category = "Appetizer", Price = 8.95m, Quantity = 0 },
            new MenuItem { Name = "Nachos", Category = "Appetizer", Price = 8.95m, Quantity = 0 },
            new MenuItem { Name = "Mushroom Caps", Category = "Appetizer", Price = 10.95m, Quantity = 0 },
            new MenuItem { Name = "Shrimp Cocktail", Category = "Appetizer", Price = 12.95m, Quantity = 0 },
            new MenuItem { Name = "Chips and Salsa", Category = "Appetizer", Price = 6.95m, Quantity = 0 },

            new MenuItem { Name = "Chicken Alfredo", Category = "Main Course", Price = 13.95m, Quantity = 0 },
            new MenuItem { Name = "Chicken Picatta", Category = "Main Course", Price = 13.95m, Quantity = 0 },
            new MenuItem { Name = "Turkey Club", Category = "Main Course", Price = 11.95m, Quantity = 0 },
            new MenuItem { Name = "Lobster Pie", Category = "Main Course", Price = 19.95m, Quantity = 0 },
            new MenuItem { Name = "Prime Rib", Category = "Main Course", Price = 20.95m, Quantity = 0 },
            new MenuItem { Name = "Shrimp Scampi", Category = "Main Course", Price = 18.95m, Quantity = 0 },
            new MenuItem { Name = "Turkey Dinner", Category = "Main Course", Price = 13.95m, Quantity = 0 },
            new MenuItem { Name = "Stuffed Chicken", Category = "Main Course", Price = 14.95m, Quantity = 0 },
            new MenuItem { Name = "Seafood Alfredo", Category = "Main Course", Price = 15.95m, Quantity = 0 },

            new MenuItem { Name = "Apple Pie", Category = "Dessert", Price = 5.95m, Quantity = 0 },
            new MenuItem { Name = "Sundae", Category = "Dessert", Price = 3.95m, Quantity = 0 },
            new MenuItem { Name = "Carrot Cake", Category = "Dessert", Price = 5.95m, Quantity = 0 },
            new MenuItem { Name = "Mud Pie", Category = "Dessert", Price = 4.95m, Quantity = 0 },
            new MenuItem { Name = "Apple Crisp", Category = "Dessert", Price = 5.95m, Quantity = 0 },
            };

            // 为每个菜单项设置类别属性
            foreach (var menuItem in MenuItems)
            {
                menuItem.Categories = new ObservableCollection<string>
                {
                    "Beverage", "Appetizer", "Main Course", "Dessert"
                };
            }
        }

        private void InitializeComboBoxItems()
        {
            Categories = new ObservableCollection<string>
            {
                "Beverage", "Appetizer", "Main Course", "Dessert"
            };

            // 设置下拉菜单的数据源
            cmbBeverage.ItemsSource = Categories;
            cmbAppetizer.ItemsSource = Categories;
            cmbMainCourse.ItemsSource = Categories;
            cmbDessert.ItemsSource = Categories;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                string selectedCategory = comboBox.SelectedItem.ToString();

                // 根据所选类别过滤菜单项
                IEnumerable<MenuItem> filteredMenuItems = MenuItems.Where(item => item.Category == selectedCategory);

                // 更新 DataGrid 中的项
                menuItemsDataGrid.ItemsSource = filteredMenuItems;

                // 设置初始数量为0并允许编辑
                foreach (var item in filteredMenuItems)
                {
                    item.Quantity = 0;
                }
            }
        }

        // 其他事件处理函数和其他方法...

        private void menuItemsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null)
                {
                    TextBox quantityTextBox = e.EditingElement as TextBox;
                    if (quantityTextBox != null)
                    {
                        int quantity;
                        if (int.TryParse(quantityTextBox.Text, out quantity))
                        {
                            if (quantity >= 0)
                            {
                                MenuItem selectedItem = grid.SelectedItem as MenuItem;
                                if (selectedItem != null)
                                {
                                    selectedItem.Quantity = quantity;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Quantity should be a positive integer.", "Invalid Quantity");
                                // Reset quantity to 0
                                quantityTextBox.Text = "0";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid integer value for Quantity.", "Invalid Input");
                            // Reset quantity to 0
                            quantityTextBox.Text = "0";
                        }
                    }
                }
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedMenuItem = menuItemsDataGrid.SelectedItem as MenuItem;
            if (selectedMenuItem != null && selectedMenuItem.Quantity > 0)
            {
                // Check if the selected item already exists in MenuItems
                MenuItem existingItem = MenuItems.FirstOrDefault(item => item.Name == selectedMenuItem.Name);

                if (existingItem != null)
                {
                    // Update the quantity if the item already exists
                    existingItem.Quantity += selectedMenuItem.Quantity;
                }
                else
                {
                    // Add the item to MenuItems if it doesn't exist
                    MenuItem newItem = new MenuItem
                    {
                        Name = selectedMenuItem.Name,
                        Category = selectedMenuItem.Category,
                        Price = selectedMenuItem.Price,
                        Quantity = selectedMenuItem.Quantity
                    };
                    MenuItems.Add(newItem);
                }
            }
        }



        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedMenuItem = menuItemsDataGrid.SelectedItem as MenuItem;
            if (selectedMenuItem != null)
            {
                // Remove the selected item from the list
                MenuItems.Remove(selectedMenuItem);
            }
        }

        private void DisplayAllBills_Click(object sender, RoutedEventArgs e)
        {
            // 获取所有数量大于零的菜单项
            IEnumerable<MenuItem> itemsToDisplay = MenuItems.Where(item => item.Quantity > 0).ToList();

            // 创建一个新的集合，用于显示
            ObservableCollection<MenuItem> displayItems = new ObservableCollection<MenuItem>(itemsToDisplay);

            // 更新 DataGrid 中的项
            menuItemsDataGrid.ItemsSource = displayItems;

            // 将 DataGrid 设置为可编辑状态
            menuItemsDataGrid.IsReadOnly = false;

            // 计算 Subtotal，并显示在对应 Label 中
            decimal subtotal = CalculateSubtotal(displayItems);
            Subtotal.Content = $"  Subtotal: {subtotal:C}";

            // 计算 Tax，并显示在对应 Label 中
            decimal tax = subtotal * TaxRate;
            Tax.Content = $"  Tax: {tax:C}";

            // 计算 Total，并显示在对应 Label 中
            decimal total = subtotal + tax;
            Total.Content = $"  Total: {total:C}";
        }

        private decimal CalculateSubtotal(IEnumerable<MenuItem> items)
        {
            decimal subtotal = 0;
            foreach (var item in items)
            {
                subtotal += item.Price * item.Quantity;
            }
            return subtotal;
        }

        private void ClearBill_Click(object sender, RoutedEventArgs e)
        {
            MenuItems.Clear();
            menuItemsDataGrid.ItemsSource = null;

            // 清空 Subtotal、Tax 和 Total 的内容
            Subtotal.Content = "Subtotal:";
            Tax.Content = "Tax:";
            Total.Content = "Total:";
        }

        private void GenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully place the order！");
        }

        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            // Open company website in Internet Explorer
            System.Diagnostics.Process.Start("iexplore", "http://www.centennialcollege.ca");
        }

        private void menuItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 处理 DataGrid 选择更改事件的代码
        }

        private void menuItemsDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
