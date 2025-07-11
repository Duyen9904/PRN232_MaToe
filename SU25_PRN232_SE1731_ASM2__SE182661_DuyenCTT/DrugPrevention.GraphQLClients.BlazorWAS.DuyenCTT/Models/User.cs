﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AppointmentMinhPp> AppointmentMinhPps { get; set; } = new List<AppointmentMinhPp>();

    public virtual ICollection<BlogMinhLh> BlogMinhLhs { get; set; } = new List<BlogMinhLh>();

    public virtual ICollection<CommunityProgramKhoaNdd> CommunityProgramKhoaNddCreatedByNavigations { get; set; } = new List<CommunityProgramKhoaNdd>();

    public virtual ICollection<CommunityProgramKhoaNdd> CommunityProgramKhoaNddEditedByNavigations { get; set; } = new List<CommunityProgramKhoaNdd>();

    public virtual ConsultantMinhPp ConsultantMinhPp { get; set; }

    public virtual ICollection<CourseEnrollmentDuyenCtt> CourseEnrollmentDuyenCtts { get; set; } = new List<CourseEnrollmentDuyenCtt>();

    public virtual ICollection<ProgramParticipantKhoaNdd> ProgramParticipantKhoaNdds { get; set; } = new List<ProgramParticipantKhoaNdd>();

    public virtual ICollection<QuestionBank> QuestionBanks { get; set; } = new List<QuestionBank>();

    public virtual Role Role { get; set; }

    public virtual ICollection<SurveyAssignment> SurveyAssignments { get; set; } = new List<SurveyAssignment>();

    public virtual ICollection<SurveyDuongNd> SurveyDuongNdCreatedByUsers { get; set; } = new List<SurveyDuongNd>();

    public virtual ICollection<SurveyDuongNd> SurveyDuongNdLastModifiedByUsers { get; set; } = new List<SurveyDuongNd>();

    public virtual ICollection<SurveyResultDuongNd> SurveyResultDuongNdReviewedByUsers { get; set; } = new List<SurveyResultDuongNd>();

    public virtual ICollection<SurveyResultDuongNd> SurveyResultDuongNdUsers { get; set; } = new List<SurveyResultDuongNd>();
}