using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [XmlElement("Answer")]
        public string Text { get; set; }
        [XmlElement("Res")]
        public bool isTrue { get; set; }
    }
}