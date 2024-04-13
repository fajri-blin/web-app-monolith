using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbMTransactionItem
{
    public Guid Guid { get; set; }

    public Guid? TransactionGuid { get; set; }

    public Guid? ProductGuid { get; set; }

    public Guid? PriceGuid { get; set; }

    public float Quantity { get; set; }

    public decimal Subtotal { get; set; }

    public bool? Isdelete { get; set; }

    public virtual TbTrPrice? Price { get; set; }

    public virtual TbMProduct? Product { get; set; }

    public virtual TbTrTransaction? Transaction { get; set; }
}
