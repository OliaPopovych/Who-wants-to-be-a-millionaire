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
                return list;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }
    }
}
