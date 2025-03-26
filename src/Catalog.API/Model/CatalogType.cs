using System.ComponentModel.DataAnnotations;

namespace ShivShambho_eShop.Catalog.API.Model;

public class CatalogType
{
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }
}
