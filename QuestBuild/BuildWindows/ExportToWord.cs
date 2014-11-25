using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;
using QuestBuild.DataAccess;

namespace QuestBuild.BuildWindows
{
    class ExportToWord
    {
        public ExportToWord(string prepodavatel, string putKDocumentam,
            string predmet, string tema, List<int> idRabot, List<string> students)
        {
            this.prepodavatel = prepodavatel;
            this.putKDocumentam = putKDocumentam;
            this.predmet = predmet;
            this.tema = tema;
            this.idRabot = idRabot;
            this.students = students;

            CreateWordDocument();
        }

        public string prepodavatel { get; set; }
        public string putKDocumentam { get; set; }
        public string predmet { get; set; }
        public string tema { get; set; }
        public List<int> idRabot { get; set; }
        public List<string> students = new List<string>();

        private Word.Application wordApp;
        private List<int> idVoprosov = new List<int>();
        
        private void CreateWordDocument()
        {
            Window statusWord = new BeginingCreateWord();
            statusWord.Show();

            putKDocumentam += @"\" + predmet + " " + tema + @"\";
            string pathString = System.IO.Path.Combine(putKDocumentam);

            for(int i = 0; i < idRabot.Count; i++)
            {
                int idRaboti = idRabot[i];
                string vidRaboti = GetItem.VidRaboti(idRaboti);
                DateTime dataVidachi = GetItem.DataVidachi(idRaboti);
                DateTime dataSdachi = GetItem.DataSdachi(idRaboti);
                int numberOfParagrafs = 1;

                wordApp = new Word.Application();
                Word.Document document = wordApp.Documents.Add();
                Word.Paragraphs paragrafs = document.Paragraphs;
                paragrafs[numberOfParagrafs].Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                
                Word.Range rangeZaglavie = paragrafs[numberOfParagrafs].Range;
                rangeZaglavie.Font.Name = "Arial";
                rangeZaglavie.Font.Bold = 1;
                rangeZaglavie.Font.Size = 18;
                rangeZaglavie.Text = vidRaboti + ".";
                numberOfParagrafs += 1;

                document.Paragraphs.Add();
                Word.Range rangePredmet = paragrafs[numberOfParagrafs].Range;
                rangePredmet.Font.Bold = 0;
                rangePredmet.Font.Size = 16;
                rangePredmet.Text = "Предмет: " + predmet + ".";
                numberOfParagrafs += 1;

                document.Paragraphs.Add();
                Word.Range rangeVariantStudent = paragrafs[numberOfParagrafs].Range;
                rangeVariantStudent.Text = "Вариант №" + (i + 1) + "     " + students[i];
                numberOfParagrafs += 1;

                List<string> spisokVoprosov = GetQuestions(idRabot[i]);

                for(int k = 0; k < spisokVoprosov.Count; k++)
                {
                    document.Paragraphs.Add();
                    paragrafs[numberOfParagrafs].Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    Word.Range rangeNumberOfQuestion = paragrafs[numberOfParagrafs].Range;
                    rangeNumberOfQuestion.Font.Bold = 1;
                    rangeNumberOfQuestion.Font.Size = 14;
                    rangeNumberOfQuestion.Text = "Вопрос №" + (k + 1);
                    numberOfParagrafs += 1;

                    document.Paragraphs.Add();
                    Word.Range rangeVopros = paragrafs[numberOfParagrafs].Range;
                    rangeVopros.Font.Bold = 0;
                    rangeVopros.Text = spisokVoprosov[k];
                    numberOfParagrafs += 1;

                    List<string> spisokOtvetov = GetAnswers(idVoprosov[k]);

                    if (spisokOtvetov.Count > 0)
                    {
                        document.Paragraphs.Add();
                        Word.Range rangeOtvet = paragrafs[numberOfParagrafs].Range;
                        rangeOtvet.Font.Bold = 1;
                        rangeOtvet.Text = "Ответы: ";
                        numberOfParagrafs += 1;

                        for(int a = 0; a < spisokOtvetov.Count; a++)
                        {
                            document.Paragraphs.Add();
                            Word.Range rangeAnswers = paragrafs[numberOfParagrafs].Range;
                            rangeAnswers.Font.Bold = 0;
                            rangeAnswers.Text = "   " + (a + 1) + ". " + spisokOtvetov[a];
                            numberOfParagrafs += 1;
                        }
                    }
                    else
                    {
                        for (int e = 0; e < 7; e++)
                        {
                            document.Paragraphs.Add();
                            Word.Range rangeEmpty = paragrafs[numberOfParagrafs].Range;
                            rangeEmpty.Text = "";
                            numberOfParagrafs += 1;
                        }
                    }
                }

                System.IO.Directory.CreateDirectory(pathString);

                Object fileName = putKDocumentam + students[i] + ".doc";
                Object fileFormat = Word.WdSaveFormat.wdFormatDocument;
                Object lockComments = false;
                Object password = "";
                Object addToRecentFiles = false;
                Object writePassword = "";
                Object readOnlyRecommended = false;
                Object embedTrueTypeFonts = false;
                Object saveNativePictureFormat = false;
                Object saveFormsData = false;
                Object saveAsAOCELetter = Type.Missing;
                Object encoding = Type.Missing;
                Object insertLineBreaks = Type.Missing;
                Object allowSubstitutions = Type.Missing;
                Object lineEnding = Type.Missing;
                Object addBiDiMarks = Type.Missing;

                document.SaveAs2(ref fileName, ref fileFormat, ref lockComments, ref password,
                    ref addToRecentFiles, ref writePassword, ref readOnlyRecommended,
                    ref embedTrueTypeFonts, ref saveNativePictureFormat, ref saveFormsData,
                    ref saveAsAOCELetter, ref encoding, ref insertLineBreaks, ref allowSubstitutions,
                    ref lineEnding, ref addBiDiMarks);
                ((Word._Application)wordApp).Quit();
            }

            statusWord.Close();

            System.Diagnostics.Process.Start(putKDocumentam);
        }

        private List<string> GetQuestions(int idZadaniya)
        {
            List<string> voprosi = new List<string>();
            List<Vopros> questions = GetListOf.Questions(idZadaniya);
            foreach(var qe in questions)
            {
              voprosi.Add(qe.Tekst_Voprosa);
              idVoprosov.Add(qe.ID_Voprosa);
            }
            return voprosi;
        }

        private List<string> GetAnswers(int idVoprosa)
        {
            List<string> answers = new List<string>();

            try
            {
                answers = GetListOf.Answers(idVoprosa);
            }
            catch
            {
                answers.Clear();
            }

            return answers;
        }
    }
}
