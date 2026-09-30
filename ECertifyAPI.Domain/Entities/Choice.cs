using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

public partial class Choice
{
    [Key]
    [Column("ChoiceID")]
    public Guid ChoiceId { get; set; }

    [Column("QuestionID")]
    public Guid QuestionId { get; set; }

    public string ChoiceText { get; set; } = null!;

    public bool IsCode { get; set; }

    public bool IsCorrect { get; set; }

    [InverseProperty("SelectedChoice")]
    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    [ForeignKey("QuestionId")]
    [InverseProperty("Choices")]
    public virtual Question Question { get; set; } = null!;
}
