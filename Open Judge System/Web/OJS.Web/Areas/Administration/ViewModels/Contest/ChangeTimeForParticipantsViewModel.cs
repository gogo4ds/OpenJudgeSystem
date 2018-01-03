﻿namespace OJS.Web.Areas.Administration.ViewModels.Contest
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.SqlServer;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using OJS.Data.Models;

    using Resource = Resources.Areas.Administration.Contests.Views.ChangeTime;

    public class ChangeTimeForParticipantsViewModel
    {
        private const double DefaultBufferTimeInMinutes = 0.5;

        public static Expression<Func<Contest, ChangeTimeForParticipantsViewModel>> FromContest =>
            contest => new ChangeTimeForParticipantsViewModel
            {
                ContesId = contest.Id,
                ContestName = contest.Name,
                ParticipantsCreatedBeforeDateTime = DateTime.Now,
                ParticipantsCreatedAfterDateTime = SqlFunctions.DateAdd(
                    "hour", 
                    (contest.Duration.Value.Hours + DefaultBufferTimeInMinutes) * -1, 
                    DateTime.Now)
            };

        [HiddenInput(DisplayValue = false)]
        public int ContesId { get; set; }

        [Display(Name = "Contest", ResourceType = typeof(Resource))]
        public string ContestName { get; set; }

        [Display(Name = "Time_in_minutes", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Time_required_error", ErrorMessageResourceType = typeof(Resource))]
        public int TimeInMinutes { get; set; }

        [Display(Name = "Participants_created_after", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Time_required_error", ErrorMessageResourceType = typeof(Resource))]
        public DateTime? ParticipantsCreatedAfterDateTime { get; set; }

        [Display(Name = "Participants_created_before", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Time_required_error", ErrorMessageResourceType = typeof(Resource))]
        public DateTime? ParticipantsCreatedBeforeDateTime { get; set; }
    }
}