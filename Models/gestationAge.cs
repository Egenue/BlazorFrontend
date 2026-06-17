using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006 // Naming Styles
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class gestationages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [JsonPropertyName("screeningId")]
        public string? screeningId { get; set; }

        [JsonPropertyName("lmp")]
        public DateTime? lmp { get; set; }

        [JsonPropertyName("ultrasoundDate")]
        public UltrasoundDateInfo? ultrasoundDate { get; set; }

        [JsonPropertyName("lmpCertainty")]
        public string? lmpCertainty { get; set; }

        [JsonPropertyName("enrolmentDate")]
        public DateTime? enrolmentDate { get; set; }

        [JsonPropertyName("estDueDate")]
        public DateTime? estDueDate { get; set; }

        [JsonPropertyName("currentGestAge")]
        public CurrentGestAge? currentGestAge { get; set; }
    }

    public class CurrentGestAge
    {
        [JsonPropertyName("gestweeks")]
        public int? gestweeks { get; set; }

        [JsonPropertyName("gestdays")]
        public int? gestdays { get; set; }
    }

    public class UltrasoundDateInfo
    {
        [JsonPropertyName("usWeeks")]
        public int? usWeeks { get; set; }

        [JsonPropertyName("usDays")]
        public int? usDays { get; set; }
    }
}