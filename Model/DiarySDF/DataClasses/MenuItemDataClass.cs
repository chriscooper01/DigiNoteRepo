using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.DataClasses
{
    public class MenuItemDataClass
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Logic { get; set; }
        public string Display { get; set; }
    }
}
