using System;
using System.Collections.Generic;

namespace DSED_07_Web_Development.Models
{
    public partial class Novels
    {
        public int NovelId { get; set; }
        public string NovelName { get; set; }
        public double? NovelPrice { get; set; }
        public string NovelAuthor { get; set; }
    }
}
