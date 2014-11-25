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
    /// Логика взаимодействия для AddKafedra.xaml
    /// </summary>
    public partial class AddKafedra : Window
    {
        Kafedra kafedra = new Kafedra();
        public AddKafedra()
        {
            InitializeComponent();
            LoadFakultet();
        }

        private void Button_SaveKafedra_Click(object sender, RoutedEventArgs e)
        {
            if((TextBox_Kafedra.Text != string.Empty) && (Cb_Fakultet.Text != string.Empty))
            {
                kafedra.Nazvanie_Kafedri = TextBox_Kafedra.Text;
                AddItem.Kafedra(kafedra);
                MessageBox.Show("Кафедра успешно добавлена.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поле.");
            }
        }

        private void Button_AddFakultet_Click(object sender, RoutedEventArgs e)
        {
            Window fakultet = new AddFakultet();
            fakultet.Show();
        }

        private void LoadFakultet()
        {
            Cb_Fakultet.ItemsSource = GetListOf.Fakultet();
        }

        private void Cb_Fakultet_DropDownClosed(object sender, EventArgs e)
        {
            if(Cb_Fakultet.Text != string.Empty)
            {
                kafedra.ID_Faculteta = GetId.Fakultet(Cb_Fakultet.Text);
            }
        }
    }
}
