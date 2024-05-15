using MextFullStack.Domain.Enums;

namespace MextFullStack.Domain.Dtos
{
    public class GptChatMessage
    {
        public GptChatMessageType MessageType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }

        public GptChatMessage(string message, GptChatMessageType messageType)
        {
            Message = message;

            MessageType = messageType;

            CreatedOn = DateTime.Now;
        }

        public GptChatMessage()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
