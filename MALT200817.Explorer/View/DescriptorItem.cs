using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Explorer.View
{
    public class DescriptorItem
    {
        public string CardTypeName { get; set; }
        public int CardType { get; set; }
        public int Options { get; set; }
        public string FirstName { get; set; }

        public ComponentCollection Components { get; set; }

           public DescriptorItem()
        {

        }
    }

}
