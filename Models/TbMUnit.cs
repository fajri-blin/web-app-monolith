using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_app.Models;

public partial class TbMUnit
{
    [Required]
    public Guid Guid { get; set; }
    [Required]
    [Display(Name = "Unit Name")]
    public string Name { get; set; } = null!;

    public bool? Isdelete { get; set; }
}
