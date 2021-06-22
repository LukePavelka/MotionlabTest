using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// The file contains classes that are used for json deserialization.
/// Json from webapi has attributes named as follows.
/// the names do not match the c# convention, so they have been suppressed
/// </summary>
namespace Motionlab.API
{
#pragma warning disable IDE1006
    public class Authorization
    {
        // Primary key
        [Key]
        // Auto gen new GUID key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string access_token { get; set; }
        public string tokenType { get; set; }
    }
    public class GetInterviewInfoRespond
    {
        // Primary key
        [Key]
        // Auto gen new GUID key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Authorization authorization { get; set; }
        public string nextStepText { get; set; }
    }
    public class PostInterviewTestInfo
    {
        // Primary key
        [Key]
        // Auto gen new GUID key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }
    public class PostInterviewTestRespond
    {
        // Primary key
        [Key]
        // Auto gen new GUID key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string confirmationText { get; set; }
    }
#pragma warning restore IDE1006
}
