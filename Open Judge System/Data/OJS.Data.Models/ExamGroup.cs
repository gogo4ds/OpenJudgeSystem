﻿namespace OJS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OJS.Common;

    public class ExamGroup
    {
        [Key]
        public int Id { get; set; }

        public int? ExternalExamGroupId { get; set; }

        public string ExternalAppId { get; set; }

        [Required]
        [MinLength(GlobalConstants.ExamGroupNameMinLength)]
        [MaxLength(GlobalConstants.ExamGroupNameMaxLength)]
        public string NameBg { get; set; }

        [Required]
        [MinLength(GlobalConstants.ExamGroupNameMinLength)]
        [MaxLength(GlobalConstants.ExamGroupNameMaxLength)]
        public string NameEn { get; set; }

        public int? ContestId { get; set; }

        public virtual Contest Contest { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; } = new HashSet<UserProfile>();
    }
}