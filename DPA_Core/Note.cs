using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Core
{
    class Note
    {
        // C, D, E, F, G, A, B
        String pitch { get; set; }

        /*
         * In most cases, a sharp raises the pitch of a note one semitone while a flat lowers it a semitone. 
         * A natural is used to cancel the effect of a flat or sharp. 
         * */
        String accidental { get; set; }

        // Geen idee?
        String timeSignature { get; set; }


    }
}
