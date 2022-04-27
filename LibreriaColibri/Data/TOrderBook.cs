using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TOrderBook
    {
        public int IdOrder { get; set; }
        public int IdBook { get; set; }
        public int Quantity { get; set; }

        public virtual TBook IdBookNavigation { get; set; } = null!;
        public virtual TOrder IdOrderNavigation { get; set; } = null!;
    }
}
