using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdStatus { get; set; }
        public string IdUser { get; set; }

        public virtual TStatus IdStatusNavigation { get; set; } = null!;
    }
}
