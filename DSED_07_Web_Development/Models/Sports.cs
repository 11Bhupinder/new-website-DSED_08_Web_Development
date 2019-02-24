using System;
using System.Collections.Generic;

namespace DSED_07_Web_Development.Models
{
    public partial class Sports
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public double? SportFees { get; set; }
        public string SportCoach { get; set; }
    }
}
