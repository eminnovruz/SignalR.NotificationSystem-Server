using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi_SignalR.Server.ApiModels.Requests;
using WebApi_SignalR.Server.Services.Abstract;
using WebApi_SignalR.Server.SignalR.Hubs;

namespace WebApi_SignalR.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }


    // Endpoint to send notification to all clients
    [HttpPost("SendNotificationToAllClients")]
    public async Task<IActionResult> SendNotificationToAllClients(SendCustomNotificationRequest request)
    {
        await _notificationService.SendCustomNotificationToAll(request);
        return Ok("Notification sent to all listeners..");
    }
}
