﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DrugPrevention.Repositories.DuyenCTT.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ProgramSurvey> ProgramSurveys { get; set; } = new List<ProgramSurvey>();

    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();

    public virtual ICollection<SurveyResult> SurveyResults { get; set; } = new List<SurveyResult>();
}