using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MyEntities
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("User Name")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
