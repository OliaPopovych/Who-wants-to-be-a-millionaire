using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using WhoWantsToBeAMillionaire.Repositories.Entities;

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
        [XmlIgnore]
        public int TimesSelected { get; set; }
        [XmlIgnore]
        public virtual StatisticsEntry StatisticEntry { get; set; }

        public Answer()
        {
        }
    }
}