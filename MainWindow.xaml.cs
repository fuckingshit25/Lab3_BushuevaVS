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

namespace Лаб3
{
    public partial class MainWindow : Window
    {
        static TriangleDBEntities triangleDBEntities = new TriangleDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            TrianglesGrid.ItemsSource = DBcontroller.triangles;
        }

        public void Add(object sender, RoutedEventArgs e)
        {
            if((A.Text!=null)&&(B.Text!=null)&&(C.Text!=null))
            {
                DBcontroller.AddDataToDB(A.Text, B.Text, C.Text);
                MessageBox.Show("Треугольник добавлен");
                TrianglesGrid.ItemsSource = DBcontroller.triangles;
            }
            else
            {
                MessageBox.Show("Вы не заполнили все необходимые данные!");
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            Triangle triangle = TrianglesGrid.SelectedItem as Triangle;
            if (triangle==null)
            {
                MessageBox.Show("Вы не выбрали треугольник!");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите удалить?", "Удаление треугольника", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBcontroller.RemoveDataToDB(triangle.ID);
                    MessageBox.Show("Треугольник удалён!");
                    TrianglesGrid.ItemsSource = DBcontroller.triangles;
                }
            }
        }
    }
}
