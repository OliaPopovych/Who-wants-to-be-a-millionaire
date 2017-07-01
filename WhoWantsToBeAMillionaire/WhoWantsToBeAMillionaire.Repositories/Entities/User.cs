using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Sum { get; set; }

        public User(string name, int sum)
        {
            Name = name;
            Sum = sum;
        }
    }
}
