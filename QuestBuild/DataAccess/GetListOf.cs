using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBuild.DataAccess
{
    static class GetListOf
    {
        public static List<string> Predmet()
        {
            List<string> listOf = new List<string>();
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from subjects in context.Predmet
                          select subjects.Nazvanie_Predmeta).ToList();
            }
            return listOf;
        }

        public static List<string> Author()
        {
            List<string> listOf = new List<string>();
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from authors in context.Prepodavateli
                          select authors.Surname + " " + authors.Name + " " + authors.Otchestvo).ToList();
            }
            return listOf;
        }

        public static List<string> TipVoprosa()
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from tips in context.Tip_Voprosa
                          select tips.Tip).ToList();
            }
            return listOf;
        }

        public static List<string> Tema(string predmet)
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from themes in context.Tema
                          where themes.Predmet.Nazvanie_Predmeta == predmet
                          select themes.Nazvanie_Temi).ToList();
            }
            return listOf;
        }

        public static List<string> Kafedra()
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from kaf in context.Kafedra
                          select kaf.Nazvanie_Kafedri).ToList();
            }
            return listOf;
        }

        public static List<string> Fakultet()
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from fak in context.Fakultet
                          select fak.Nazvanie_Fakulteta).ToList();
            }
            return listOf;
        }

        public static List<string> Group()
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                var listOfInt = (from gruppa in context.Groups
                          select gruppa.Number_of_group).ToList();

                foreach(var item in listOfInt)
                {
                    listOf.Add(Convert.ToString(item));
                }
            }
            return listOf;
        }

        public static List<int> IdVoprosov(string tipVoprosa)
        {
            List<int> listOf = new List<int>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from sV in context.Vopros
                                     where sV.Tip_Voprosa.Tip == tipVoprosa
                                     select sV.ID_Voprosa).ToList();
            }
            return listOf;
        }

        public static List<string> VidRabot()
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from vid in context.Vidi_Rabot
                          select vid.Nazvanie_Vida).ToList();
            }
            return listOf;
        }

        public static List<Vopros> Questions(int idZadaniya)
        {
            List<Vopros> questions = new List<Vopros>();
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                questions = (from qe in context.Zadanie
                             where qe.ID_Raboti == idZadaniya
                             select qe.Vopros).First().ToList();
            }
            return questions;
        }

        public static List<string> Answers(int idVoprosa)
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from an in context.Otvet
                          where an.ID_Voprosa == idVoprosa
                          select an.Tekst_otveta).ToList();
            }
            return listOf;
        }

        public static List<string> Students(int numberOfGroup)
        {
            List<string> listOf = new List<string>();
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                listOf = (from st in context.Students
                          where st.Groups.Number_of_group == numberOfGroup
                          select st.Surname + " " + st.Name + " " + st.Otchestvo).ToList();
            }
            return listOf;
        }
    }
}
