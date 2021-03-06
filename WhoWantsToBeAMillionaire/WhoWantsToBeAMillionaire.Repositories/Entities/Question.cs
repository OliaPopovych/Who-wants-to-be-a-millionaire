﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        [XmlElement("Question")]
        public string Text { get; set; }
        [XmlElement("Answers")]
        public List<Answer> Answers { get; set; }
        [XmlIgnore]
        public int RightAnswerId { get; set; }
        [XmlIgnore]
        public virtual StatisticsEntry StatisticEntry { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }

        public bool IsAnswersListEmpty()
        {
            foreach(var item in Answers)
            {
                if(item.TimesSelected != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
