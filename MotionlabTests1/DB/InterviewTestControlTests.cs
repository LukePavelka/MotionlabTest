using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motionlab.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionlab.DB.Tests
{
    [TestClass()]
    public class InterviewTestControlTests
    {
        private Guid TestEntryId { get; set; }

        [TestMethod()]
        public void SaveAsyncTest()
        {
            InterviewTestDb TestEntry = new InterviewTestDb
            {
                Email = "test",
                Name = "test",
                Key = "test",
                IsSuccessful = true,
                Error = "dsdsd",
                ID = Guid.NewGuid()
            };
            this.TestEntryId = TestEntry.ID;
            Assert.ThrowsExceptionAsync<Exception>(async () => await DB.InterviewTestControl.SaveAsync(TestEntry));
        }

        [TestMethod()]
        public async Task DeleteAsyncTest()
        {
            SaveAsyncTest();
            await DB.InterviewTestControl.DeleteAsync(this.TestEntryId);
            var Obj = await DB.InterviewTestControl.FindAsync(this.TestEntryId);
            Assert.IsNull(Obj);
        }

        [TestMethod()]
        public async Task FindAsyncTest()
        {
            SaveAsyncTest();
            var Obj = await DB.InterviewTestControl.FindAsync(this.TestEntryId);
            await DB.InterviewTestControl.DeleteAsync(this.TestEntryId);
            Assert.IsNotNull(Obj);
        }

        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            await DB.InterviewTestControl.DeleteAllAsync();
            var TestList = new List<InterviewTestDb>();
            for (int i = 0; i < 100; i++)
            {
                InterviewTestDb TestEntry = new InterviewTestDb
                {
                    Email = "test",
                    Name = "test",
                    Key = "test",
                    IsSuccessful = true,
                    Error = "test",
                    ID = Guid.NewGuid()
                };
                TestList.Add(TestEntry);
            }
            foreach (var item in TestList)
            {
                await DB.InterviewTestControl.SaveAsync(item);
            }
            var List = await DB.InterviewTestControl.GetAllAsync();

            HashSet<Guid> HashGuildList = new HashSet<Guid>(TestList.Select(s => s.ID));
            var Results = List.Where(m => HashGuildList.Contains(m.ID)).ToList();
            Assert.AreEqual(100, Results.Count);
        }

        [TestMethod()]
        public async Task DeleteAllAsyncTest()
        {
            var TestList = new List<InterviewTestDb>();
            for (int i = 0; i < 222; i++)
            {
                InterviewTestDb TestEntry = new InterviewTestDb
                {
                    Email = "test",
                    Name = "test",
                    Key = "test",
                    IsSuccessful = true,
                    Error = "test",
                    ID = Guid.NewGuid()
                };
                TestList.Add(TestEntry);
            }
            await DB.InterviewTestControl.DeleteAllAsync();
            var List = await DB.InterviewTestControl.GetAllAsync();
            Assert.AreEqual(0,List.Count());
        }
    }
}