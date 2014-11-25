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
    /// Логика взаимодействия для AddTip.xaml
    /// </summary>
    public partial class AddTip : Window
    {
        public AddTip()
        {
            InitializeComponent();
        }

        private void Button_SaveTip_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox_Tip.Text != string.Empty)
            {
                Tip_Voprosa tip = new Tip_Voprosa();
                tip.Tip = TextBox_Tip.Text;
                AddItem.TipVoprosa(tip);
                MessageBox.Show("Новый тип вопроса \nуспешно добавлен.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поле.");
            }
        }
    }
}
