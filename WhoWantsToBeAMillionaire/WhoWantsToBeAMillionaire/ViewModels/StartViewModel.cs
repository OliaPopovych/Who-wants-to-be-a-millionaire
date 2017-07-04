using WhoWantsToBeAMillionaire.Repositories;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class StartViewModel
    {
        public Question Question { get; set; }
        public string FiftyButtonDisabl { get; set; }
        public StartViewModel()
        {
            FiftyButtonDisabl = "false";
        }
    }
}