using System.Collections.Generic;
using System.Xml.Serialization;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class Question
    {
        [XmlElement("Question")]
        public string Text { get; set; }
        [XmlElement("Answers")]
        public List<Answer> Answers { get; set; }
    }
}
