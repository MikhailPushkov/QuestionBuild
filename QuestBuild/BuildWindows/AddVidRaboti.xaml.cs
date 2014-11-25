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
    /// Логика взаимодействия для AddVidRaboti.xaml
    /// </summary>
    public partial class AddVidRaboti : Window
    {
        public AddVidRaboti()
        {
            InitializeComponent();
        }

        private void Button_SaveVid_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox_VidRaboti.Text != string.Empty)
            {
                Vidi_Rabot vid = new Vidi_Rabot();
                vid.Nazvanie_Vida = TextBox_VidRaboti.Text;
                AddItem.VidRaboti(vid);
                MessageBox.Show("Вид работы добавлен.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поле.");
            }
        }
    }
}
