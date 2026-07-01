using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006 // Naming Styles
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class closeoutforms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonPropertyName("sreeningId")]
        public string? sreeningId { get; set; }

        [JsonPropertyName("closeOutInterviewDate")]
        public DateTime closeOutInterviewDate { get; set; }

        [JsonPropertyName("dateOfTermination")]
        public DateTime dateOfTermination { get; set; }

        [JsonPropertyName("participantStatus")]
        public ParticipationStatus? participantStatus { get; set; }

        [JsonPropertyName("submittedAt")]
        public DateTime submittedAt { get; set; }

        [JsonPropertyName("submittedBy")]
        public string? submittedBy { get; set; }
    }

    public class ParticipationStatus
    {
        [JsonPropertyName("choicesStudy")]
        public string? choicesStudy { get; set; } = string.Empty;

        [JsonPropertyName("incompleteReason")]
        public IncompleteReason? incompleteReason { get; set; }
    }

    public class IncompleteReason
    {
        [JsonPropertyName("incompletionOptions")]
        public string? incompletionOptions { get; set; } = string.Empty;

        [JsonPropertyName("adverseEvent")]
        public string? adverseEvent { get; set; }

        [JsonPropertyName("deathOption")]
        public DateTime deathOption { get; set; }

        [JsonPropertyName("protocolDeviation")]
        public string? protocolDeviation { get; set; }

        [JsonPropertyName("withdrawalReason")]
        public string? withdrawalReason { get; set; }

        [JsonPropertyName("otherReason")]
        public string? otherReason { get; set; }
    }
}