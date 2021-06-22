using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionlab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionlab.Tests
{
    [TestClass()]
    public class InterviewTestTests
    {
        [TestMethod()]
        public async Task SendApplicationAsyncTestAsync1()
        {
            var LukyInterview = new InterviewTest("8743f41d-98c6-4578-9d7b-611af96a16ba", "luke.pavelka@outlook.com", "Lukáš Pavelka C# test");
            var Answer = await LukyInterview.SendApplicationAsync();
            Assert.IsTrue(LukyInterview.IsSuccessful && Answer.confirmationText != null);
        }
        [TestMethod()]
        public async Task SendApplicationAsyncTestAsync2()
        {
            var LukyInterview = new InterviewTest("TestFail", "luke.pavelka@outlook.com", "Lukáš Pavelka C# test");
            var Answer = await LukyInterview.SendApplicationAsync();
            Assert.IsFalse(LukyInterview.IsSuccessful && Answer.confirmationText != null);
        }
    }
}