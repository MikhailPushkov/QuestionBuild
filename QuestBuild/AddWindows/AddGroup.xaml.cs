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
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        Groups group = new Groups();

        public AddGroup()
        {
            InitializeComponent();
        }

        private void Button_SaveGroup_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBox_Kurs.Text != string.Empty) && (TextBox_Gruppa.Text != string.Empty))
            {
                try
                {
                    Int32 numberOfGroup = Convert.ToInt32((TextBox_Kurs.Text + TextBox_Gruppa.Text));
                    group.Number_of_group = numberOfGroup;
                }
                catch
                {
                    MessageBox.Show("Введены не корректные данные.");
                    TextBox_Kurs.Clear();
                    TextBox_Gruppa.Clear();
                }
                AddItem.Group(group);
                MessageBox.Show("Группа успешно добавлена.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поля.");
            }
        }
    }
}
