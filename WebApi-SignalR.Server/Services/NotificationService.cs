using Microsoft.AspNetCore.SignalR;
using WebApi_SignalR.Server.ApiModels.Requests;
using WebApi_SignalR.Server.Services.Abstract;
using WebApi_SignalR.Server.SignalR.Hubs;

namespace WebApi_SignalR.Server.Services;

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendCustomNotificationToAll(SendCustomNotificationRequest request)
        => await _hubContext.Clients.All.SendAsync("ReceiveNotification", request.Content);
}
