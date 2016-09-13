using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Core
{
    public class Note
    {
        String name { get; set; }


        public Note()
        {
            this.name = "note";
        }

        public String call_self()
        {
            return "My name is " + this.name;
        }
    }
}
