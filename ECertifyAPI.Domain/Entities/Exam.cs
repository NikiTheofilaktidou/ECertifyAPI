using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

[Table("EXAMS")]
public partial class Exam
{
    [Key]
    [Column("ExamID")]
    public Guid ExamId { get; set; }

    [Column("CourseID")]
    public Guid CourseId { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    public DateTime StartedOn { get; set; }

    public DateTime? FinishedOn { get; set; }

    [StringLength(2000)]
    public string? Feedback { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Exams")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Exam")]
    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    [ForeignKey("UserId")]
    [InverseProperty("Exams")]
    public virtual User User { get; set; } = null!;
}
