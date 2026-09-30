using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

[Table("ECertify")]
public partial class Ecertify
{
    [Key]
    [Column("ECertifyID")]
    public Guid EcertifyId { get; set; }

    [InverseProperty("Ecertify")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
