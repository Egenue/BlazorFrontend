using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class auditlogs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string recordId { get; set;}
        public required string userInitials { get; set;}
        public required string action { get; set;}
        public required string module { get; set;}
        public Dictionary<string, object>? oldValue { get; set; } 
        public Dictionary<string, object>? newValue { get; set; }
        public string reason { get; set;} = string.Empty;
        public DateTime timestamp { get; set; } = DateTime.Now;
    }
}
