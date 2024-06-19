using web_app.Models;

namespace web_app.ViewModels;

public class ProductViewModel : TbMProduct
{
    public string? UnitName { get; set; }
    public decimal? Price { get; set; }
    public List<TbMUnit>? Units { get; set; }
}
