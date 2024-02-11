namespace SignalR.WebUI.ClientHandler
{
    public static class HttpClientInstance
    {
        
        public static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress= new Uri("https://localhost:7135/api/");

            return client;
        }
    }
}
