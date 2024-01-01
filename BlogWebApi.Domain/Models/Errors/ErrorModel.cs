using System.Collections.Generic;

namespace BlogWebApi.Domain.Models.Errors
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Errors = new List<ErrorDetailModel>();
        }

        public ErrorModel(string logRef, string message)
        {
            Errors = new List<ErrorDetailModel>();
            AddError(message);
        }
        

        public List<ErrorDetailModel> Errors { get; set; }

        public void AddError(string message)
        {
            Errors.Add(new ErrorDetailModel(message));
        }
    }

}
