using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace mtuliwindo
{
    public class Contact
    {
        private static int ids = 0;
        public int id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }

        public Contact(string phone, string name, string email) {
            id = ids++;
            PhoneNum = phone;
            Email = email;
            Name = name;
        }
        public Contact()
        {
            id = ids++;
            PhoneNum = "";
            Email = "";
            Name = "";
        }
    }
}
