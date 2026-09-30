using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

public partial class Notification
{
    [Key]
    [Column("NotificationID")]
    public Guid NotificationId { get; set; }

    [StringLength(200)]
    public string Subject { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime ScheduledSendTime { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Notification")]
    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}
