namespace BlazorFrontend.lib
{
    public class ValidationResult
    {
        public string Category { get; set; } = string.Empty;
        public string Interpretation { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty; // 'normal' | 'info' | 'warning' | 'alert' | 'critical' | 'error'
        public bool BlockEntry { get; set; }
    }

    public static class VitalsValidation
    {
        public static ValidationResult? ValidateBloodPressure(int? systolic, int? diastolic)
        {
            if (!systolic.HasValue || !diastolic.HasValue || systolic == 0 || diastolic == 0) return null;

            if (systolic > 180 || diastolic > 120)
            {
                return new ValidationResult { Category = "Hypertensive Crisis", Interpretation = "Immediate medical attention (call 911 if symptoms exist).", Level = "critical" };
            }
            if (systolic >= 140 || diastolic >= 90)
            {
                return new ValidationResult { Category = "Stage 2 Hypertension", Interpretation = "Lifestyle changes + medication typically required.", Level = "error" };
            }
            if (systolic >= 130 || (diastolic >= 80 && diastolic <= 89))
            {
                return new ValidationResult { Category = "Stage 1 Hypertension", Interpretation = "Lifestyle changes; medication may be prescribed based on risk.", Level = "warning" };
            }
            if (systolic < 90 || diastolic < 60)
            {
                return new ValidationResult { Category = "Low Blood Pressure", Interpretation = "Monitor for symptoms (dizziness, fainting).", Level = "alert" };
            }
            if (systolic >= 120 && systolic <= 129 && diastolic < 80)
            {
                return new ValidationResult { Category = "Elevated", Interpretation = "Lifestyle changes recommended.", Level = "info" };
            }
            if (systolic < 120 && diastolic < 80)
            {
                return new ValidationResult { Category = "Normal", Interpretation = "Maintain healthy lifestyle.", Level = "normal" };
            }

            return null;
        }

        public static ValidationResult? ValidateTemperature(double? temp)
        {
            if (!temp.HasValue || temp == 0) return null;

            if (temp > 40.0)
            {
                return new ValidationResult { Category = "Hyperpyrexia (Critical)", Interpretation = "Life-threatening; risk of organ damage; requires emergency care.", Level = "critical" };
            }
            if (temp >= 39.0 && temp <= 39.4)
            {
                return new ValidationResult { Category = "High Fever", Interpretation = "Indicates significant infection or inflammation; medical attention advised.", Level = "error" };
            }
            if (temp >= 38.0)
            {
                return new ValidationResult { Category = "Fever Threshold (Kenya/WHO)", Interpretation = "Clinical definition of Acute Febrile Illness; warrants investigation for infection (e.g., malaria, viral).", Level = "alert" };
            }
            if (temp >= 37.3 && temp <= 37.9)
            {
                return new ValidationResult { Category = "High Normal / Low-Grade", Interpretation = "May occur post-ovulation, after exercise, or in hot environments; monitor for symptoms.", Level = "info" };
            }
            if (temp >= 36.5 && temp <= 37.2)
            {
                return new ValidationResult { Category = "Standard Normal", Interpretation = "Optimal healthy range for adult women at rest.", Level = "normal" };
            }
            if (temp >= 36.1 && temp <= 36.4)
            {
                return new ValidationResult { Category = "Low Normal", Interpretation = "Common in early morning; generally healthy if asymptomatic.", Level = "normal" };
            }
            if (temp < 35.0)
            {
                return new ValidationResult { Category = "Hypothermia (Critical)", Interpretation = "Medical emergency; requires immediate warming and evaluation.", Level = "critical" };
            }

            return null;
        }

        public static ValidationResult? ValidateRespiratoryRate(int? rr)
        {
            if (!rr.HasValue || rr == 0) return null;

            if (rr > 35)
            {
                return new ValidationResult { Category = "Critical Tachypnea", Interpretation = "Imminent respiratory failure or extreme systemic shock; requires immediate resuscitation.", Level = "critical" };
            }
            if (rr >= 25 && rr <= 35)
            {
                return new ValidationResult { Category = "Severe Tachypnea", Interpretation = "Significant respiratory distress, severe infection (e.g., pneumonia, sepsis), or metabolic acidosis.", Level = "error" };
            }
            if (rr >= 21 && rr <= 24)
            {
                return new ValidationResult { Category = "High Normal / Borderline", Interpretation = "Mild tachypnea. Often seen with mild exertion, anxiety, or early-stage infection; monitor.", Level = "info" };
            }
            if (rr >= 12 && rr <= 20)
            {
                return new ValidationResult { Category = "Normal Resting Range", Interpretation = "Standard healthy range for adult women at rest. Indicates efficient gas exchange.", Level = "normal" };
            }
            if (rr >= 8 && rr <= 11)
            {
                return new ValidationResult { Category = "Bradypnea", Interpretation = "Abnormally slow. May indicate drug effect, severe metabolic imbalance; evaluate if symptomatic.", Level = "warning" };
            }
            if (rr < 8)
            {
                return new ValidationResult { Category = "Critical Bradypnea", Interpretation = "Life-threatening respiratory failure; immediate emergency intervention needed.", Level = "critical" };
            }

            return null;
        }

        public static ValidationResult? ValidatePulseRate(int? pr)
        {
            if (!pr.HasValue || pr == 0) return null;

            if (pr > 120)
            {
                return new ValidationResult { Category = "Critical Tachycardia", Interpretation = "Severe tachycardia; requires immediate medical evaluation for potential shock, severe hemorrhage, or cardiac crisis.", Level = "critical" };
            }
            if (pr >= 112 && pr <= 120)
            {
                return new ValidationResult { Category = "Tachycardia", Interpretation = "Elevated heart rate at rest; may indicate stress, dehydration, anemia, acute infection, or malaria.", Level = "error" };
            }
            if (pr >= 101 && pr <= 111)
            {
                return new ValidationResult { Category = "Borderline Elevated", Interpretation = "Stretched normal range. Statistically observed within the Kenyan reference interval, but warrants monitoring for early infection or anemia.", Level = "info" };
            }
            if (pr >= 58 && pr <= 100)
            {
                return new ValidationResult { Category = "Normal Resting Range", Interpretation = "Standard healthy range for adult women at rest. Integrates the lower limit of the 95% Kenyan reference interval (58 bpm).", Level = "normal" };
            }
            if (pr >= 40 && pr <= 57)
            {
                return new ValidationResult { Category = "Bradycardia", Interpretation = "Abnormally low heart rate; concerning if accompanied by dizziness or fatigue (though normal for highly conditioned athletes).", Level = "warning" };
            }
            if (pr < 40)
            {
                return new ValidationResult { Category = "Critical Bradycardia", Interpretation = "Life-threateningly low heart rate; requires immediate medical evaluation and emergency intervention.", Level = "critical" };
            }

            return null;
        }

        public static ValidationResult? ValidateHeight(double? height)
        {
            if (!height.HasValue || height == 0) return null;

            if (height > 195)
            {
                return new ValidationResult { Category = "Hard Maximum (Block)", Interpretation = "BLOCK ENTRY. Exceeds logical boundaries for the local demographic; flag to prevent accidental typos.", Level = "error", BlockEntry = true };
            }
            if (height >= 181 && height <= 195)
            {
                return new ValidationResult { Category = "Tall Stature", Interpretation = "INFO. Structurally tall, but completely normal and safe. No clinical risk attached.", Level = "info" };
            }
            if (height >= 150 && height <= 180)
            {
                return new ValidationResult { Category = "Normal Stature Range", Interpretation = "NONE. Standard healthy reference interval for adult women in Kenya.", Level = "normal" };
            }
            if (height >= 145 && height <= 149)
            {
                return new ValidationResult { Category = "Short Stature (Risk Zone)", Interpretation = "ALERT / FLAG. Below the standard 150 cm obstetric safety cutoff in Kenya. Statistically higher risk for Cephalopelvic Disproportion (CPD); requires close monitoring during delivery.", Level = "alert" };
            }
            if (height >= 100 && height <= 144)
            {
                return new ValidationResult { Category = "Severe Stature Warning", Interpretation = "WARNING. Indicates dwarfism or severe skeletal dysplasia. In maternal care, this represents an extreme risk for obstructed labor; mandatory referral for elective C-section.", Level = "warning" };
            }
            if (height < 100)
            {
                return new ValidationResult { Category = "Hard Minimum (Block)", Interpretation = "BLOCK ENTRY. Extremely unlikely for an adult woman; flag as an obvious data entry typo.", Level = "error", BlockEntry = true };
            }

            return null;
        }

        public static ValidationResult? ValidateBMI(double? bmi)
        {
            if (!bmi.HasValue || bmi == 0) return null;

            if (bmi < 15)
            {
                return new ValidationResult { Category = "Critical Low BMI", Interpretation = "BMI is below the safe range (15-45). Risk of severe malnutrition or underlying illness.", Level = "critical" };
            }
            if (bmi > 45)
            {
                return new ValidationResult { Category = "Critical High BMI", Interpretation = "BMI exceeds the safe range (15-45). Indicates extreme obesity; high risk for pregnancy complications.", Level = "critical" };
            }
            if (bmi >= 15 && bmi < 18.5)
            {
                return new ValidationResult { Category = "Underweight", Interpretation = "Below normal BMI. Monitor nutritional intake.", Level = "warning" };
            }
            if (bmi >= 18.5 && bmi <= 24.9)
            {
                return new ValidationResult { Category = "Normal BMI", Interpretation = "Healthy weight range.", Level = "normal" };
            }
            if (bmi >= 25 && bmi <= 29.9)
            {
                return new ValidationResult { Category = "Overweight", Interpretation = "Increased risk for gestational diabetes and hypertension.", Level = "info" };
            }
            if (bmi >= 30 && bmi <= 45)
            {
                return new ValidationResult { Category = "Obesity", Interpretation = "Significant risk for pregnancy complications. Requires close monitoring.", Level = "alert" };
            }

            return null;
        }
    }
}
