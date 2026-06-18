using System;

namespace BlazorFrontend.lib
{
    public static class DateUtils
    {
        public static AgeResult CalculateAge(string dobString, string interviewDateString)
        {
            if (string.IsNullOrEmpty(dobString) || !DateTime.TryParse(dobString, out var dob))
            {
                return new AgeResult { Years = 0, Months = 0 };
            }

            var interview = string.IsNullOrEmpty(interviewDateString)
                ? DateTime.Now
                : (DateTime.TryParse(interviewDateString, out var parsed) ? parsed : DateTime.Now);

            int years = interview.Year - dob.Year;
            int months = interview.Month - dob.Month;

            if (months < 0 || (months == 0 && interview.Day < dob.Day))
            {
                years--;
                months += 12;
            }

            if (interview.Day < dob.Day)
            {
                months--;
                if (months < 0)
                {
                    months = 11;
                }
            }

            return new AgeResult
            {
                Years = Math.Max(0, years),
                Months = Math.Max(0, months)
            };
        }

        public static string FormatDateUtil(DateTime newateUtil)
        {
            return newateUtil.ToShortDateString();
        }

        public static bool IsValidDob(string dobString)
        {
            if (string.IsNullOrEmpty(dobString) || !DateTime.TryParse(dobString, out var dob))
            {
                return false;
            }

            var minDate = new DateTime(1972, 1, 1);
            var maxDate = new DateTime(2006, 1, 1);

            return dob >= minDate && dob <= maxDate;
        }

        public static string FormatToDdmMmyyyy(string? dateInput)
        {
            if (string.IsNullOrEmpty(dateInput)) return string.Empty;
            if (DateTime.TryParse(dateInput, out var date))
            {
                var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                return $"{date.Day:D2}/{months[date.Month - 1]}/{date.Year}";
            }
            return dateInput;
        }

        public static string FormatToDdmMmyyyy(DateTime? dateInput)
        {
            if (!dateInput.HasValue) return string.Empty;
            var date = dateInput.Value;
            var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            return $"{date.Day:D2}/{months[date.Month - 1]}/{date.Year}";
        }

        public static GAIAResult CalculateGAIA(GAIAParameters parameters)
        {
            var today = DateTime.Today;
            var result = new GAIAResult
            {
                Trimester = "N/A",
                PregnancyStartByUS = DateTime.Now,
                FinalPregnancyStartDate = DateTime.Now,
                Source = "N/A",
                Loc = "N/A",
                AbsDiff = null,
                GaAtEnrolmentDays = 0,
                Edd = DateTime.Now
            };

            DateTime usDate = parameters.UltrasoundDate.Date;

            DateTime enrDate = parameters.EnrolmentDate.Date;
            if (enrDate == DateTime.MinValue)
            {
                enrDate = today;
            }

            if (usDate > today)
            {
                result.Error = "Ultrasound date cannot be in the future.";
                return result;
            }

            if (parameters.UsWeeks < 0 || parameters.UsWeeks > 42)
            {
                result.Error = "Ultrasound weeks must be between 0 and 42.";
                return result;
            }

            if (parameters.UsDays < 0 || parameters.UsDays > 6)
            {
                result.Error = "Ultrasound days must be between 0 and 6.";
                return result;
            }

            DateTime? lmp = parameters.LmpDate?.Date;
            if (lmp.HasValue && lmp != DateTime.MinValue)
            {
                if (lmp > today)
                {
                    result.Error = "LMP date cannot be in the future.";
                    return result;
                }
                if (lmp > usDate)
                {
                    result.Error = "LMP date cannot be after ultrasound date.";
                    return result;
                }
            }
            else
            {
                lmp = null;
            }

            int usGADays = parameters.UsWeeks * 7 + parameters.UsDays;
            string trimester = usGADays <= 97 ? "First" : (usGADays <= 195 ? "Second" : "Third or beyond");

            var pregnancyStartByUS = usDate.AddDays(-usGADays);
            var finalPregnancyStartDate = pregnancyStartByUS;
            string source = "Ultrasound";
            string loc = "";
            int? absDiff = null;

            if (lmp.HasValue)
            {
                int diffUsLmp = (int)Math.Round((pregnancyStartByUS - lmp.Value).TotalDays);
                absDiff = Math.Abs(diffUsLmp);

                if (trimester == "First")
                {
                    loc = "LOC-1";
                    if (absDiff <= 7 && parameters.LmpCertainty == "certain")
                    {
                        finalPregnancyStartDate = lmp.Value;
                        source = "LMP";
                    }
                }
                else if (trimester == "Second")
                {
                    if (parameters.LmpCertainty == "certain")
                    {
                        loc = "LOC-2a";
                        if (absDiff <= 14)
                        {
                            finalPregnancyStartDate = lmp.Value;
                            source = "LMP";
                        }
                    }
                    else
                    {
                        loc = "LOC-2b";
                        if (absDiff <= 10)
                        {
                            finalPregnancyStartDate = lmp.Value;
                            source = "LMP";
                        }
                    }
                }
                else
                {
                    loc = "NOT LOC 1-2b";
                }
            }
            else
            {
                loc = trimester == "First" ? "LOC-1" : (trimester == "Second" ? "LOC-2b" : "NOT LOC 1-2b");
            }

            int gaAtEnrolmentDays = (int)Math.Round((enrDate - finalPregnancyStartDate).TotalDays);

            if (gaAtEnrolmentDays < 0)
            {
                result.Error = "Calculated pregnancy start is after enrolment date.";
                return result;
            }

            var edd = finalPregnancyStartDate.AddDays(280);

            result.Trimester = trimester;
            result.PregnancyStartByUS = pregnancyStartByUS;
            result.FinalPregnancyStartDate = finalPregnancyStartDate;
            result.Source = source;
            result.Loc = loc;
            result.AbsDiff = absDiff;
            result.GaAtEnrolmentDays = gaAtEnrolmentDays;
            result.Edd = edd;

            return result;
        }
    }

    public class AgeResult
    {
        public int Years { get; set; }
        public int Months { get; set; }
    }

    public class GAIAParameters
    {
        public DateTime UltrasoundDate { get; set; }
        public int UsWeeks { get; set; }
        public int UsDays { get; set; }
        public DateTime? LmpDate { get; set; }
        public string? LmpCertainty { get; set; }
        public DateTime EnrolmentDate { get; set; }
    }

    public class GAIAResult
    {
        public string Trimester { get; set; } = string.Empty;
        public DateTime PregnancyStartByUS { get; set; }
        public DateTime FinalPregnancyStartDate { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Loc { get; set; } = string.Empty;
        public int? AbsDiff { get; set; }
        public int GaAtEnrolmentDays { get; set; }
        public DateTime Edd { get; set; }
        public string? Error { get; set; }
    }
}
