using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006 // Naming Styles
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class screeningforms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? _id { get; set; }

        [JsonPropertyName("screeningId")]
        public required string screeningId { get; set; }

        [JsonPropertyName("interviewDate")]
        public DateTime interviewDate { get; set; } = DateTime.Today;

        [JsonPropertyName("DoB")]
        public required DateTime DoB { get; set; }

        [JsonPropertyName("healthFacility")]
        public required string healthFacility { get; set; } 

        [JsonPropertyName("Age")]
        public required AgeInfo Age { get; set; }

        [JsonPropertyName("height")]
        public double height { get; set; }

        [JsonPropertyName("weight")]
        public double weight { get; set; }

        [JsonPropertyName("BMI")]
        public double BMI { get; set; }

        [JsonPropertyName("vitalSigns")]
        public required VitalSignsInfo vitalSigns { get; set; }

        [JsonPropertyName("lastMenstrualPeriod")]
        public LmpInfo? lastMenstrualPeriod { get; set; }

        [JsonPropertyName("fundalHeight")]
        public double fundalHeight { get; set; }

        [JsonPropertyName("inclusionCriteria")]
        public required InclusionCriteria inclusionCriteria { get; set; }

        [JsonPropertyName("exclusionCriteria")]
        public required ExclusionCrit exclusionCriteria{ get; set; }

        [JsonPropertyName("eligibility")]
        public required Eligibility eligibility { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; } = DateTime.Now;
    }

    public class Eligibility
    {
        [JsonPropertyName("meetsAllCriteria")]
        public required string meetsAllCriteria { get; set; }

        [JsonPropertyName("consentedToParticipate")]
        public required string consentedToParticipate { get; set; }

        [JsonPropertyName("reasonForRefusal")]
        public required string reasonForRefusal { get; set; }
    }

    public class ExclusionCrit
    {
        [JsonPropertyName("multiplePregancy")]
        public required string multiplePregancy { get; set; }

        [JsonPropertyName("fisturaRepairOrSpinalDeformity")]
        public required string fisturaRepairOrSpinalDeformity { get; set; }

        [JsonPropertyName("unableToGiveInformedConsent")]
        public required string unableToGiveInformedConsent { get; set; }
    }

    public class InclusionCriteria
    {
        [JsonPropertyName("residentWithin15km")]
        public required string residentWithin15km { get; set; }

        [JsonPropertyName("pregnancyConfirmed")]
        public required string pregnancyConfirmed { get; set; }

        [JsonPropertyName("gestationLessThan31Weeks")]
        public required string gestationLessThan31Weeks { get; set; }

        [JsonPropertyName("consentsToHIVTesting")]
        public required string consentsToHIVTesting { get; set; }

        [JsonPropertyName("willingToDeliverAtStudyHospital")]
        public required string willingToDeliverAtStudyHospital { get; set; }
    }

    public class LmpInfo
    {
        [JsonPropertyName("date")]
        public DateTime? date { get; set; }

        [JsonPropertyName("unknown")]
        public bool? unknown { get; set; }
    }

    public class VitalSignsInfo
    {
        [JsonPropertyName("temperature")]
        public required TempInfo temperature { get; set; }

        [JsonPropertyName("respiratoryRate")]
        public int respiratoryRate { get; set; }

        [JsonPropertyName("pulseRate")]
        public int pulseRate { get; set; }

        [JsonPropertyName("bloodPressure")]
        public required BloodPressureInfo bloodPressure { get; set; }
    }

    public class BloodPressureInfo
    {
        [JsonPropertyName("systolic")]
        public int systolic { get; set; }

        [JsonPropertyName("diastolic")]
        public int diastolic { get; set; }
    }

    public class TempInfo
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("location")]
        public required string location { get; set; }
    }

    public class AgeInfo
    {
        [JsonPropertyName("years")]
        public int years {get; set;}

        [JsonPropertyName("months")]
        public int months { get; set; }
    }
}
