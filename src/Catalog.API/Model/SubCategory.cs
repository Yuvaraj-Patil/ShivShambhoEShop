using System.ComponentModel.DataAnnotations;

namespace ShivShambho_eShop.Catalog.API.Model;

public class SubCategory
{
    public int SubCategoryId { get; set; }

    [Required]
    public string SubCategoryName { get; set; }
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; }
}
