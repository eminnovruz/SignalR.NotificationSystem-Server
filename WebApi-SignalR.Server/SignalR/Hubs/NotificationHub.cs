using Microsoft.AspNetCore.SignalR;

namespace WebApi_SignalR.Server.SignalR.Hubs;

public class NotificationHub : Hub
{
    private List<string> _activeUsers;

    public NotificationHub()
    {
        _activeUsers = new List<string>();
    }

    public async Task SendNotificationToAllClients(string message)
    {
        await Clients.All.SendAsync(message);
    }

    public override async Task OnConnectedAsync()
    {
        string userId = Context.ConnectionId;

        _activeUsers.Add(userId);

        Console.WriteLine($"Client with id {userId} is connected");

        await Clients.Caller.SendAsync("ReceiveNotification", "Welcome to notification system");

        await base.OnConnectedAsync();
    }

    public async Task SendNotification(string message)
        => await Clients.All.SendAsync("ReceiveMessage", message);
}
