using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuestBuild.DataAccess;

namespace QuestBuild.BuildWindows
{
    class ZadanieForWord
    {
        public ZadanieForWord(string prepodavatel, string gruppa, string subject,
            string theme, string vidRabot, string path, int maxBall, DateTime dataVidachi,
            DateTime dataSdachi, List<string> tipVoprosov, List<int> chisloVoprosovTipa)
        {
            this.prepodavatel = prepodavatel;
            this.gruppa = gruppa;
            this.subject = subject;
            this.theme = theme;
            this.vidRaboti = vidRabot;
            this.path = path;
            this.maxBall = maxBall;
            this.dataVidachi = dataVidachi;
            this.dataSdachi = dataSdachi;
            this.tipVoprosov = tipVoprosov;
            this.chisloVoprosovTipa = chisloVoprosovTipa;

            foreach(int chislo in chisloVoprosovTipa)
            {
                kolichestvoVoprosov += chislo;
            }

            GetStudents();
            CreateZadanie();
            GoToWord();
        }
        public string prepodavatel { get; set; }
        public string gruppa { get; set; }
        public string subject { get; set; }
        public string theme { get; set; }
        public string vidRaboti { get; set; }
        public string path { get; set; }
        public int maxBall { get; set; }
        public DateTime dataVidachi { get; set; }
        public DateTime dataSdachi { get; set; }
        public List<string> tipVoprosov { get; set; }
        public List<int> chisloVoprosovTipa { get; set; }

        private List<string> students = new List<string>();
        private List<int> questions = new List<int>();
        private List<int> idRabot = new List<int>();
        private int kolichestvoVoprosov;

        private void GetStudents()
        {
            int numberOfGrupp = Convert.ToInt32(gruppa.Remove(1, 3));
            students = GetListOf.Students(numberOfGrupp);
        }

        private void CreateZadanie()
        {
            Window beginingCreateZadanie = new BeginingCreateZadanie();
            beginingCreateZadanie.Show();

            try
            {
                foreach (string student in students)
                {
                    int idStudent = GetId.Student(student);
                    int idVida = GetId.Vid(vidRaboti);
                    int idZadaniya;
                    Zadanie zadanie = new Zadanie();
                    List<int> questionsForStudent = new List<int>();

                    zadanie.Kolichestvo_Voprosov = kolichestvoVoprosov;
                    zadanie.Stoimost_Raboti = maxBall;
                    zadanie.Data_Vidachi = dataVidachi;
                    zadanie.Data_Sdachi = dataSdachi;
                    zadanie.ID_Student = idStudent;
                    zadanie.ID_Vida = idVida;
                    AddItem.Zadanie(zadanie);
                    idZadaniya = GetId.Zadanie();
                    
                    int k = 0;
                    List<int> idVoprosov = new List<int>();

                    foreach (string tip in tipVoprosov)
                    {
                        List<int> voprosiTipa = GetListOf.IdVoprosov(tip);
                        
                        for (int i = 0; i < chisloVoprosovTipa[k]; i++)
                        {
                            Random random = new Random();
                            int kolichestvo = 0;
                        m: int r = random.Next(0, chisloVoprosovTipa[k] - 1);

                            if (questions.Contains(voprosiTipa[r]))
                            {
                                kolichestvo += 1;
                                if (kolichestvo == chisloVoprosovTipa[k])
                                {
                                    questions.Clear();
                                    kolichestvo = 0;
                                }

                                goto m;
                            }
                            else
                            {
                                questions.Add(voprosiTipa[r]);
                                if (questionsForStudent.Contains(voprosiTipa[r]))
                                {
                                    goto m;
                                }
                                else
                                {
                                    questionsForStudent.Add(voprosiTipa[r]);
                                    idVoprosov.Add(voprosiTipa[r]);
                                }
                            }
                        }

                        k += k + 1;
                    }

                    AddItem.VoprosToZadanie(idZadaniya, idVoprosov);
                    idRabot.Add(idZadaniya);
                }

                beginingCreateZadanie.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка! Данные не добавлены в базу. \nОбратитесь к администратору.");
                beginingCreateZadanie.Close();
            }
        }

        private void GoToWord()
        {
            ExportToWord expToWord = new ExportToWord(prepodavatel,
                path, subject, theme, idRabot, students);
        }
    }
}
