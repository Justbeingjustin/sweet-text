using SweetTextV2.Models;

namespace SweetTextV2.Services
{
    public interface ITextMessageService
    {
        void SendTextMessage(IMessage message);
    }
}