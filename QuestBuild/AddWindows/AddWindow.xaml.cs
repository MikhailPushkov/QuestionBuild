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
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using QuestBuild.AddWindows;
using QuestBuild.DataAccess;
using QuestBuild.ShowWindows;

namespace QuestBuild
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Vopros vop = new Vopros();
        int change = 0;
        
        public AddWindow()
        {
            InitializeComponent();
            LoadSomeComboBoxes();
        }
        public AddWindow(DataForGridOfQuestions data, string predmet)
        {
            InitializeComponent();
            change = 1;
            LoadSomeComboBoxes();
            LoadOtherData(data, predmet);
        }

        private void Button_AddSubject_Click(object sender, RoutedEventArgs e)
        {
            Window AddSubject_Window = new AddSubject();
            AddSubject_Window.Show();
        }

        private void Button_AddTheme_Click(object sender, RoutedEventArgs e)
        {
            Window AddTheme_Window = new AddTheme();
            AddTheme_Window.Show();
        }

        private void Button_AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            Window AddAuthor_Window = new AddAuthor();
            AddAuthor_Window.Show();
        }

        private void Button_AddTip_Click(object sender, RoutedEventArgs e)
        {
            Window tip = new AddTip();
            tip.Show();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (Proverka() == true)
            {
                Send();
                if(change == 0)
                {
                    MessageBox.Show("Вопрос успешно добавлен.");
                    ClearWindow();
                }
                else
                {
                    MessageBox.Show("Вопрос успешно изменен");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Не все необходимые поля заполнены.");
            }
        }

        private void Cb_Subject_DropDownClosed(object sender, EventArgs e)
        {
            Cb_Theme.ItemsSource = GetListOf.Tema(Cb_Subject.Text);
        }

        private void Send()
        {
            vop.Tekst_Voprosa = TextBox_Quest.Text;
            vop.ID_Prepodavatelya = GetId.Prepodavatel(Cb_Author.Text);
            vop.ID_Tipa = GetId.Tip(Cb_Tip.Text);
            vop.ID_Temi = GetId.Theme(Cb_Theme.Text);
            switch (Cb_Slozhnost.Text)
            {
                case "Низкая":
                    vop.Stoimost_Voprosa = 1;
                    break;
                case "Средняя":
                    vop.Stoimost_Voprosa = 2;
                    break;
                case "Высокая":
                    vop.Stoimost_Voprosa = 3;
                    break;
            }

            if(change == 0)
            {
                AddItem.Vopros(vop);
            }
            else
            {
                AddItem.ChangedVopros(vop);
            }

            if((TextBox_Answer1.Text != string.Empty) || (TextBox_Answer2.Text !=string.Empty) ||
                (TextBox_Answer3.Text != string.Empty) || (TextBox_Answer4.Text != string.Empty))
            {
                AddOtvet();
            }
        }

        private bool Proverka()
        {
            if ((Cb_Author.Text != string.Empty) && 
                (Cb_Subject.Text != string.Empty) && 
                (Cb_Theme.Text != string.Empty) &&
                (Cb_Slozhnost.Text != string.Empty) &&
                (TextBox_Quest.Text != string.Empty))
            return true;
            else return false;
        }

        private void ClearWindow()
        {
            
            TextBox_Quest.Clear();
            TextBox_Answer1.Clear();
            TextBox_Answer2.Clear();
            TextBox_Answer3.Clear();
            TextBox_Answer4.Clear();
            CheckBox_Answer1.IsChecked = false;
            CheckBox_Answer2.IsChecked = false;
            CheckBox_Answer3.IsChecked = false;
            CheckBox_Answer4.IsChecked = false;
        }

        private void AddOtvet()
        {
            if((CheckBox_Answer1.IsChecked == false) && (CheckBox_Answer2.IsChecked == false) &&
                (CheckBox_Answer3.IsChecked == false) && (CheckBox_Answer4.IsChecked == false))
            {
                MessageBox.Show("Хотя бы один ответ \nдолжен быть правильным");
            }
            else
            {
                Int32 idVoprosa = GetId.Vopros();
  
                if(TextBox_Answer1.Text != string.Empty)
                {
                    Otvet answer1 = new Otvet();
                    answer1.Tekst_otveta = TextBox_Answer1.Text;
                    answer1.Pravilnost = CheckBox_Answer1.IsChecked;
                    if(change == 0)
                    {
                        answer1.ID_Voprosa = idVoprosa;
                        AddItem.Answer(answer1);
                    }
                    else
                    {
                        answer1.ID_Voprosa = vop.ID_Voprosa;
                        AddItem.ChangedAnswer(answer1, 1);
                    }
                }

                if (TextBox_Answer2.Text != string.Empty)
                {
                    Otvet answer2 = new Otvet();
                    answer2.Tekst_otveta = TextBox_Answer2.Text;
                    answer2.Pravilnost = CheckBox_Answer2.IsChecked;
                    if (change == 0)
                    {
                        answer2.ID_Voprosa = idVoprosa;
                        AddItem.Answer(answer2);
                    }
                    else
                    {
                        answer2.ID_Voprosa = vop.ID_Voprosa;
                        AddItem.ChangedAnswer(answer2, 2);
                    }
                }

                if (TextBox_Answer3.Text != string.Empty)
                {
                    Otvet answer3 = new Otvet();
                    answer3.Tekst_otveta = TextBox_Answer3.Text;
                    answer3.Pravilnost = CheckBox_Answer3.IsChecked;
                    if (change == 0)
                    {
                        answer3.ID_Voprosa = idVoprosa;
                        AddItem.Answer(answer3);
                    }
                    else
                    {
                        answer3.ID_Voprosa = vop.ID_Voprosa;
                        AddItem.ChangedAnswer(answer3, 3);
                    }
                }

                if (TextBox_Answer4.Text != string.Empty)
                {
                    Otvet answer4 = new Otvet();
                    answer4.Tekst_otveta = TextBox_Answer4.Text;
                    answer4.Pravilnost = CheckBox_Answer4.IsChecked;
                    if (change == 0)
                    {
                        answer4.ID_Voprosa = idVoprosa;
                        AddItem.Answer(answer4);
                    }
                    else
                    {
                        answer4.ID_Voprosa = vop.ID_Voprosa;
                        AddItem.ChangedAnswer(answer4, 4);
                    }
                }
            }
        }

        private void LoadSomeComboBoxes()
        {
            Cb_Subject.ItemsSource = GetListOf.Predmet();
            Cb_Author.ItemsSource = GetListOf.Author();
            Cb_Tip.ItemsSource = GetListOf.TipVoprosa();
            List<string> slozhnost = new List<string>();
            slozhnost.Add("Низкая");
            slozhnost.Add("Средняя");
            slozhnost.Add("Высокая");
            Cb_Slozhnost.ItemsSource = slozhnost;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadSomeComboBoxes();
        }

        private void LoadOtherData(DataForGridOfQuestions data, string predmet)
        {
            Cb_Author.Text = data.prepodavatel;
            Cb_Tip.Text = data.tipVoprosa;
            Cb_Subject.Text = predmet;
            Cb_Theme.ItemsSource = GetListOf.Tema(predmet);
            Cb_Theme.Text = data.tema;
            Cb_Slozhnost.Text = data.slozhnost;
            TextBox_Quest.Text = data.vopros;
            GetAnswers(data);
            vop.ID_Voprosa = data.idVoprosa;
        }

        private void GetAnswers(DataForGridOfQuestions data)
        {
            if (data.answers != string.Empty)
            {
                List<string> answers = GetListOf.Answers(data.idVoprosa);
                switch (answers.Count)
                {
                    case 1:
                        TextBox_Answer1.Text = answers[0];
                        break;
                    case 2:
                        TextBox_Answer1.Text = answers[0];
                        TextBox_Answer2.Text = answers[1];
                        break;
                    case 3:
                        TextBox_Answer1.Text = answers[0];
                        TextBox_Answer2.Text = answers[1];
                        TextBox_Answer3.Text = answers[2];
                        break;
                    case 4:
                        TextBox_Answer1.Text = answers[0];
                        TextBox_Answer2.Text = answers[1];
                        TextBox_Answer3.Text = answers[2];
                        TextBox_Answer4.Text = answers[3];
                        break;
                }
                int i = 1;
                foreach (var answer in answers)
                {
                    if (GetItem.RightAnswer(data.idVoprosa, answer) == true)
                    {
                        switch (i)
                        {
                            case 1: CheckBox_Answer1.IsChecked = true;
                                break;
                            case 2: CheckBox_Answer2.IsChecked = true;
                                break;
                            case 3: CheckBox_Answer3.IsChecked = true;
                                break;
                            case 4: CheckBox_Answer4.IsChecked = true;
                                break;
                        }
                    }
                    i += 1;
                }
            }
        }

        private void Button_ImportFromExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
