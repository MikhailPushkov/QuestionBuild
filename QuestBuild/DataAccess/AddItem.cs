using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBuild.DataAccess
{
    static class AddItem
    {
        public static void Vopros(Vopros vopros)
        {
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Vopros.Add(vopros);
                context.SaveChanges();
            }
        }

        public static void Answer(Otvet answer)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Otvet.Add(answer);
                context.SaveChanges();
            }
        }

        public static void Author(Prepodavateli author)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Prepodavateli.Add(author);
                context.SaveChanges();
            }
        }

        public static void Fakultet(Fakultet fakultet)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Fakultet.Add(fakultet);
                context.SaveChanges();
            }
        }

        public static void Group(Groups group)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Groups.Add(group);
                context.SaveChanges();
            }
        }

        public static void Kafedra(Kafedra kafedra)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Kafedra.Add(kafedra);
                context.SaveChanges();
            }
        }

        public static void Student(Students student)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public static void Subject(Predmet subject)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Predmet.Add(subject);
                context.SaveChanges();
            }
        }

        public static void Tema(Tema theme)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Tema.Add(theme);
                context.SaveChanges();
            }
        }

        public static void TipVoprosa(Tip_Voprosa tip)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Tip_Voprosa.Add(tip);
                context.SaveChanges();
            }
        }

        public static void VidRaboti(Vidi_Rabot vid)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Vidi_Rabot.Add(vid);
                context.SaveChanges();
            }
        }

        public static void Zadanie(Zadanie zadanie)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                context.Zadanie.Add(zadanie);
                context.SaveChanges();
            }
        }

        public static void VoprosToZadanie(int idZadaniya, List<int> idVoprosov)
        {
            using (QuestBuildEntities context = new QuestBuildEntities())
            {
                Zadanie zadanieToUpdate = (from zad in context.Zadanie
                                           where zad.ID_Raboti == idZadaniya
                                           select zad).First();

                foreach (var vop in idVoprosov)
                {
                    zadanieToUpdate.Vopros.Add((from vp in context.Vopros
                                                where vp.ID_Voprosa == vop
                                                select vp).First());
                }
                context.SaveChanges();
            }
        }

        public static void ChangedVopros(Vopros vopros)
        {
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                Vopros voprosToChange = (from vop in context.Vopros
                                         where vop.ID_Voprosa == vopros.ID_Voprosa
                                         select vop).First();
                voprosToChange.ID_Voprosa = vopros.ID_Voprosa;
                voprosToChange.ID_Prepodavatelya = vopros.ID_Prepodavatelya;
                voprosToChange.ID_Temi = vopros.ID_Temi;
                voprosToChange.ID_Tipa = vopros.ID_Tipa;
                voprosToChange.Stoimost_Voprosa = vopros.Stoimost_Voprosa;
                voprosToChange.Tekst_Voprosa = vopros.Tekst_Voprosa;
                context.SaveChanges();
            }
        }

        public static void ChangedAnswer(Otvet answer, int numberOfAnswer)
        {
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                List<Otvet> answers = (from otvet in context.Otvet
                                        where otvet.ID_Voprosa == answer.ID_Voprosa
                                        select otvet).ToList();
                Otvet newAnswer = answers[numberOfAnswer - 1];
                newAnswer.Pravilnost = answer.Pravilnost;
                newAnswer.Tekst_otveta = answer.Tekst_otveta;
                context.SaveChanges();
            }
        }
    }
}
