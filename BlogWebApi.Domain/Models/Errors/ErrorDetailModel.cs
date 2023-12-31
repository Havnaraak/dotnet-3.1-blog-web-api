namespace BlogWebApi.Domain.Models.Errors
{
    public class ErrorDetailModel
    {
        public string LogRef { get; private set; }

        public string Message { get; private set; }

        public ErrorDetailModel(string logRef, string message)
        {
            LogRef = logRef;
            Message = message;
        }
    }
}
