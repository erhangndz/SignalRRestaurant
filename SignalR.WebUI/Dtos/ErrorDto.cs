namespace SignalR.WebUI.Dtos
{
    public class ErrorDto
    {

       
            public string type { get; set; }
            public string title { get; set; }
            public int status { get; set; }
            public Errors errors { get; set; }
            public string traceId { get; set; }
        

        public class Errors
        {
            public string[] Title { get; set; }
            public string[] ImageUrl { get; set; }
            public string[] Description { get; set; }
        }

    }
}
