using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Models
{
    public class User
    {
        public int Id { get; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int Diary_Id {  get; }

        public User(int id, int diary_Id)
        {
            Id = id;
            Diary_Id = diary_Id;
        }
    }
}
