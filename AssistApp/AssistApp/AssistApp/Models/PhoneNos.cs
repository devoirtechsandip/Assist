using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistApp.Models
{
    public class PhoneNos
    {
        [PrimaryKey, AutoIncrement]
        public int pk { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
    }
}
