using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TPublishingHouse
    {
        public TPublishingHouse()
        {
            TBooks = new HashSet<TBook>();
        }

        public int Id { get; set; }
        public string NamePh { get; set; } = null!;

        public virtual ICollection<TBook> TBooks { get; set; }
    }
}
