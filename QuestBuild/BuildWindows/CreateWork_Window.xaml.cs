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

namespace QuestBuild.BuildWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateWork_Window.xaml
    /// </summary>
    public partial class CreateWork_Window : Window
    {
        List<string> tipVoprosov = new List<string>();
        List<int> chisloVoprosovTipa = new List<int>();

        public CreateWork_Window()
        {
            InitializeComponent();
            LoadSomeComboBoxes();
        }

        private void Button_AddVidRaboti_Click(object sender, RoutedEventArgs e)
        {
            Window addVid = new AddVidRaboti();
            addVid.Show();
        }

        private void Button_AddVopros_Click(object sender, RoutedEventArgs e)
        {
            if((Cb_TipVoprosov.Text != string.Empty) && (TextBox_KolvoVoprosov.Text != string.Empty))
            {
                List<int> summaVoprosov = GetListOf.IdVoprosov(Cb_TipVoprosov.Text);
                if (summaVoprosov.Count >= Convert.ToInt32(TextBox_KolvoVoprosov.Text))
                {
                    TextBox_Itog.AppendText("\n" + Cb_TipVoprosov.Text + "                                  " + TextBox_KolvoVoprosov.Text);
                    tipVoprosov.Add(Cb_TipVoprosov.Text);
                    chisloVoprosovTipa.Add(Convert.ToInt32(TextBox_KolvoVoprosov.Text));
                }
                else
                {
                    TextBox_KolvoVoprosov.Clear();
                    MessageBox.Show("Количество вопросов данного типа равно: " + summaVoprosov.Count);
                }
            }
        }

        private void Button_Gotovo_Click(object sender, RoutedEventArgs e)
        {
            if(Proverka() == true)
            {
                ZadanieForWord zadanieForWord = new ZadanieForWord(Cb_Prepodavatel.Text,
                    Cb_Groups.Text, Cb_Subject.Text, Cb_Theme.Text, Cb_VidRaboti.Text, TextBox_Path.Text,
                    Convert.ToInt32(TextBox_MaxBall.Text), Convert.ToDateTime(Dp_DataVidachi.Text), 
                    Convert.ToDateTime(Dp_DataSdachi.Text), tipVoprosov, chisloVoprosovTipa);
            }
        }

        private void Cb_Subject_DropDownClosed(object sender, EventArgs e)
        {
            if(Cb_Subject.Text != string.Empty)
            {
                Cb_Theme.ItemsSource = GetListOf.Tema(Cb_Subject.Text);
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadSomeComboBoxes();
        }

        private void LoadSomeComboBoxes()
        {
            Cb_Subject.ItemsSource = GetListOf.Predmet();
            Cb_VidRaboti.ItemsSource = GetListOf.VidRabot();
            Cb_TipVoprosov.ItemsSource = GetListOf.TipVoprosa();
            Cb_Prepodavatel.ItemsSource = GetListOf.Author();
            List<string> listOfGroups = new List<string>();
            foreach (var gr in GetListOf.Group())
            {
                string groupForCb = Convert.ToString(gr).Insert(1, " - ");
                listOfGroups.Add(groupForCb);
            }
            Cb_Groups.ItemsSource = listOfGroups;

            string content = "Путь для\nсохранения \nдокументов:";
            Label_Path.Content = content;
        }

        private void Button_ClearTbItog_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Itog.Clear();
            TextBox_Itog.AppendText("Тип вопроса:                   Число вопросов:");
        }

        private bool Proverka()
        {
            if((Cb_Subject.Text != string.Empty) && (Cb_Groups.Text != string.Empty) &&
                (Cb_VidRaboti.Text != string.Empty) && (Cb_Theme.Text != string.Empty) &&
                (Cb_Prepodavatel.Text != string.Empty) && (Dp_DataVidachi.Text != string.Empty) &&
                (Dp_DataSdachi.Text != string.Empty) && (TextBox_MaxBall.Text != string.Empty) &&
                (chisloVoprosovTipa.Count != 0) && (TextBox_Path.Text != string.Empty))
            {
                if (Convert.ToDateTime(Dp_DataVidachi.Text) <= Convert.ToDateTime(Dp_DataSdachi.Text))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Дата сдачи задания должна быть \nбоьше либо равна дате \nвыдачи задания.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены.");
                return false;
            }
        }

        private void Button_Path_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            TextBox_Path.Text = dialog.SelectedPath;
        }
    }
}
