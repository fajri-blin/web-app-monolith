using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_app.Models;

public partial class TbTrPrice
{
    public Guid Guid { get; set; }

    public Guid? ProductGuid { get; set; }

    public Guid? UnitGuid { get; set; }

    [Required]
    [Display(Name = "Price Amount")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Please enter a valid price amount.")]
    public decimal Amount { get; set; }

    public bool? Isdelete { get; set; }
}
