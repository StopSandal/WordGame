﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Data
{
    public class WordItem
    {
        public string Word {  get; set; }
        public WordItem(string word)
        {
            Word = word;
        }
    }
}
