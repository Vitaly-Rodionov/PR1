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

namespace PR1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void DelMatrixColumn(int KFunctions, int kollStolbFunctions)
        {
            DGTwoMas.Columns.RemoveAt(KFunctions);
            kollStolbFunctions = kollStolbFunctions - 1;
            if (kollStolbFunctions == 0)
            {
                tbStrok.Text = 0.ToString();
            }
            tbStolb.Text = kollStolbFunctions.ToString();
        }
        private void Task_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана вещественная матрица размерности n * m. Удалить k столбец матрицы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Programmer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Работу выполнил студент группы ИСП-32\nРодионов В.С.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        int[,] mas2;
        private void fill2_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbStrok.Text, out int kollStrok))
            {
                if (int.TryParse(tbStolb.Text, out int kollStolb))
                {
                    if (kollStrok > 0)
                    {
                        if (kollStolb > 0)
                        {
                            mas2 = new int[kollStrok, kollStolb];
                            Random random = new Random();
                            for (int i = 0; i < kollStrok; i++)
                            {
                                for (int j = 0; j < kollStolb; j++)
                                {
                                    mas2[i, j] = random.Next(-100, 100);
                                    DGTwoMas.ItemsSource = VisualArray.ToDataTable(mas2).DefaultView;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не корректно введено значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не корректно введено значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Не корректно введено кол-во столбцов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не корректно введено кол-во строк", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DGTwoMas.ItemsSource = null;
            mas2 = null;
            Kstolb.Clear();
        }

        private void DelKstolb_Click(object sender, RoutedEventArgs e)
        {
            int KollItem = DGTwoMas.Columns.Count;
            if (KollItem > 0)
            {
                if (int.TryParse(tbStolb.Text, out int kollStolb))
                {
                    if (int.TryParse(Kstolb.Text, out int K))
                    {
                        K = K - 1;
                        if (K >= 0 && K < KollItem)
                        {
                            DelMatrixColumn(K, kollStolb);
                            MessageBox.Show("Столбец матрицы успешно удалён", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Введено некорректное значение K\nВы вышли за пределы массива", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введено некорректное значение K", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Нет элементов в массисве", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Нет элементов в массисве", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}