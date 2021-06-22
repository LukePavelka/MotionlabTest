using System;
using System.Threading.Tasks;

namespace Motionlab
{
    class Program
    {
        static async Task Main()
        {
            //8743f41d-98c6-4578-9d7b-611af96a16ba
            var LukyInterview = new InterviewTest("8743f41d-98c6-4578-9d7b-611af96a16ba","luke.pavelka@outlook.com","Lukáš Pavelka C# test");
            await LukyInterview.SendApplicationAsync();

            Console.WriteLine(LukyInterview.IsSuccessful);

        }
    }
}
