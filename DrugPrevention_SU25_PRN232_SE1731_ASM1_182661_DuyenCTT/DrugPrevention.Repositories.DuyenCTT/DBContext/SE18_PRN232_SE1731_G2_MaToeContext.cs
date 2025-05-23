﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using DrugPrevention.Repositories.DuyenCTT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DrugPrevention.Repositories.DuyenCTT.DBContext;

public partial class SE18_PRN232_SE1731_G2_MaToeContext : DbContext
{
    public SE18_PRN232_SE1731_G2_MaToeContext()
    {
    }

    public SE18_PRN232_SE1731_G2_MaToeContext(DbContextOptions<SE18_PRN232_SE1731_G2_MaToeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentMinhPp> AppointmentMinhPps { get; set; }

    public virtual DbSet<BlogMinhLh> BlogMinhLhs { get; set; }

    public virtual DbSet<BlogMinhLhcomment> BlogMinhLhcomments { get; set; }

    public virtual DbSet<CommunityProgramKhoaNdd> CommunityProgramKhoaNdds { get; set; }

    public virtual DbSet<ConsultantAvailability> ConsultantAvailabilities { get; set; }

    public virtual DbSet<ConsultantMinhPp> ConsultantMinhPps { get; set; }

    public virtual DbSet<CourseDuyenCtt> CourseDuyenCtts { get; set; }

    public virtual DbSet<CourseEnrollmentDuyenCtt> CourseEnrollmentDuyenCtts { get; set; }

    public virtual DbSet<ProgramParticipantKhoaNdd> ProgramParticipantKhoaNdds { get; set; }

    public virtual DbSet<ProgramSurvey> ProgramSurveys { get; set; }

    public virtual DbSet<QuestionBank> QuestionBanks { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SurveyAnswerDuongNd> SurveyAnswerDuongNds { get; set; }

    public virtual DbSet<SurveyAssignment> SurveyAssignments { get; set; }

    public virtual DbSet<SurveyDuongNd> SurveyDuongNds { get; set; }

    public virtual DbSet<SurveyOptionManhPt> SurveyOptionManhPts { get; set; }

    public virtual DbSet<SurveyQuestionManhPt> SurveyQuestionManhPts { get; set; }

    public virtual DbSet<SurveyResultDuongNd> SurveyResultDuongNds { get; set; }

    public virtual DbSet<SystemUserAccount> SystemUserAccounts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=duyen9904\\SQLEXPRESS;Initial Catalog=SE18_PRN232_SE1731_G2_MaToe;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentMinhPp>(entity =>
        {
            entity.HasKey(e => e.AppointmentMinhPpid).HasName("PK__Appointm__F658C78C9E0BC235");

            entity.ToTable("AppointmentMinhPP");

            entity.Property(e => e.AppointmentMinhPpid).HasColumnName("AppointmentMinhPPId");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Consultant).WithMany(p => p.AppointmentMinhPps)
                .HasForeignKey(d => d.ConsultantId)
                .HasConstraintName("FK__Appointme__Consu__0F624AF8");

            entity.HasOne(d => d.User).WithMany(p => p.AppointmentMinhPps)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Appointme__UserI__0E6E26BF");
        });

        modelBuilder.Entity<BlogMinhLh>(entity =>
        {
            entity.HasKey(e => e.BlogMinhLhid).HasName("PK__BlogMinh__DF36E58A866CCA17");

            entity.ToTable("BlogMinhLH");

            entity.Property(e => e.BlogMinhLhid).HasColumnName("BlogMinhLHId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Draft");
            entity.Property(e => e.Summary).HasMaxLength(500);
            entity.Property(e => e.Tags).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Views).HasDefaultValue(0);

            entity.HasOne(d => d.Author).WithMany(p => p.BlogMinhLhs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__BlogMinhL__Autho__403A8C7D");
        });

        modelBuilder.Entity<BlogMinhLhcomment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__BlogMinh__C3B4DFCA346214F3");

            entity.ToTable("BlogMinhLHComment");

            entity.Property(e => e.BlogMinhLhid).HasColumnName("BlogMinhLHId");
            entity.Property(e => e.CommentText).IsRequired();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.BlogMinhLh).WithMany(p => p.BlogMinhLhcomments)
                .HasForeignKey(d => d.BlogMinhLhid)
                .HasConstraintName("FK_BlogMinhLHComment_BlogMinhLH");
        });

        modelBuilder.Entity<CommunityProgramKhoaNdd>(entity =>
        {
            entity.HasKey(e => e.CommunityProgramKhoaNddid).HasName("PK__Communit__9B982E399B7D74AB");

            entity.ToTable("CommunityProgramKhoaNDD");

            entity.Property(e => e.CommunityProgramKhoaNddid).HasColumnName("CommunityProgramKhoaNDDId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastEditedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TargetGroup).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CommunityProgramKhoaNddCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Community__Creat__151B244E");

            entity.HasOne(d => d.EditedByNavigation).WithMany(p => p.CommunityProgramKhoaNddEditedByNavigations)
                .HasForeignKey(d => d.EditedBy)
                .HasConstraintName("FK__Community__Edite__160F4887");
        });

        modelBuilder.Entity<ConsultantAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__Consulta__DA3979B16D427C78");

            entity.ToTable("ConsultantAvailability");

            entity.HasOne(d => d.Consultant).WithMany(p => p.ConsultantAvailabilities)
                .HasForeignKey(d => d.ConsultantId)
                .HasConstraintName("FK__Consultan__Consu__0B91BA14");
        });

        modelBuilder.Entity<ConsultantMinhPp>(entity =>
        {
            entity.HasKey(e => e.ConsultantMinhPpid).HasName("PK__Consulta__25EBB06950355AB1");

            entity.ToTable("ConsultantMinhPP");

            entity.HasIndex(e => e.UserId, "UQ__Consulta__1788CC4D6763D5E8").IsUnique();

            entity.Property(e => e.ConsultantMinhPpid).HasColumnName("ConsultantMinhPPId");
            entity.Property(e => e.Specialization).HasMaxLength(255);

            entity.HasOne(d => d.User).WithOne(p => p.ConsultantMinhPp)
                .HasForeignKey<ConsultantMinhPp>(d => d.UserId)
                .HasConstraintName("FK__Consultan__UserI__08B54D69");
        });

        modelBuilder.Entity<CourseDuyenCtt>(entity =>
        {
            entity.HasKey(e => e.CourseDuyenCttid).HasName("PK__CourseDu__92E5DB88CC076C02");

            entity.ToTable("CourseDuyenCTT");

            entity.Property(e => e.CourseDuyenCttid).HasColumnName("CourseDuyenCTTId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TargetGroup).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<CourseEnrollmentDuyenCtt>(entity =>
        {
            entity.HasKey(e => e.EnrollmentDuyenCttid).HasName("PK__CourseEn__2BD149986F7C7E83");

            entity.ToTable("CourseEnrollmentDuyenCTT");

            entity.Property(e => e.EnrollmentDuyenCttid).HasColumnName("EnrollmentDuyenCTTId");
            entity.Property(e => e.CertificateUrl).HasMaxLength(500);
            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.EnrolledAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EnrollmentSource).HasMaxLength(100);
            entity.Property(e => e.IsCertified).HasDefaultValue(false);
            entity.Property(e => e.Progress).HasDefaultValue(0);
            entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrollmentDuyenCtts)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__CourseEnr__Cours__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.CourseEnrollmentDuyenCtts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CourseEnr__UserI__4CA06362");
        });

        modelBuilder.Entity<ProgramParticipantKhoaNdd>(entity =>
        {
            entity.HasKey(e => e.ProgramParticipantKhoaNddid).HasName("PK__ProgramP__2AD8D8994A68D40E");

            entity.ToTable("ProgramParticipantKhoaNDD");

            entity.Property(e => e.ProgramParticipantKhoaNddid).HasColumnName("ProgramParticipantKhoaNDDId");
            entity.Property(e => e.JoinedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramParticipantKhoaNdds)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProgramPa__Progr__18EBB532");

            entity.HasOne(d => d.User).WithMany(p => p.ProgramParticipantKhoaNdds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProgramPa__UserI__19DFD96B");
        });

        modelBuilder.Entity<ProgramSurvey>(entity =>
        {
            entity.HasKey(e => e.ProgramSurveyId).HasName("PK__ProgramS__A9FC9B0ED23ABB60");

            entity.ToTable("ProgramSurvey");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramSurveys)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__ProgramSu__Progr__1DB06A4F");

            entity.HasOne(d => d.Survey).WithMany(p => p.ProgramSurveys)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("FK__ProgramSu__Surve__1EA48E88");
        });

        modelBuilder.Entity<QuestionBank>(entity =>
        {
            entity.HasKey(e => e.BankQuestionId).HasName("PK__Question__FB3CD73E3E639D53");

            entity.ToTable("QuestionBank");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsArchived).HasDefaultValue(false);
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .HasDefaultValue("en-US");
            entity.Property(e => e.LastModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.QuestionText).IsRequired();
            entity.Property(e => e.QuestionType)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SubCategory).HasMaxLength(100);
            entity.Property(e => e.SuggestedOptionsJson).HasColumnName("SuggestedOptionsJSON");
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.Version).HasDefaultValue(1);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.QuestionBanks)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__QuestionB__Creat__6754599E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A3465B7AA");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B6160B14A57D8").IsUnique();

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<SurveyAnswerDuongNd>(entity =>
        {
            entity.HasKey(e => e.AnswerDuongNdid).HasName("PK__SurveyAn__0D07D7764D14A042");

            entity.ToTable("SurveyAnswerDuongND");

            entity.Property(e => e.AnswerDuongNdid).HasColumnName("AnswerDuongNDID");
            entity.Property(e => e.AnswerScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.AnsweredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Option).WithMany(p => p.SurveyAnswerDuongNds)
                .HasForeignKey(d => d.OptionId)
                .HasConstraintName("FK__SurveyAns__Optio__03F0984C");

            entity.HasOne(d => d.Question).WithMany(p => p.SurveyAnswerDuongNds)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SurveyAns__Quest__02FC7413");

            entity.HasOne(d => d.Result).WithMany(p => p.SurveyAnswerDuongNds)
                .HasForeignKey(d => d.ResultId)
                .HasConstraintName("FK__SurveyAns__Resul__02084FDA");
        });

        modelBuilder.Entity<SurveyAssignment>(entity =>
        {
            entity.HasKey(e => e.SurveyAssignmentId).HasName("PK__SurveyAs__C93307D5ABC53D49");

            entity.ToTable("SurveyAssignment");

            entity.HasIndex(e => new { e.SurveyId, e.UserId, e.RoleInSurvey }, "UQ_SurveyAssignment_SurveyUserRole").IsUnique();

            entity.Property(e => e.AssignmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActiveAssignment).HasDefaultValue(true);
            entity.Property(e => e.RoleInSurvey)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyAssignments)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("FK__SurveyAss__Surve__5FB337D6");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyAssignments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SurveyAss__UserI__60A75C0F");
        });

        modelBuilder.Entity<SurveyDuongNd>(entity =>
        {
            entity.HasKey(e => e.SurveyDuongNdid).HasName("PK__SurveyDu__1CC1898F9154DD01");

            entity.ToTable("SurveyDuongND");

            entity.Property(e => e.SurveyDuongNdid).HasColumnName("SurveyDuongNDID");
            entity.Property(e => e.AnonymityLevel).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Purpose).HasMaxLength(1000);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Draft");
            entity.Property(e => e.SurveyGuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SurveyGUID");
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.Version).HasDefaultValue(1);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.SurveyDuongNdCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__SurveyDuo__Creat__571DF1D5");

            entity.HasOne(d => d.LastModifiedByUser).WithMany(p => p.SurveyDuongNdLastModifiedByUsers)
                .HasForeignKey(d => d.LastModifiedByUserId)
                .HasConstraintName("FK__SurveyDuo__LastM__5812160E");

            entity.HasOne(d => d.ParentSurvey).WithMany(p => p.InverseParentSurvey)
                .HasForeignKey(d => d.ParentSurveyId)
                .HasConstraintName("FK__SurveyDuo__Paren__5BE2A6F2");
        });

        modelBuilder.Entity<SurveyOptionManhPt>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__SurveyOp__92C7A1FFC90B6EA6");

            entity.ToTable("SurveyOptionManhPT");

            entity.Property(e => e.ImageUrl).HasMaxLength(1024);
            entity.Property(e => e.OptionText).IsRequired();
            entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Question).WithMany(p => p.SurveyOptionManhPts)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__SurveyOpt__Quest__76969D2E");
        });

        modelBuilder.Entity<SurveyQuestionManhPt>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__SurveyQu__0DC06FAC4C2D8C0C");

            entity.ToTable("SurveyQuestionManhPT");

            entity.Property(e => e.ConditionsJson).HasColumnName("ConditionsJSON");
            entity.Property(e => e.HintText).HasMaxLength(500);
            entity.Property(e => e.IsMandatory).HasDefaultValue(false);
            entity.Property(e => e.PageNumber).HasDefaultValue(1);
            entity.Property(e => e.PointsPossible).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.QuestionText).IsRequired();
            entity.Property(e => e.QuestionType)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SectionTitle).HasMaxLength(255);

            entity.HasOne(d => d.BankQuestion).WithMany(p => p.SurveyQuestionManhPts)
                .HasForeignKey(d => d.BankQuestionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__SurveyQue__BankQ__6FE99F9F");

            entity.HasOne(d => d.ParentQuestion).WithMany(p => p.InverseParentQuestion)
                .HasForeignKey(d => d.ParentQuestionId)
                .HasConstraintName("FK__SurveyQue__Paren__73BA3083");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestionManhPts)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("FK__SurveyQue__Surve__6EF57B66");
        });

        modelBuilder.Entity<SurveyResultDuongNd>(entity =>
        {
            entity.HasKey(e => e.ResultDuongNdid).HasName("PK__SurveyRe__D1C0F455AECCBC1D");

            entity.ToTable("SurveyResultDuongND");

            entity.Property(e => e.ResultDuongNdid).HasColumnName("ResultDuongNDID");
            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.DurationSeconds).HasComputedColumnSql("(datediff(second,[TakenAt],[CompletedAt]))", true);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ReviewStatus).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("InProgress");
            entity.Property(e => e.TakenAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalScore).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserAgent).HasMaxLength(255);

            entity.HasOne(d => d.ReviewedByUser).WithMany(p => p.SurveyResultDuongNdReviewedByUsers)
                .HasForeignKey(d => d.ReviewedByUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__SurveyRes__Revie__7F2BE32F");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyResultDuongNds)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SurveyRes__Surve__797309D9");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyResultDuongNdUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SurveyRes__UserI__7A672E12");
        });

        modelBuilder.Entity<SystemUserAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("System.UserAccount");

            entity.Property(e => e.ApplicationCode).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.RequestCode).HasMaxLength(50);
            entity.Property(e => e.UserAccountId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserAccountID");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C80671BAC");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053409B9E782").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}