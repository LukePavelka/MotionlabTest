using System;
using System.Threading.Tasks;

namespace Motionlab
{
    /// <summary>
    /// Main class for working with request api, method encapsulation, storing request to database.
    /// </summary>
    public class InterviewTest
    {
        public string Key { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public bool IsSuccessful { get; private set; }
        private API.GetInterviewInfoRespond FirstRequest { get; set; }
        public API.PostInterviewTestRespond SecondaryRequest { get; private set; }
        public Exception Error { get; private set; }

        public InterviewTest(string Key, string Email, string Name)
        {
            this.Key = Key;
            this.Email = Email;
            this.Name = Name;
        }

        private async Task<API.GetInterviewInfoRespond> GetAuthorizationTokenAsync() 
        {
            API.GetInterviewInfoRespond HttpRequestToken = null;
            try
            {
                HttpRequestToken = await InterviewTestAPI.GetInterviewInfoAsync(this.Key);
            }
            catch (Exception e)
            {
                this.Error = e;
            }
            finally
            {
                this.IsSuccessful = false;
            }
            return HttpRequestToken;
        }

        public async Task<API.PostInterviewTestRespond> SendApplicationAsync() 
        {
            this.FirstRequest = await GetAuthorizationTokenAsync();

            API.PostInterviewTestRespond FinalRequest = null;

            if (this.Error == null)
            {
                try
                {
                    FinalRequest = await InterviewTestAPI.PostInterviewTestAsync(this.Email, this.Name, this.FirstRequest.authorization.access_token);
                }
                catch (Exception e)
                {
                    this.Error = e;
                }
                finally
                {
                    this.IsSuccessful = false;
                }
                this.SecondaryRequest = FinalRequest;
            }
            if (FinalRequest != null)
            {
                this.IsSuccessful = true;
            }
            await this.DbSaveAsync();
            return FinalRequest;
        }

        private async Task DbSaveAsync()
        {
            using var db = new DB.InterviewTestContext();
            var Entry = new DB.InterviewTestDb
            {
                Key = this.Key,
                Email = this.Email,
                Name = this.Name,
                IsSuccessful = this.IsSuccessful,
            };

            if (this.FirstRequest != null)
            {
                Entry.FirstRequest = this.FirstRequest;
            }
            if (this.SecondaryRequest != null)
            {
                Entry.SecondaryRequest = this.SecondaryRequest;
            }
            if (this.Error != null)
            {
                Entry.Error = this.Error.ToString();
            }

            await DB.InterviewTestControl.SaveAsync(Entry);
        }
    }
}