using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UniversalDataClasses
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Text{ get; set; }
        public Nullable<DateTime> Date { get; set; }
    }
}
