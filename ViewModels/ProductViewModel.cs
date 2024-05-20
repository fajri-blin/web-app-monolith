using web_app.Models;

namespace web_app.ViewModels;

public class ProductViewModel : TbMProduct
{
    public TbMUnit? Unit { get; set; } = new TbMUnit();
    public TbTrPrice? Price { get; set; } = new TbTrPrice();
}
