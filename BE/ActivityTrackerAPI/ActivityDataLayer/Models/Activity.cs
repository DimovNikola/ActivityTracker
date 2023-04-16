using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityDataLayer.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool NeedHelp { get; set; }
        public User User { get; set; }
        public ActivityImage ActivityImage { get; set; }
    }
}
