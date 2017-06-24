using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class XmlQuestionRepository : IRepository<Question>
    {
        private string fileName;
        List<Question> list;

        public XmlQuestionRepository()
        {
            fileName = HttpContext.Current.Server.MapPath("~/App_Data/questions.xml");
        }

        public IEnumerable<Question> GetAll()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

                using (StreamReader reader = new StreamReader(fileName))
                {
                    list = (List<Question>)serializer.Deserialize(reader);
                }
                return list;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }
    }
}
