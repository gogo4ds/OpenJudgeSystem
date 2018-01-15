﻿namespace OJS.Services.Data.ExamGroups
{
    using OJS.Data.Models;
    using OJS.Services.Common;

    public interface IExamGroupsDataService : IService
    {
        void Add(ExamGroup examGroup);

        void Update(ExamGroup examGroup);

        ExamGroup GetByExternalIdAndAppId(int? externalId, string appId);
    }
}