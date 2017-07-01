using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class XmlQuestionRepository : IQuestionRepository
    {
        private string fileName;
        private List<Question> list;

        public XmlQuestionRepository(string path)
        {
            fileName = HttpContext.Current.Server.MapPath(path);
        }

        public IList<Question> GetAll()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

                using (StreamReader reader = new StreamReader(fileName))
                {
                    list = (List<Question>)serializer.Deserialize(reader);
                }
                FillRightAnswerFields();
                return list;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }

        private void FillRightAnswerFields()
        {
            for(int i = 0; i < list.Count; i++)
            {
                list[i].RightAnswerId = GetRightAnswer(list[i]);
            }
        }

        private int GetRightAnswer(Question question)
        {
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (question.Answers[i].isTrue == true)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
