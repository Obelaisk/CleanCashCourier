
namespace ApiClases_20270722_Proyecto.SignalRServicio;

public class SignalRHubNotificacion : Hub
{
    public async Task SendNotification(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", user, message);
    }
}
