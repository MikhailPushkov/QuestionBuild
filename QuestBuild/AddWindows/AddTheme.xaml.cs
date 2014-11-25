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
    /// Логика взаимодействия для AddTheme.xaml
    /// </summary>
    public partial class AddTheme : Window
    {
        Tema theme = new Tema();

        public AddTheme()
        {
            InitializeComponent();
            Load_Subjects();
        }

        private void Button_SaveTheme_Click(object sender, RoutedEventArgs e)
        {
            if((TextBox_Theme.Text != string.Empty) && (Cb_SubjectForAddTheme.Text != string.Empty))
            {
                theme.Nazvanie_Temi = TextBox_Theme.Text;
            }
            else
            {
                MessageBox.Show("Заполните необходимые поля!");
            }
                try
                {
                    AddItem.Tema(theme);
                    MessageBox.Show("Тема успешно добавлена.");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
        }

        private void Cb_SubjectForAddTheme_DropDownClosed(object sender, EventArgs e)
        {
            Cb_KornTheme.ItemsSource = GetListOf.Tema(Cb_SubjectForAddTheme.Text);
            theme.ID_Predmeta = GetId.Predmet(Cb_SubjectForAddTheme.Text);
        }

        private void Cb_KornTheme_DropDownClosed(object sender, EventArgs e)
        {
            if (Cb_KornTheme.Text != string.Empty)
            {
                theme.ID_Nad_Tema = GetId.Theme(Cb_KornTheme.Text);
            }
        }

        private void Load_Subjects()
        {
            Cb_SubjectForAddTheme.ItemsSource = GetListOf.Predmet();
        }
    }
}
