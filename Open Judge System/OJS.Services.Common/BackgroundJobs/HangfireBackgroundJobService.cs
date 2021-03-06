﻿namespace OJS.Services.Common.BackgroundJobs
{
    using System;
    using System.Linq.Expressions;

    using Hangfire;

    public class HangfireBackgroundJobService : IHangfireBackgroundJobService
    {
        public void AddOrUpdateRecurringJob(
            object recurringJobId,
            Expression<Action> methodCall,
            string cronExpression) => RecurringJob.AddOrUpdate((string)recurringJobId, methodCall, cronExpression);

        public void AddOrUpdateRecurringJob<T>(
            object recurringJobId,
            Expression<Action<T>> methodCall,
            string cronExpression) => RecurringJob.AddOrUpdate((string)recurringJobId, methodCall, cronExpression);
    }
}