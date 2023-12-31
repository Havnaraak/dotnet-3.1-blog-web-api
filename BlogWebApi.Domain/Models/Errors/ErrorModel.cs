using BlogWebApi.Domain.Models.Errors;
using System;
using System.Collections.Generic;

namespace BlogWebApi.Domain.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailModel>();
        }

        public ErrorModel(string logRef, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailModel>();
            AddError(logRef, message);
        }

        public string TraceId { get; private set; }

        public List<ErrorDetailModel> Errors { get; set; }

        public void AddError(string logRef, string message)
        {
            Errors.Add(new ErrorDetailModel(logRef, message));
        }
    }

}
