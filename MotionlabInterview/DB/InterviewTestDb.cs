using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionlab.DB
{
    /// <summary>
    /// Model that is used for the database within the ef core.
    /// </summary>
    public class InterviewTestDb
    {
        // Primary key
        [Key]
        // Auto gen new GUID key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Key { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public API.GetInterviewInfoRespond FirstRequest { get; set; }
        public API.PostInterviewTestRespond SecondaryRequest { get; set; }

    }
}
