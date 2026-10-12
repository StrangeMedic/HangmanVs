using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HangmanVs.Models
{
    internal class StackResponse
    {
        public class Root
        {
            public string word { get; set; }
        }
    }
}
