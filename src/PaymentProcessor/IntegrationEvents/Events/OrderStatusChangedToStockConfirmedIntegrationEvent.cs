﻿namespace ShivShambho_eShop.PaymentProcessor.IntegrationEvents.Events;

public record OrderStatusChangedToStockConfirmedIntegrationEvent(int OrderId) : IntegrationEvent;
