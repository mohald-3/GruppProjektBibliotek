﻿using System;
using System.Collections.Generic;

namespace GruppProjektBibliotek
{
    public class Bok
    {
       
        public string BokTitel { get; set; }
        public string BokFörfattare { get; set; }
        public int ISBN { get; set; }
        public bool IsCheckedOut { get; set; }  

        public Bok(string boktitel, string bokförfattare, int isbn)
        {
            BokTitel = boktitel;
            BokFörfattare = bokförfattare;
            ISBN = isbn;
            IsCheckedOut = false;
        }
    }
}

