﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EFCoreRepro.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Children = new HashSet<Child>();
        }

        public long? Id { get; set; }
        public Guid ParentId { get; set; }

        public virtual ICollection<Child> Children { get; set; } = new List<Child>();
    }
}