using System.Xml.Serialization;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class Answer
    {
        [XmlElement("Answer")]
        public string Text { get; set; }
        [XmlElement("Res")]
        public bool isTrue { get; set; }
    }
}