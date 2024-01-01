namespace BlogWebApi.Domain.Models.Errors
{
    public class ErrorDetailModel
    {
        public string Message { get; private set; }

        public ErrorDetailModel(string message)
        {
            Message = message;
        }
    }
}
