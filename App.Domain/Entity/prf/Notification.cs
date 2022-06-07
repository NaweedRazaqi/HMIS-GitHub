using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string SenderUserId { get; set; }
        public string ReceiverUsersId { get; set; }
        public DateTime Time { get; set; }
        public int NotificationTypeId { get; set; }
        public bool IsSeen { get; set; }
    }
}
