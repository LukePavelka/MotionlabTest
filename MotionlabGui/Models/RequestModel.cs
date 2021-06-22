using Motionlab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionlabGui.Models
{
    public class RequestModel
    {
        public string Key { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsSuccessful { get; set; }
        public bool IsNotCompleted = true;
        public string Answer { get; set; }
        public string Error { get; set; }


        public bool IsValid() 
        {
            if (Key != null && Email != null && Name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void ProceedData(InterviewTest NewRequest)
        {
            this.IsSuccessful = NewRequest.IsSuccessful;
            if (IsSuccessful)
            {
                this.Answer = NewRequest.SecondaryRequest.confirmationText;
            }
            else
            {
                this.Error = NewRequest.Error.ToString();
            }
        }
    }
}
