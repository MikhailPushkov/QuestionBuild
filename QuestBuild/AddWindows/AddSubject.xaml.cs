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
    /// Логика взаимодействия для AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Window
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        private void Button_SaveSubject_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox_Subject.Text != string.Empty)
            {
               Predmet subject = new Predmet();
               subject.Nazvanie_Predmeta = TextBox_Subject.Text;
               AddItem.Subject(subject);
               MessageBox.Show("Предмет успешно добавлен.");
               this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поле.");
            }
        }
    }
}
