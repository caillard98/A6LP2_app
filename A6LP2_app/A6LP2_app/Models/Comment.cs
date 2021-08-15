using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Recipe_ID { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string DateString { get; set; }

        public Comment()
        {

        }
    }
}
