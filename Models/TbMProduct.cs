using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbMProduct
{
    public Guid Guid { get; set; }

    public string BarcodeId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public bool? Isdelete { get; set; }

    public virtual ICollection<TbMTransactionItem> TbMTransactionItems { get; set; } = new List<TbMTransactionItem>();

    public virtual ICollection<TbTrPrice> TbTrPrices { get; set; } = new List<TbTrPrice>();
}
