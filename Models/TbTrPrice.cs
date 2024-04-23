using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbTrPrice
{
    public Guid Guid { get; set; }

    public Guid? ProductGuid { get; set; }

    public Guid? UnitGuid { get; set; }

    public decimal Amount { get; set; }

    public bool? Isdelete { get; set; }
}
