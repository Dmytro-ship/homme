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

namespace Pract3._2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Setter.Text = "Метал";
            FirstB.IsChecked = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double material = 0;
            switch (Setter.Text)
            {
                case "Метал": material = 0.05; break;
                case "Дерево": material = 0.25; break;
                case "Металопластик": material = 0.15; break;
            }
            Result.Content = "Вартість : "
                + ((Convert.ToDouble(FirstT.Text)
                * Convert.ToDouble(SecondT.Text))
                * (material
                + (0.05 * Convert.ToDouble((bool)SecondB.IsChecked)))
                + (35 * Convert.ToDouble((bool)Active.IsChecked)))
                + " грн.";
        }
    }
}
