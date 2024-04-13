using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbMUnit
{
    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public bool? Isdelete { get; set; }

    public virtual ICollection<TbTrPrice> TbTrPrices { get; set; } = new List<TbTrPrice>();
}
