﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.Models;

public partial class BlogMinhLhcomment
{
    public int CommentId { get; set; }

    public int BlogMinhLhid { get; set; }

    public int? AuthorId { get; set; }

    public string CommentText { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BlogMinhLh BlogMinhLh { get; set; }
}