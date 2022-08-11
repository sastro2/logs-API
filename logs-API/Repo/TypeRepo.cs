﻿using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Models.LogModels.Database;
using logs_API.Models.Response;

namespace logs_API.Repo
{
    public class TypeRepo : ITypes
    {
        public async Task<Error?> CreateType(DataContext context, string name, int projectId, bool sendImmediately)
        {
            var project = context.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project == null)
            {
                return new Error { Message = "Could not find project please make sure to pass an existing projectId with your type", ErrorCode = 0004 };
            }

            DbLogType newType = new () { Name = name, ProjectId = projectId, SendImmediately = sendImmediately };
            context.Types.Add(newType);

            await context.SaveChangesAsync();

            return null;
        }

        public Task<Error?> DeleteType(DataContext context, int id, int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
