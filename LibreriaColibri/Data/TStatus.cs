using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TStatus
    {
        public TStatus()
        {
            TOrders = new HashSet<TOrder>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<TOrder> TOrders { get; set; }
    }
}
