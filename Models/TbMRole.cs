using System;
using System.Collections.Generic;

namespace web_app.Models;

public partial class TbMRole
{
    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public bool? Isdelete { get; set; }
}
