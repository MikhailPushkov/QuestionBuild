using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBuild.DataAccess
{
    static class GetItem
    {
        public static string VidRaboti(int idWork)
        {
            string vid;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                vid = (from someVar in context.Zadanie
                       where someVar.ID_Raboti == idWork
                       select someVar.Vidi_Rabot.Nazvanie_Vida).First();
            }
            return vid;
        }

        public static DateTime DataVidachi(int idWork)
        {
            DateTime dataVidachi;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                dataVidachi = (DateTime)(from someVar in context.Zadanie
                               where someVar.ID_Raboti == idWork
                               select someVar.Data_Vidachi).First();
            }
            return dataVidachi;
        }

        public static DateTime DataSdachi(int idWork)
        {
            DateTime dataSdachi;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                dataSdachi = (DateTime)(from someVar in context.Zadanie
                                        where someVar.ID_Raboti == idWork
                                        select someVar.Data_Sdachi).First();
            }
            return dataSdachi;
        }

        public static bool RightAnswer(int idVoprosa, string answer)
        {
            bool rAnswer;
            using(QuestBuildEntities context = new QuestBuildEntities())
            {
                rAnswer = (bool)(from otvet in context.Otvet
                           where otvet.Tekst_otveta == answer && otvet.ID_Voprosa == idVoprosa
                           select otvet.Pravilnost).First();
            }
            return rAnswer;
        }
    }
}
