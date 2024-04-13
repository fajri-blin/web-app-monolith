using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbTrPrice
{
    public Guid Guid { get; set; }

    public Guid? ProductGuid { get; set; }

    public Guid? PriceGuid { get; set; }

    public decimal Amount { get; set; }

    public bool? Isdelete { get; set; }

    public virtual TbMUnit? Price { get; set; }

    public virtual TbMProduct? Product { get; set; }

    public virtual ICollection<TbMTransactionItem> TbMTransactionItems { get; set; } = new List<TbMTransactionItem>();
}
