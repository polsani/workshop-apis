using System.Runtime.Serialization;

namespace SoapServiceServer.Models
{
    [DataContract]
    public class RequestModel
    {
        [DataMember] 
        public string Name { get; set; }
        
        [DataMember] 
        public string Email { get; set; }
    }
}