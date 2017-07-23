using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class MailViewModel
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Text { get; set; }
    }
}