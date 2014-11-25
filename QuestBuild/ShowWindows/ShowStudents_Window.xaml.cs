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

namespace QuestBuild.ShowWindows
{
    /// <summary>
    /// Логика взаимодействия для ShowStudents_Window.xaml
    /// </summary>
    public partial class ShowStudents_Window : Window
    {
        public ShowStudents_Window()
        {
            InitializeComponent();
            LoadGroups();
        }

        private void Cb_Group_DropDownClosed(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGroups()
        {
            List<string> groups = GetListOf.Group();
            List<String> listGroups = new List<string>();
            foreach (var gr in groups)
            {
                string groupForAddInComboBox = Convert.ToString(gr).Insert(1, " - ");
                listGroups.Add(groupForAddInComboBox);
            }
            Cb_Group.ItemsSource = listGroups;
        }

        private void Button_AddStudents_Click(object sender, RoutedEventArgs e)
        {
            Window addStudents = new AddStudents();
            addStudents.Show();
        }

        private void LoadGrid()
        {
            if (Cb_Group.Text != string.Empty)
            {
                int numberOfGrupp = Convert.ToInt32(Cb_Group.Text.Remove(1, 3));
                ClassForGrid data = new ClassForGrid(numberOfGrupp);
                Dg_Students.ItemsSource = data.GetDataOfStudents();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            if (Dg_Students.SelectedItem != null)
            {
                Window changeStudent = new AddStudents(GetStudent(), Cb_Group.Text);
                changeStudent.Show();
            }
            else
            {
                MessageBox.Show("Ни один студент не выбран");
            }
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Dg_Students.SelectedItem != null)
            {
                RemoveItem.Student(GetStudent());
            }
            else
            {
                MessageBox.Show("Ни один студент не выбран");
            }
        }

        private string GetStudent()
        {
                DataForGridOfStudents newStudent = (DataForGridOfStudents)Dg_Students.SelectedItem;
                return newStudent.fio;
        }
    }
}
