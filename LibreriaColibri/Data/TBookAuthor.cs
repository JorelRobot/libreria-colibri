using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TBookAuthor
    {
        public int IdBook { get; set; }
        public int IdAuthor { get; set; }

        public virtual TAuthor IdAuthorNavigation { get; set; } = null!;
        public virtual TBook IdBookNavigation { get; set; } = null!;
    }
}
