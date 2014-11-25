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
using QuestBuild.AddWindows;
using QuestBuild.ShowWindows;

namespace QuestBuild.ShowQuestWindows
{
    /// <summary>
    /// Логика взаимодействия для ShowQuest_Window.xaml
    /// </summary>
    public partial class ShowQuest_Window : Window
    {
        public ShowQuest_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cb_Teacher.ItemsSource = GetListOf.Author();
            Cb_Subject.ItemsSource = GetListOf.Predmet();
        }

        private void Button_Done_Click(object sender, RoutedEventArgs e)
        {
            if((Cb_Teacher.Text != string.Empty) && (Cb_Theme.Text != string.Empty))
            {
                ClassForGrid data = new ClassForGrid(Cb_Teacher.Text, Cb_Theme.Text);
                Dg_Vopros.ItemsSource = data.GetDataOfQuestions();
            }
        }

        private void Cb_Subject_DropDownClosed(object sender, EventArgs e)
        {
            if(Cb_Subject.Text != string.Empty)
            {
                Cb_Theme.ItemsSource = GetListOf.Tema(Cb_Subject.Text);
            }
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            DataForGridOfQuestions data = (DataForGridOfQuestions)Dg_Vopros.SelectedItem;
            Window changeQuest = new AddWindow(data, Cb_Subject.Text);
            changeQuest.Show();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            DataForGridOfQuestions data = (DataForGridOfQuestions)Dg_Vopros.SelectedItem;
            try
            {
                RemoveItem.Vopros(data.idVoprosa);
                MessageBox.Show("Удаление прошло успешно");
            }
            catch
            {
                MessageBox.Show("Выбранный вопрос удалить не удалось");
            }
        }

        private void Button_AddQuest_Click(object sender, RoutedEventArgs e)
        {
            Window addQuest = new AddWindow();
            addQuest.Show();
        }
    }
}
