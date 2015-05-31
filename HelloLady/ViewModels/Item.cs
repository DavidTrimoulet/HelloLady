using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLady.ViewModels
{
    public class Item
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
        public string Guid { get; set; }
        public DateTime Published { get; set; }
    }
}
