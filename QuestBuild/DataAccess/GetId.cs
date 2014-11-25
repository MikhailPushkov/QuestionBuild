using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBuild
{
    static class GetId
    {
        public static int Prepodavatel(string prepodavatel)
        {
            int id;
            string[] fio = prepodavatel.Split(' ');
            string surname = fio[0];
            string name = fio[1];
            string otchestvo = fio[2];
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from au in context.Prepodavateli
                              where au.Surname == surname &&
                              au.Name == name &&
                              au.Otchestvo == otchestvo
                              select au.ID_Prepodavatelya).First();
            }
            return id;
        }

        public static int Student(string student)
        {
            int id;
            string[] fio = student.Split(' ');
            string surname = fio[0];
            string name = fio[1];
            string otchestvo = fio[2];
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from students in context.Students
                      where students.Surname == surname &&
                      students.Name == name &&
                      students.Otchestvo == otchestvo
                      select students.ID_Student).First();
            }
            return id;
        }

        public static int Theme(string tema)
        {
            int id;
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
               id = (from t in context.Tema
                             where t.Nazvanie_Temi == tema
                             select t.ID_Temi).First();
            }
            return id;
        }

        public static int Group(int numberOfGroup)
        {
            int id;
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from gr in context.Groups
                               where gr.Number_of_group == numberOfGroup
                               select gr.ID_Group).First();
            }
            return id;
        }

        public static int Tip(string tip)
        {
            int id;
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from tv in context.Tip_Voprosa
                           where tv.Tip == tip
                           select tv.ID_Tipa).First();
            }
            return id;
        }

        public static int Vopros()
        {
            int id;
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                var idVoprosa = (from idV in context.Vopros
                                 select idV.ID_Voprosa).ToList();
                id = idVoprosa.Last();
            }
            return id;
        }

        public static int Vid(string vidRaboti)
        {
            int id;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from idV in context.Vidi_Rabot
                      where idV.Nazvanie_Vida == vidRaboti
                      select idV.ID_Vida).First();
            }
            return id;
        }

        public static int Zadanie()
        {
            int id;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from idZ in context.Zadanie
                      select idZ.ID_Raboti).ToList().Last();
            }
            return id;
        }

        public static int Kafedra(string nameOfKafedra)
        {
            int id;
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from idK in context.Kafedra
                               where idK.Nazvanie_Kafedri == nameOfKafedra
                               select idK.ID_Kafedri).First();
            }
            return id;
        }

        public static int Fakultet(string nameOfFakultet)
        {
            int id;
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from idF in context.Fakultet
                               where idF.Nazvanie_Fakulteta == nameOfFakultet
                               select idF.ID_Faculteta).First();
            }
            return id;
        }

        public static int Predmet(string nameOfSubject)
        {
            int id;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                id = (from idS in context.Predmet
                      where idS.Nazvanie_Predmeta == nameOfSubject
                      select idS.ID_Predmeta).First();
            }
            return id;
        }

    }
}
