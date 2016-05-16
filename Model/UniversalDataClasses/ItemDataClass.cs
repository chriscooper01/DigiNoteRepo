using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UniversalDataClasses
{
    public class ItemDataClass
    {
        public int Id { get; set; }
        public string ItemControlName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartedPlan { get; set; }
        public DateTime CompletionPlanned { get; set; }

        public string CurrentColumn { get; set; }

        public ItemDataClass()
        {

        }

        public ItemDataClass(object tag)
        {
            if (tag != null)
            {
                var masked = (ItemDataClass)tag;
                Id = masked.Id;
                ItemControlName = masked.ItemControlName;
                Name = masked.Name;
                Description = masked.Description;
                StartedPlan = masked.StartedPlan;
                CompletionPlanned = masked.CompletionPlanned;
                CurrentColumn = masked.CurrentColumn;

            }//END if(tag !=null)
        }

    }
}
