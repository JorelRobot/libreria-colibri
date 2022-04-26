using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TCarBook
    {
        public int? IdCar { get; set; }
        public int? IdBook { get; set; }
        public int? Quantity { get; set; }

        public virtual TBook? IdBookNavigation { get; set; }
        public virtual TShoppingCar? IdCarNavigation { get; set; }
    }
}
