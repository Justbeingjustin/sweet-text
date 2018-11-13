namespace SweetTextV2.Models
{
    public class EmptyMessage : IMessage
    {
        public string Message { get; set; } = "There are no more sweet messages.";
    }
}