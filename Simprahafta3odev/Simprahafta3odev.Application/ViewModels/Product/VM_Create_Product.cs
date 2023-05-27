using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simprahafta3odev.Application.ViewModels.Category
{
    public class VM_Create_Product
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }

    }
}
