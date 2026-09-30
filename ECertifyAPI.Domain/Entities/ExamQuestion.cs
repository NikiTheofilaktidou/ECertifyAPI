using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

public partial class ExamQuestion
{
    [Key]
    [Column("ExamQuestionID")]
    public Guid ExamQuestionId { get; set; }

    [Column("ExamID")]
    public Guid ExamId { get; set; }

    [Column("QuestionID")]
    public Guid QuestionId { get; set; }

    [Column("SelectedChoiceID")]
    public Guid SelectedChoiceId { get; set; }

    [Column("ISCORRECT")]
    public bool? Iscorrect { get; set; }

    [Column("REVIEWLATER")]
    public bool? Reviewlater { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("ExamQuestions")]
    public virtual Exam Exam { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("ExamQuestions")]
    public virtual Question Question { get; set; } = null!;

    [ForeignKey("SelectedChoiceId")]
    [InverseProperty("ExamQuestions")]
    public virtual Choice SelectedChoice { get; set; } = null!;
}
