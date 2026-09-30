using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Domain.Entities;

public partial class Question
{
    [Key]
    [Column("QuestionID")]
    public Guid QuestionId { get; set; }

    [Column("CourseID")]
    public Guid CourseId { get; set; }

    public string QuestionText { get; set; } = null!;

    [StringLength(20)]
    public string DifficultyLevel { get; set; } = null!;

    public bool IsCode { get; set; }

    public bool HasMultipleAnswers { get; set; }

    [InverseProperty("Question")]
    public virtual ICollection<Choice> Choices { get; set; } = new List<Choice>();

    [ForeignKey("CourseId")]
    [InverseProperty("Questions")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
}
