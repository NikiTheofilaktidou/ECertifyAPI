using ECertifyAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECertifyAPI.Infrastructure;

public partial class EcertifyContext : DbContext
{
    public EcertifyContext()
    {
    }

    public EcertifyContext(DbContextOptions<EcertifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BannerInfo> BannerInfos { get; set; }

    public virtual DbSet<Choice> Choices { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Ecertify> Ecertifies { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BannerInfo>(entity =>
        {
            entity.HasKey(e => e.BannerId).HasName("PK_BannerInfo_BannerID");

            entity.Property(e => e.BannerId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())", "DF_BannerInfo_CreatedOn");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Choice>(entity =>
        {
            entity.HasKey(e => e.ChoiceId).HasName("PK_Choices_ChoiceID");

            entity.Property(e => e.ChoiceId).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.Question).WithMany(p => p.Choices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Choices_QuestionID");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.ContactUsId).HasName("PK_ContactUs_ContactUsID");

            entity.Property(e => e.ContactUsId).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Courses_CourseID");

            entity.Property(e => e.CourseId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())", "DF_Courses_CreatedOn");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_CreatedBy");
        });

        modelBuilder.Entity<Ecertify>(entity =>
        {
            entity.HasKey(e => e.EcertifyId).HasName("PK_Roles_ECertifyID");

            entity.Property(e => e.EcertifyId).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK_Exams_ExamID");

            entity.Property(e => e.ExamId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.StartedOn).HasDefaultValueSql("(getdate())", "DF_Exams_StartedOn");
            entity.Property(e => e.Status).HasDefaultValue("In Progress");

            entity.HasOne(d => d.Course).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_CourseID");

            entity.HasOne(d => d.User).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_UserID");
        });

        modelBuilder.Entity<ExamQuestion>(entity =>
        {
            entity.HasKey(e => e.ExamQuestionId).HasName("PK_ExamQuestions_ExamQuestionsID");

            entity.Property(e => e.ExamQuestionId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Reviewlater).HasDefaultValue(false);

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamQuestions_ExamID");

            entity.HasOne(d => d.Question).WithMany(p => p.ExamQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamQuestions_QuestionID");

            entity.HasOne(d => d.SelectedChoice).WithMany(p => p.ExamQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamQuestions_SelectedChoiceID");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK_Notification_NotificationID");

            entity.Property(e => e.NotificationId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())", "df_notification_createdon");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK_Questions_QuestionID");

            entity.Property(e => e.QuestionId).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.Course).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_CourseID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_Roles_RoleID");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.AdObjId).HasDefaultValue("Unknown", "DF_Users_AdObjID");
            entity.Property(e => e.DisplayName).HasDefaultValue("Guest", "DF_Users_DisplayName");
        });

        modelBuilder.Entity<UserActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_UserActivityLog_LogID");

            entity.Property(e => e.LogId).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserActivityLog_UserID");
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.HasKey(e => e.UserNotificationId).HasName("PK_UserNotifications_UserNotificationID");

            entity.Property(e => e.UserNotificationId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())", "DF_UserNotifications_CreatedOn");

            entity.HasOne(d => d.Notification).WithMany(p => p.UserNotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserNotifications_NotificationID");

            entity.HasOne(d => d.User).WithMany(p => p.UserNotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserNotifications_UserID");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK_UserRoles_UserRoleID");

            entity.Property(e => e.UserRoleId).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.Ecertify).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_ECertify");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
