using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

[Table("UserActivityLog")]
public partial class UserActivityLog
{
    [Key]
    [Column("LogID")]
    public Guid LogId { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    [StringLength(50)]
    public string ActivityType { get; set; } = null!;

    public string? ActivityDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LogDate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserActivityLogs")]
    public virtual User User { get; set; } = null!;
}
