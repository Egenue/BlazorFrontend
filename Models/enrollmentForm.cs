using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006 // Naming Styles
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class enrollmentforms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [JsonPropertyName("screeningId")]
        public required string screeningId { get; set; }

        [JsonPropertyName("healthFacility")]
        public required string healthFacility { get; set; }

        [JsonPropertyName("DoB")]
        public DateTime? DoB { get; set; }

        [JsonPropertyName("Age")]
        public AgeInfo? Age { get; set; }

        [JsonPropertyName("maritalStatus")]
        public string? maritalStatus { get; set; }

        [JsonPropertyName("HusbandName")]
        public string? HusbandName { get; set; }

        [JsonPropertyName("villageOfResidence")]
        public string? villageOfResidence { get; set; }

        [JsonPropertyName("educationLevel")]
        public string? educationLevel { get; set; }

        [JsonPropertyName("subjectOccupation")]
        public string? subjectOccupation { get; set; }

        [JsonPropertyName("otherOccupation")]
        public string? otherOccupation { get; set; }

        [JsonPropertyName("height")]
        public double? height { get; set; }

        [JsonPropertyName("weight")]
        public double? weight { get; set; }

        [JsonPropertyName("BMI")]
        public double? BMI { get; set; }

        [JsonPropertyName("vitalSigns")]
        public VitalSignsInfo? vitalSigns { get; set; }

        [JsonPropertyName("submittedAt")]
        public DateTime? submittedAt { get; set; }

        [JsonPropertyName("estGestAge")]
        public int? estGestAge { get; set; }

        [JsonPropertyName("gaParameters")]
        public GaParams? gaParameters { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }

    public class GaParams
    {
        [JsonPropertyName("ultrasoundDate")]
        public DateTime? ultrasoundDate { get; set; }

        [JsonPropertyName("usWeeks")]
        public int? usWeeks { get; set; }

        [JsonPropertyName("usDays")]
        public int? usDays { get; set; }

        [JsonPropertyName("lmpDate")]
        public DateTime? lmpDate { get; set; }

        [JsonPropertyName("lmpCertainty")]
        public string? lmpCertainty { get; set; }

        [JsonPropertyName("calculatedTrimester")]
        public string? calculatedTrimester { get; set; }

        [JsonPropertyName("finalPregnancyStartDate")]
        public DateTime? finalPregnancyStartDate  { get; set; }

        [JsonPropertyName("gaAtEnrolmentDays")]
        public int? gaAtEnrolmentDays { get; set; }

        [JsonPropertyName("edd")]
        public DateTime? edd { get; set; }

        [JsonPropertyName("source")]
        public string? source { get; set; }

        [JsonPropertyName("loc")]
        public string? loc { get; set; }
    }

    // public class GaAtEnrollmentDay
    // {
    //     public int gaAtEnrollmentDay { get; set; }
    //     public int gaAtEnrollmentWeeks { get; set; }
    // }
}
