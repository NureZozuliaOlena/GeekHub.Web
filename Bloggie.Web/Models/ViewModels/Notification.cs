using GeekHub.Web.Enums;

namespace GeekHub.Web.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}