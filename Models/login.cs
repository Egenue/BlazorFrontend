using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006 // Naming Styles
    [BsonIgnoreExtraElements]
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string userName{get; set;} = string.Empty;
        public string password{set; get;} = string.Empty;
        public string fullName{get; set;} = string.Empty;
        public string userRole { get; set; } = string.Empty;
        public string? userInitials { get; set; }
        public DateTime dateLoggedIn { get; set; } = DateTime.Now;
        public DateTime dateCreated { get; set; } = DateTime.Now;
    }
}
