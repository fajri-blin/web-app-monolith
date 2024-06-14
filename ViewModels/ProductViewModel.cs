using web_app.Models;

namespace web_app.ViewModels;

public class ProductViewModel : TbMProduct
{
    public TbMUnit? Unit { get; set; }
    public TbTrPrice? Price { get; set; }
    public List<TbMUnit>? Units { get; set; }
}
