using System.Security.AccessControl;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class ancvisits
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [JsonPropertyName("visitNumber")]
        public string? visitNumber { get; set; }

        [JsonPropertyName("visitDate")]
        public DateTime? visitDate { get; set; } = DateTime.Today;

        [JsonPropertyName("gestationAge")]
        public GestationAgeInfo? gestationAge { get; set; }

        [JsonPropertyName("weightKilos")]
        public int? weightKilos { get; set; }

        [JsonPropertyName("bloodPressure")]
        public BloodPressureInfo? bloodPressure { get; set; }

        [JsonPropertyName("fundalHeight")]
        public int? fundalHeight { get; set; }

        [JsonPropertyName("muac")]
        public int? muac { get; set; }

        [JsonPropertyName("complaints")]
        public string? complaints { get; set; } = string.Empty;

        [JsonPropertyName("medicationGiven")]
        public string? medicationGiven { get; set; } = string.Empty;

        [JsonPropertyName("nextAppointment")]
        public DateTime? nextAppointment { get; set; }
    }

    public class GestationAgeInfo
    {
        [JsonPropertyName("gestWeeks")]
        public int? gestWeeks { get; set; }

        [JsonPropertyName("gestDays")]
        public int? gestDays { get; set; }
    }
}
