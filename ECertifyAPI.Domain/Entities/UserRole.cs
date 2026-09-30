using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

public partial class UserRole
{
    [Key]
    [Column("UserRoleID")]
    public Guid UserRoleId { get; set; }

    [Column("RoleID")]
    public Guid RoleId { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    [Column("ECertifyID")]
    public Guid EcertifyId { get; set; }

    [ForeignKey("EcertifyId")]
    [InverseProperty("UserRoles")]
    public virtual Ecertify Ecertify { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRoles")]
    public virtual User User { get; set; } = null!;
}
