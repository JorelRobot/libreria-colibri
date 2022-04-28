using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TBookCategory
    {
        public int IdBook { get; set; }
        public int IdCategory { get; set; }

        public virtual TBook IdBookNavigation { get; set; } = null!;
        public virtual TCategory IdCategoryNavigation { get; set; } = null!;
    }
}
