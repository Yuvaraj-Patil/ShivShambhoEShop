using System.ComponentModel.DataAnnotations;

namespace ShivShambho_eShop.Catalog.API.Model;

public class ProductCategory
{
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }
    public ICollection<SubCategory> SubCategories { get; set; }
}
