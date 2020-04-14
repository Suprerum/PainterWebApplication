using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainterWebApplication.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public Set Set { get; set; }
        public Painter Painter { get; set; }
    }
}
