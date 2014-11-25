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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestBuild.AddWindows;
using QuestBuild.BuildWindows;
using QuestBuild.ShowQuestWindows;
using QuestBuild.ShowWindows;

namespace QuestBuild
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddQuest_Click(object sender, RoutedEventArgs e)
        {
            Window addQuestions = new AddWindow();
            addQuestions.Show(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window students = new ShowStudents_Window();
            students.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window createWork = new CreateWork_Window();
            createWork.Show();
        }

        private void Button_ShowQ_Click(object sender, RoutedEventArgs e)
        {
            Window showQuest = new ShowQuest_Window();
            showQuest.Show();
        }
    }
}
