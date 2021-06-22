using Motionlab.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Motionlab
{
    /// <summary>
    /// this class contains methods that can call Rest API Motionlab intended for interviews. 
    /// Methods return objects that are deserialized using json from Rest API.
    /// </summary>
    public class InterviewTestAPI
    {
        public const string Url = "https://ralph.motionlab.io/";
       
        public static async Task<GetInterviewInfoRespond> GetInterviewInfoAsync(string Key) 
        {
            var clientHandler = new HttpClientHandler
            {
                UseCookies = false,
            };
            var client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Url}api/interviewInfo?apiKey={Key}")
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GetInterviewInfoRespond>(body);
        }

        public static async Task<PostInterviewTestRespond> PostInterviewTestAsync(string Email, string Name, string Token)
        {
            var clientHandler = new HttpClientHandler
            {
                UseCookies = false,
            };
            var client = new HttpClient(clientHandler);
            var SendJson = new PostInterviewTestInfo
            {
                email = Email,
                name = Name
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://ralph.motionlab.io/api/interviewTest"),
                Headers =
                {
                    { "Authorization", $"Bearer {Token}" }
                },
                //Content = new StringContent("{\n  \"email\": \"luke.pavelka@outlook.com\",\n  \"name\": \"Lukáš Pavelka\"\n}")
                Content = new StringContent(JsonSerializer.Serialize(SendJson))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PostInterviewTestRespond>(body);
        }
    }
}
