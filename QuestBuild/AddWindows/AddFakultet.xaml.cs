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
using QuestBuild.DataAccess;

namespace QuestBuild.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddFakultet.xaml
    /// </summary>
    public partial class AddFakultet : Window
    {
        public AddFakultet()
        {
            InitializeComponent();
        }

        private void Button_SaveFakultet_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox_Fakultet.Text != string.Empty)
            {
                Fakultet fakultet = new Fakultet();
                fakultet.Nazvanie_Fakulteta = TextBox_Fakultet.Text;
                AddItem.Fakultet(fakultet);    
                MessageBox.Show("Факультет успешно добавлен.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поле.");
            }
        }
    }
}
