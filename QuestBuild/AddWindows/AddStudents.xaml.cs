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
    /// Логика взаимодействия для AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Window
    {
        Students student = new Students();
        int change = 0;
        string nameOfStudent;

        public AddStudents()
        {
            InitializeComponent();
            LoadGroups();
        }

        public AddStudents(string student, string group)
        {
            InitializeComponent();
            LoadGroups();
            Cb_Groups.Text = group;
            string[] fioOfStudent = student.Split(' ');
            TextBox_Name.Text = fioOfStudent[1];
            TextBox_Surname.Text = fioOfStudent[0];
            TextBox_Otchestvo.Text = fioOfStudent[2];
            nameOfStudent = student;
            change = 1;
        }

        private void Button_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            Window addGroup = new AddGroup();
            addGroup.Show();
        }

        private void Button_SaveStudent_Click(object sender, RoutedEventArgs e)
        {
            if((TextBox_Surname.Text != string.Empty) && (TextBox_Name.Text != string.Empty) && 
                (TextBox_Otchestvo.Text != string.Empty) && (Cb_Groups.Text != string.Empty))
            {
                Int32 selectedGroup = Convert.ToInt32(Cb_Groups.Text.Remove(1, 3));
                student.ID_Group = GetId.Group(selectedGroup);
                student.Surname = TextBox_Surname.Text;
                student.Name = TextBox_Name.Text;
                student.Otchestvo = TextBox_Otchestvo.Text;
                if (change == 0)
                {
                    AddItem.Student(student);
                    MessageBox.Show("Студент успешно добавлен.");
                }
                else
                {
                    student.ID_Student = GetId.Student(nameOfStudent);
                    AddItem.ChangeStudent(student);
                    MessageBox.Show("Студент успешно изменен");
                }
                TextBox_Surname.Clear();
                TextBox_Name.Clear();
                TextBox_Otchestvo.Clear();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены.");
            }
        }

        private void LoadGroups()
        {
            List<string> groups = GetListOf.Group();
            List<String> listGroups = new List<string>();
            foreach(var gr in groups)
            {
               string groupForAddInComboBox = Convert.ToString(gr).Insert(1," - ");
               listGroups.Add(groupForAddInComboBox);
            }
            Cb_Groups.ItemsSource = listGroups;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void Button_Import_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Excel|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                WorkWithExcel workWithExcel = new WorkWithExcel(openFileDialog.FileName);
                workWithExcel.AddStudents();
            }
            
        }

    }
}
