using DPA_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Note note = new Note();

            Console.WriteLine(note.call_self());

            Console.ReadKey();
        }
    }
}
