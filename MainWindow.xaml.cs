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

namespace Практическая_работа_1_часть_1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        public void calculate_click(object sender, RoutedEventArgs e)
        {
            if (Radio1.IsChecked == true)
            {
                if (forx.Text != "" && fory.Text != "")
                {
                    int forx_num = Convert.ToInt32(forx.Text);
                    int fory_num = Convert.ToInt32(fory.Text);

                    double f_x = Math.Sin(forx_num);

                    double b;

                    if (fory_num == 0)
                    {
                        b = 0;
                    }
                    else if (forx_num == 0)
                    {
                        b = Math.Pow(f_x * f_x + fory_num, 3);
                    }
                    else if (fory_num > 0)
                    {
                        b = Math.Log(f_x) + Math.Pow(f_x * f_x + fory_num, 3);
                    }
                    else
                    {
                        b = Math.Log(Math.Abs(f_x / fory_num)) + Math.Pow(f_x + fory_num, 3);
                    }

                    double sh_b = Math.Sinh(b);

                    answer.Text = Convert.ToString(sh_b);
                }

                else
                {
                    answer.Text = "Некорректный ввод";
                }
            }

            else if (Radio2.IsChecked == true)
            {
                if (forx.Text != "" && fory.Text != "")
                {
                    int forx_num = Convert.ToInt32(forx.Text);
                    int fory_num = Convert.ToInt32(fory.Text);

                    double f_x = Math.Sin(forx_num);

                    double b = (fory_num == 0) ? 0 :
                               (forx_num == 0) ? Math.Pow(f_x * f_x + fory_num, 3) :
                               (fory_num > 0) ? Math.Log(f_x) + Math.Pow(f_x * f_x + fory_num, 3) :
                                                 Math.Log(Math.Abs(f_x / fory_num)) + Math.Pow(f_x + fory_num, 3);

                    double b_squared = b * b;

                    answer.Text = Convert.ToString(b_squared);

                }

                else
                {
                    answer.Text = "Некорректный ввод";
                }
            }

            else if (Radio3.IsChecked == true)
            {
                if (forx.Text != "" && fory.Text != "")
                {
                    int forx_num = Convert.ToInt32(forx.Text);
                    int fory_num = Convert.ToInt32(fory.Text);

                    double f_x = Math.Sin(forx_num); // Пример: f(x) = sin(x)

                    // Вычисление значения b
                    double b = (fory_num == 0) ? 0 :
                               (forx_num == 0) ? Math.Pow(f_x * f_x + fory_num, 3) :
                               (fory_num > 0) ? Math.Log(f_x) + Math.Pow(f_x * f_x + fory_num, 3) :
                                                 Math.Log(Math.Abs(f_x / fory_num)) + Math.Pow(f_x + fory_num, 3);

                    // Вычисление экспоненты от b (e^b)
                    double exp_b = Math.Exp(b);

                    answer.Text = Convert.ToString(exp_b);
                }

                else
                {
                    answer.Text = "Некорректный ввод";
                }
            }

            else
            {
                answer.Text = "Не выбрана функция";
            }





        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            forx.Text = "";
            fory.Text = "";
            answer.Text = "";

            Radio1.IsChecked = false;
            Radio2.IsChecked = false;
            Radio3.IsChecked = false;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Отображаем MessageBox с вопросом
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите закрыть окно?", "Подтверждение закрытия", MessageBoxButton.YesNo);

            // Если пользователь выбрал "Нет", отменяем закрытие окна
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
