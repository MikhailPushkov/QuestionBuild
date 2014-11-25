using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBuild.DataAccess
{
    static class RemoveItem
    {
        public static void Vopros(int idVoprosa)
        {
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                Vopros vopros = (from vop in context.Vopros
                                 where vop.ID_Voprosa == idVoprosa
                                 select vop).First();
                context.Vopros.Remove(vopros);
                context.SaveChanges();
            }
        }

        public static void Student(string nameOfStudent)
        {
            int idStudent = GetId.Student(nameOfStudent);
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                Students student = (from stud in context.Students
                                    where stud.ID_Student == idStudent
                                    select stud).First();
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
