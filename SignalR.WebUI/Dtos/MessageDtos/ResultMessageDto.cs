namespace SignalR.WebUI.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }

        public bool isRead { get; set; }
    }
}
