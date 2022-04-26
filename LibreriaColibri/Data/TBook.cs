using System;
using System.Collections.Generic;

namespace LibreriaColibri.Data
{
    public partial class TBook
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public int IdPh { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Depot { get; set; }
        public string? Img { get; set; }
        public int Sold { get; set; }

        public virtual TPublishingHouse IdPhNavigation { get; set; } = null!;
    }
}
