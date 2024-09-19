using WebApi_SignalR.Server.ApiModels.Requests;

namespace WebApi_SignalR.Server.Services.Abstract;

public interface INotificationService
{
    Task SendCustomNotificationToAll(SendCustomNotificationRequest message);
}
