using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbTrTransaction
{
    public Guid Guid { get; set; }

    public Guid? EmployeeGuid { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal? TotalAmmount { get; set; }

    public bool? Isdelete { get; set; }
}
