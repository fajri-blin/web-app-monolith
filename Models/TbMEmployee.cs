using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbMEmployee
{
    public Guid Guid { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid? RoleGuid { get; set; }

    public bool? Isdelete { get; set; }

    public virtual TbMRole? Role { get; set; }

    public virtual ICollection<TbTrTransaction> TbTrTransactions { get; set; } = new List<TbTrTransaction>();
}
