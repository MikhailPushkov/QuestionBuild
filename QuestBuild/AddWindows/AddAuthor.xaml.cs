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
    /// Логика взаимодействия для AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Window
    {
        Prepodavateli author = new Prepodavateli();

        public AddAuthor()
        {
            InitializeComponent();
            LoadKafedra();
        }

        private void Button_AddKafedra_Click(object sender, RoutedEventArgs e)
        {
            Window kafedra = new AddKafedra();
            kafedra.Show();
        }

        private void Button_SaveAuthor_Click(object sender, RoutedEventArgs e)
        {
            if(ProverkaAndAddFIO() == true)
            {
                    try
                    {
                        AddItem.Author(author);
                        MessageBox.Show("Данные о преподавателе \nуспешно добавлены.");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                    }
            }
        }

        private void LoadKafedra()
        {
            Cb_Kafedra.ItemsSource = GetListOf.Kafedra();
        }

        private void Cb_Kafedra_DropDownClosed(object sender, EventArgs e)
        {
            if(Cb_Kafedra.Text != string.Empty)
            {
                author.ID_Kafedri = GetId.Kafedra(Cb_Kafedra.Text);
            }
        }

        private bool ProverkaAndAddFIO()
        {
            if((TextBox_Surname.Text != string.Empty) && (TextBox_Name.Text != string.Empty) &&
                (TextBox_Otchestvo.Text != string.Empty) && (Cb_Kafedra.Text != string.Empty))
            {
                author.Surname = TextBox_Surname.Text;
                author.Name = TextBox_Name.Text;
                author.Otchestvo = TextBox_Otchestvo.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены.");
                return false;
            }
        }
    }
}
