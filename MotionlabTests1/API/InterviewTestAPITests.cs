using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionlab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Motionlab.Tests
{
    [TestClass()]
    public class InterviewTestAPITests
    {
        private const string ValidKey = "8743f41d-98c6-4578-9d7b-611af96a16ba";
        private const string NotValidKey = "12341234-1234-1234-1234-111222334515";
        [TestMethod()]
        public async Task GetInterviewInfoAsyncTest1()
        {
            var HttpRequest1 = await InterviewTestAPI.GetInterviewInfoAsync(ValidKey);
            Assert.IsNotNull(HttpRequest1.authorization);
        }
        [TestMethod()]
        public void GetInterviewInfoAsyncTest2()
        {
            Assert.ThrowsExceptionAsync<HttpRequestException>(async () => await InterviewTestAPI.GetInterviewInfoAsync(""));
        }
        [TestMethod()]
        public void GetInterviewInfoAsyncTest3()
        {
            Assert.ThrowsExceptionAsync<HttpRequestException>(async () => await InterviewTestAPI.GetInterviewInfoAsync(NotValidKey));
        }
        [TestMethod()]
        public void GetInterviewInfoAsyncTest4()
        {
            Assert.ThrowsExceptionAsync<HttpRequestException>(async () => await InterviewTestAPI.GetInterviewInfoAsync(" Testing "));
        }

        [TestMethod()]
        public async Task PostInterviewTestAsyncTest1()
        {
            var Token = await InterviewTestAPI.GetInterviewInfoAsync(ValidKey);
            var Request = await InterviewTestAPI.PostInterviewTestAsync("luke.pavelka@outlook.com", "Lukáš Pavelka - C#", Token.authorization.access_token);
            Assert.IsNotNull(Request.confirmationText);
        }
        [TestMethod()]
        public void PostInterviewTestAsyncTest2()
        {
            Assert.ThrowsExceptionAsync<HttpRequestException>(async () => await InterviewTestAPI.PostInterviewTestAsync("luke.pavelka@outlook.com", "Lukáš Pavelka - C#", NotValidKey));
        }
        [TestMethod()]
        public void PostInterviewTestAsyncTest3()
        {
            Assert.ThrowsExceptionAsync<HttpRequestException>(async () => await InterviewTestAPI.PostInterviewTestAsync("luke.pavelka@outlook.com", "Lukáš Pavelka - C#", ""));
        }

    }
}