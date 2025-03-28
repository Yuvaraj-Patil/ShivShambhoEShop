namespace ShivShambho_eShop.Ordering.API.Application.Commands;
using ShivShambho_eShop.Ordering.API.Application.Models;

public record CreateOrderDraftCommand(string BuyerId, IEnumerable<BasketItem> Items) : IRequest<OrderDraftDTO>;
