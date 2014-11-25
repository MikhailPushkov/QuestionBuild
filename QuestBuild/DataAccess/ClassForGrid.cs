using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestBuild.ShowWindows;

namespace QuestBuild.DataAccess
{
    class ClassForGrid
    {
        public string teacherForSerch { get; set; }
        public string tema { get; set; }
        public int numberOfGroup { get; set; }

        public ClassForGrid(string teacher, string tema)
        {
            this.teacherForSerch = teacher;
            this.tema = tema;
        }

        public ClassForGrid(int numberOfGroup)
        {
            this.numberOfGroup = numberOfGroup;
        }

        public List<DataForGridOfQuestions> GetDataOfQuestions()
        {
            int idTeacher = GetId.Prepodavatel(teacherForSerch);
            int idTheme = GetId.Theme(tema);
            List<DataForGridOfQuestions> forGridQuest = new List<DataForGridOfQuestions>();

            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                var dataForQuest = (from vop in context.Vopros
                                    where vop.ID_Prepodavatelya == idTeacher && vop.ID_Temi == idTheme
                                    select new
                                    {
                                       teacher = vop.Prepodavateli.Surname + " " + vop.Prepodavateli.Name + " " + vop.Prepodavateli.Otchestvo,
                                       tema = vop.Tema.Nazvanie_Temi,
                                       vopros = vop.Tekst_Voprosa,
                                       id = vop.ID_Voprosa,
                                       tip = vop.Tip_Voprosa.Tip,
                                       slozhnost = vop.Stoimost_Voprosa
                                    }).ToList();
                foreach(var data in dataForQuest)
                {
                    DataForGridOfQuestions forGrid = new DataForGridOfQuestions();

                    var answers = from answ in context.Otvet
                                  where answ.ID_Voprosa == data.id
                                  select new
                                  {
                                      otvet = answ.Tekst_otveta,
                                      right = answ.Pravilnost
                                  };
                    int i = 1;
                    foreach(var answer in answers)
                    {
                        forGrid.answers += "Ответ " + i + ": " + answer.otvet;
                        i += 1;
                        if(answer.right == true)
                        {
                            forGrid.answers += " - Правильный";
                        }
                        forGrid.answers += "\n";
                    }

                    switch (data.slozhnost)
                    {
                        case 1:
                            forGrid.slozhnost = "Низкая";
                            break;
                        case 2:
                            forGrid.slozhnost = "Средняя";
                            break;
                        case 3:
                            forGrid.slozhnost = "Высокая";
                            break;
                    }

                    forGrid.prepodavatel = data.teacher;
                    forGrid.tema = data.tema;
                    forGrid.vopros = data.vopros;
                    forGrid.idVoprosa = data.id;
                    forGrid.tipVoprosa = data.tip;
                    forGridQuest.Add(forGrid);
                }
            }
            return forGridQuest;
        }

        public List<DataForGridOfStudents> GetDataOfStudents()
        {
            List<DataForGridOfStudents> forGridStudents = new List<DataForGridOfStudents>();
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                var students = (from student in context.Students
                                where student.Groups.Number_of_group == numberOfGroup
                                select new
                                {
                                    fio = student.Surname + " " + student.Name + " " + student.Otchestvo
                                }).ToList();
                foreach(var student in students)
                {
                    DataForGridOfStudents forGrid = new DataForGridOfStudents();
                    forGrid.fio = student.fio;
                    forGridStudents.Add(forGrid);
                }
            }
            return forGridStudents;
        }

    }
}
