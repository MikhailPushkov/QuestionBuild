using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuestBuild
{
    class WorkWithExcel
    {
        private Excel.Application _application = null;
        private Excel.Workbook _workBook = null;
        private Excel.Worksheet _workSheet = null;
        private string fileName;

        public WorkWithExcel(string fileName)
        {
            this.fileName = fileName;
            _application = new Excel.Application();
            _workBook = _application.Workbooks.Open(fileName);
            _workSheet = (Excel.Worksheet)_workBook.Worksheets.get_Item(1);
        }

        public void AddStudents()
        {
            int usedRowsNum = _workSheet.UsedRange.Rows.Count;

            for(int i = 2; i <= usedRowsNum; i++)
            {
                Students student = new Students();
                string[] fio;
                Int32 selectedGroup;
                Int32 group;

                Excel.Range cellRange = (Excel.Range)_workSheet.Cells[i, 1];
                fio = cellRange.Value.ToString().Split(' ');
                
                cellRange = (Excel.Range)_workSheet.Cells[i, 2];
                selectedGroup = Convert.ToInt32(cellRange.Value.Remove(1, 3));
                
                student.Surname = fio[0];
                student.Name = fio[1];
                student.Otchestvo = fio[2];

                using (QuestBuildEntities context = new QuestBuildEntities())
                {
                    try
                    {
                        group = (from gr in context.Groups
                                       where gr.Number_of_group == selectedGroup
                                       select gr.ID_Group).First();
                    }
                    catch
                    {
                        Groups newGroup = new Groups();
                        newGroup.Number_of_group = selectedGroup;
                        context.Groups.Add(newGroup);
                        context.SaveChanges();

                        group = (from gr in context.Groups
                                       where gr.Number_of_group == selectedGroup
                                       select gr.ID_Group).First();

                    }
                    student.ID_Group = group;
                }

                using (QuestBuildEntities context = new QuestBuildEntities())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
            }

            MessageBox.Show("Студенты успешно добавлены");
            Close();
        }

        public void Close()
        {
            _workBook.Close(false);

            _application.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(_application);

            _application = null;
            _workBook = null;
            _workSheet = null;

            System.GC.Collect();
        }


    }
}
