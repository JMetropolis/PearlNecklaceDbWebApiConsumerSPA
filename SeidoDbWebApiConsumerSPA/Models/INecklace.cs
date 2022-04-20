using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklaceDbWebApiConsumerSPA.Models
{
    public interface INecklace : IEquatable<INecklace>, IRandomInit
    {
        public int NecklaceID { get; }
        public string Name { get; set; }
        public int price { get; set; }
    }
}
