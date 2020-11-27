namespace TeApp.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }

        public ErrorModel(string message)
        {
            this.Message = message;
        }
    }
}
