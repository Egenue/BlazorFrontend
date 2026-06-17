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
        public string? Id { get; set; }

        [JsonPropertyName("screeningId")]
        public string? screeningId { get; set; }

        [JsonPropertyName("interviewDate")]
        public DateTime? interviewDate { get; set; } = DateTime.Today;

        [JsonPropertyName("DoB")]
        public DateTime? DoB { get; set; }

        [JsonPropertyName("healthFacility")]
        public string? healthFacility { get; set; } 

        [JsonPropertyName("Age")]
        public AgeInfo? Age { get; set; }

        [JsonPropertyName("height")]
        public double? height { get; set; }

        [JsonPropertyName("weight")]
        public double? weight { get; set; }

        [JsonPropertyName("BMI")]
        public double? BMI { get; set; }

        [JsonPropertyName("vitalSigns")]
        public VitalSignsInfo? vitalSigns { get; set; }

        [JsonPropertyName("lastMensrualPeriod")]
        public LmpInfo? lastMensrualPeriod { get; set; }

        [JsonPropertyName("fundalHeight")]
        public int? fundalHeight { get; set; }

        [JsonPropertyName("inclusionCriteria")]
        public InclusionCriteria? inclusionCriteria { get; set; }

        [JsonPropertyName("exclusionCriteria")]
        public ExclusionCrit? exclusionCriteria{ get; set; }

        [JsonPropertyName("eligibility")]
        public Eligibility? eligibility { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? createdAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updatedAt")]
        public DateTime? updatedAt { get; set; } = DateTime.Now;
    }

    public class Eligibility
    {
        [JsonPropertyName("meetsAllCriteria")]
        public string? meetsAllCriteria { get; set; }

        [JsonPropertyName("consentedToParticipate")]
        public string? consentedToParticipate { get; set; }

        [JsonPropertyName("reasonForRefusal")]
        public string? reasonForRefusal { get; set; }
    }

    public class ExclusionCrit
    {
        [JsonPropertyName("multiplePregancy")]
        public string? multiplePregancy { get; set; }

        [JsonPropertyName("fisturaRepairOrSpinalDeformity")]
        public string? fisturaRepairOrSpinalDeformity { get; set; }

        [JsonPropertyName("unableToGiveInformedConsent")]
        public string? unableToGiveInformedConsent { get; set; }
    }

    public class InclusionCriteria
    {
        [JsonPropertyName("residentWithin15km")]
        public string? residentWithin15km { get; set; }

        [JsonPropertyName("pregnancyConfirmed")]
        public string? pregnancyConfirmed { get; set; }

        [JsonPropertyName("gestationLessThan31Weeks")]
        public string? gestationLessThan31Weeks { get; set; }

        [JsonPropertyName("consentsToHIVTesting")]
        public string? consentsToHIVTesting { get; set; }

        [JsonPropertyName("willingToDeliverAtStudyHospital")]
        public string? willingToDeliverAtStudyHospital { get; set; }
    }

    public class LmpInfo
    {
        [JsonPropertyName("date")]
        public DateTime? date { get; set; }

        [JsonPropertyName("unknown")]
        public string? unknown { get; set; } = string.Empty;
    }

    public class VitalSignsInfo
    {
        [JsonPropertyName("temperature")]
        public TempInfo? temperature { get; set; }

        [JsonPropertyName("respiratoryRate")]
        public int? respiratoryRate { get; set; }

        [JsonPropertyName("pulseRate")]
        public int? pulseRate { get; set; }

        [JsonPropertyName("bloodPressure")]
        public BloodPressureInfo? bloodPressure { get; set; }
    }

    public class BloodPressureInfo
    {
        [JsonPropertyName("systolic")]
        public int? systolic { get; set; }

        [JsonPropertyName("diastolic")]
        public int? diastolic { get; set; }
    }

    public class TempInfo
    {
        [JsonPropertyName("value")]
        public double? value { get; set; }

        [JsonPropertyName("location")]
        public string? location { get; set; }
    }

    public class AgeInfo
    {
        [JsonPropertyName("years")]
        public int? years {get; set;}

        [JsonPropertyName("months")]
        public int? months { get; set; }
    }
}
