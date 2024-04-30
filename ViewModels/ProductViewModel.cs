using web_app.Models;

namespace web_app.ViewModels;

public class ProductViewModel : TbMProduct
{
    public required TbMUnit Unit { get; set; }
    public required TbTrPrice Price { get; set; }
}
