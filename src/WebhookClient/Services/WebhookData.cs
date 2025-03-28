using System.Text.Json;

namespace ShivShambho_eShop.WebhookClient.Services;

public class WebhookData
{
    public DateTime When { get; set; }

    public string? Payload { get; set; }

    public string? Type { get; set; }
}
