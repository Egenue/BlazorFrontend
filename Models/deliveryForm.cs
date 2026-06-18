using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlazorFrontend.Models
{
    #pragma warning disable IDE1006 // Naming Styles
    #pragma warning disable CS8981
    [BsonIgnoreExtraElements]
    public class deliveryforms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [JsonPropertyName("interviewDate")]
        public DateTime interviewDate { get; set; } = DateTime.Now;

        [JsonPropertyName("deliveryScreeningId")]
        public required string deliveryScreeningId { get; set; }

        [JsonPropertyName("physicalExam")]
        public PhysicalExamInfo? physicalExam { get; set; }

        [JsonPropertyName("bodyMassIndex")]
        public BMI? bodyMassIndex { get; set; }

        [JsonPropertyName("motherAbnormality")]
        public MotherAbnomarlity? motherAbnormality { get; set; }

        [JsonPropertyName("deliveryHistory")]
        public required DeliveryHistory deliveryHistory { get; set; }

        [JsonPropertyName("closeOut")]
        public closeoutforms? closeOut { get; set; }
    }

    public class PhysicalExamInfo
    {
        [JsonPropertyName("motherWeight")]
        public double? motherWeight { get; set; }

        [JsonPropertyName("vitalSigns")]
        public vitalSignsInfo? vitalSigns { get; set; }
    }

    public class BMI
    {
        [JsonPropertyName("value")]
        public double? value { get; set; }

        [JsonPropertyName("unknown")]
        public bool? unknown { get; set; }
    }

    public class DeliveryHistory
    {
        [JsonPropertyName("deliveryDate")]
        public DateTime deliveryDate { get; set; }

        [JsonPropertyName("deliveryTime")]
        public string? deliveryTime { get; set; } = string.Empty;

        [JsonPropertyName("deliveryPlace")]
        public DeliveryPlace? deliveryPlace { get; set; }

        [JsonPropertyName("deliveryPersonnel")]
        public DeliveryPersonnel? deliveryPersonnel { get; set; }

        [JsonPropertyName("deliveryMode")]
        public DeliveryMode? deliveryMode{ get; set; }
    }

    public class DeliveryPersonnel
    {
        [JsonPropertyName("deliveryPersValue")]
        public string? deliveryPersValue { get; set; }

        [JsonPropertyName("otherPersonnel")]
        public string? otherPersonnel { get; set; }
    }

    public class DeliveryMode
    {
        [JsonPropertyName("choices")]
        public string? choices { get; set; }

        [JsonPropertyName("otherMode")]
        public string? otherMode { get; set; }

        [JsonPropertyName("csectionIndication")]
        public CsectionIndication? csectionIndication { get; set; }
    }

    public class CsectionIndication
    {
        [JsonPropertyName("csectOptions")]
        public string? csectOptions { get; set; } = string.Empty;

        [JsonPropertyName("otherOption")]
        public string? otherOption { get; set; } = string.Empty;
    }

    public class DeliveryPlace
    {
        [JsonPropertyName("deliveryChoices")]
        public string? deliveryChoices { get; set; }

        [JsonPropertyName("otherLocation")]
        public string? otherLocation { get; set; } = string.Empty;

        [JsonPropertyName("otherFacility")]
        public string? otherFacility { get; set; } = string.Empty;
    }

    public class MotherAbnomarlity
    {
        [JsonPropertyName("motherAbnomValue")]
        public string? motherAbnomValue { get; set; }

        [JsonPropertyName("specifics")]
        public string? specifics { get; set; } = string.Empty;
    }

    public class vitalSignsInfo
    {
        [JsonPropertyName("temperature")]
        public TempInfo2? temperature { get; set; }

        [JsonPropertyName("respiratoryRate")]
        public int? respiratoryRate { get; set; }

        [JsonPropertyName("pulseRate")]
        public int? pulseRate { get; set; }

        [JsonPropertyName("bloodPressure")]
        public BloodPressureInfo? bloodPressure { get; set; }

        [JsonPropertyName("oxygenSaturation")]
        public OxygenSaturation? oxygenSaturation { get; set; }
    }

    public class TempInfo2
    {
        [JsonPropertyName("tempValue")]
        public double? tempValue { get; set; }

        [JsonPropertyName("location")]
        public string? location { get; set; }
    }

    public class OxygenSaturation
    {
        [JsonPropertyName("oxygenValue")]
        public double? oxygenValue { get; set; }

        [JsonPropertyName("oxygenOptions")]
        public string?  oxygenOptions { get; set; }
    }
}