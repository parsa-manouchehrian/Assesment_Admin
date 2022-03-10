using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminPanel.Models
{
    public partial class AssessmentDBContext : DbContext
    {
        public AssessmentDBContext()
        {
        }

        public AssessmentDBContext(DbContextOptions<AssessmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assessment> Assessments { get; set; } = null!;
        public virtual DbSet<AssessmentResultGroup> AssessmentResultGroups { get; set; } = null!;
        public virtual DbSet<AssessmentUserResult> AssessmentUserResults { get; set; } = null!;
        public virtual DbSet<AssessmentsQuestion> AssessmentsQuestions { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Operator> Operators { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<PhoneValidation> PhoneValidations { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionType> QuestionTypes { get; set; } = null!;
        public virtual DbSet<ResetPasswordRequest> ResetPasswordRequests { get; set; } = null!;
        public virtual DbSet<ResultTip> ResultTips { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<UserOptionAnswer> UserOptionAnswers { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=142.44.243.3;Database=AssessmentDB;User=sa;password=SA123!@#asd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasIndex(e => e.AssessmentResultGroupsId, "IX_Assessments_AssessmentResultGroupsId");

                entity.HasIndex(e => e.SubjectId, "IX_Assessments_SubjectId");

                entity.HasIndex(e => e.UserId, "IX_Assessments_UserId");

                entity.HasOne(d => d.AssessmentResultGroups)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.AssessmentResultGroupsId);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.SubjectId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AssessmentUserResult>(entity =>
            {
                entity.HasIndex(e => e.AssessmentId, "IX_AssessmentUserResults_AssessmentId");

                entity.HasIndex(e => e.AssessmentResultGroupId, "IX_AssessmentUserResults_AssessmentResultGroupId");

                entity.HasIndex(e => e.UserId, "IX_AssessmentUserResults_UserId");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentUserResults)
                    .HasForeignKey(d => d.AssessmentId);

                entity.HasOne(d => d.AssessmentResultGroup)
                    .WithMany(p => p.AssessmentUserResults)
                    .HasForeignKey(d => d.AssessmentResultGroupId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssessmentUserResults)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AssessmentsQuestion>(entity =>
            {
                entity.HasIndex(e => e.AssessmentId, "IX_AssessmentsQuestions_AssessmentId");

                entity.HasIndex(e => e.QuestionId, "IX_AssessmentsQuestions_QuestionId");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentsQuestions)
                    .HasForeignKey(d => d.AssessmentId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentsQuestions)
                    .HasForeignKey(d => d.QuestionId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasIndex(e => e.AssessmentResultGroupsId, "IX_Options_AssessmentResultGroupsId");

                entity.HasIndex(e => e.CurrentQuestionId, "IX_Options_CurrentQuestionId");

                entity.HasIndex(e => e.NextQuestionId, "IX_Options_NextQuestionId");

                entity.HasOne(d => d.AssessmentResultGroups)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.AssessmentResultGroupsId);

                entity.HasOne(d => d.CurrentQuestion)
                    .WithMany(p => p.OptionCurrentQuestions)
                    .HasForeignKey(d => d.CurrentQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.NextQuestion)
                    .WithMany(p => p.OptionNextQuestions)
                    .HasForeignKey(d => d.NextQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PhoneValidation>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_PhoneValidations_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PhoneValidations)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Provinces_CountryId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasIndex(e => e.NextQuestionId, "IX_Questions_NextQuestionId");

                entity.HasIndex(e => e.QuestionTypeName, "IX_Questions_QuestionTypeName");

                entity.HasOne(d => d.NextQuestion)
                    .WithMany(p => p.InverseNextQuestion)
                    .HasForeignKey(d => d.NextQuestionId);

                entity.HasOne(d => d.QuestionTypeNameNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeName);
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("QuestionType");
            });

            modelBuilder.Entity<ResetPasswordRequest>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_ResetPasswordRequests_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ResetPasswordRequests)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ResultTip>(entity =>
            {
                entity.HasIndex(e => e.AssessmentResultGroupId, "IX_ResultTips_AssessmentResultGroupId");

                entity.HasOne(d => d.AssessmentResultGroup)
                    .WithMany(p => p.ResultTips)
                    .HasForeignKey(d => d.AssessmentResultGroupId);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.FirstQuestionId, "IX_Subjects_FirstQuestionId");

                entity.HasOne(d => d.FirstQuestion)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.FirstQuestionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.ProvinceId, "IX_Users_ProvinceId");

                entity.HasIndex(e => e.UserStatusName, "IX_Users_UserStatusName");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HasAcceptAgreement)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProvinceId);

                entity.HasOne(d => d.UserStatusNameNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusName);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserOptionAnswer>(entity =>
            {
                entity.HasIndex(e => e.AssessmentId, "IX_UserOptionAnswers_AssessmentId");

                entity.HasIndex(e => e.OptionsId, "IX_UserOptionAnswers_OptionsId");

                entity.HasIndex(e => e.UserId, "IX_UserOptionAnswers_UserId");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.UserOptionAnswers)
                    .HasForeignKey(d => d.AssessmentId);

                entity.HasOne(d => d.Options)
                    .WithMany(p => p.UserOptionAnswers)
                    .HasForeignKey(d => d.OptionsId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOptionAnswers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.HasKey(e => e.Name);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
