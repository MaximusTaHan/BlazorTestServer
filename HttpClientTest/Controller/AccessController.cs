using System.Text;
using HttpClientTest.Models;

namespace HttpClientTest.Controller
{
    public class EncoderClass
    {
        public static string Base64Encode(string configToEncode)
        {
            byte[] configToBytes = Encoding.UTF8.GetBytes(configToEncode);
            return Convert.ToBase64String(configToBytes);
        }
    }
    public class TokenTracker
    {
        public AccessModel responseInfo;
        public string errorString;
        
        public async Task RetrievePost(IHttpClientFactory _clientFactory)
        {

            var data = new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", "testScope"),
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "token") 
            {
                // sets the content of the request body
                Content = new FormUrlEncodedContent(data)
            };
            var client = _clientFactory.CreateClient("vast");

            HttpResponseMessage response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                responseInfo = await response.Content.ReadFromJsonAsync<AccessModel>();
                errorString = null;
            }
            else
            {
                errorString = $"There was an error getting our access: { response.ReasonPhrase }";
            }
        }
    }
}

