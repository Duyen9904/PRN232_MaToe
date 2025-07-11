﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
namespace DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.Models;

public partial class SurveyOptionManhPt
{
    public int OptionId { get; set; }

    public int QuestionId { get; set; }

    public string OptionText { get; set; }

    public decimal? Score { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsCorrectAnswer { get; set; }

    public string FeedbackIfSelected { get; set; }

    public string ImageUrl { get; set; }

    public virtual SurveyQuestionManhPt Question { get; set; }

    public virtual ICollection<SurveyAnswerDuongNd> SurveyAnswerDuongNds { get; set; } = new List<SurveyAnswerDuongNd>();
}