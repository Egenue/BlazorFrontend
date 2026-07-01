using System.Net.Http.Json;
using System.Text.Json.Serialization;
using BlazorFrontend.Models;

namespace BlazorFrontend.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http)
        {
            _http = http;
        }

        // Screening
        public async Task<List<screeningforms>> GetAllScreeningForms()
        {
            try
            {
                var response = await _http.GetAsync("getScreeninForms");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<screeningforms>(); // Return empty list instead of crashing
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    var wrapper = await response.Content.ReadFromJsonAsync<ScreeningFormsResponse>();
                    return wrapper?.screeningDocs ?? new List<screeningforms>();
                }
            }
            catch
            {
                return new List<screeningforms>();
            }
        }

        public async Task CreateScreeningForm(screeningforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("createScreeningForm", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateScreeningForm(string id, screeningforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"updateScreeningForm/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteScreeningForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteScreeningForm/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Enrollment
        public async Task<List<enrollmentforms>> GetAllEnrollmentForms()
        {
            try
            {
                var response = await _http.GetAsync("getEnrollment");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<enrollmentforms>(); // Return empty list instead of crashing
                }else
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<List<enrollmentforms>>() ?? new List<enrollmentforms>();
                }
            }
            catch
            {
                return new List<enrollmentforms>();
            }
        }

        public async Task CreateEnrollmentForm(enrollmentforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("createEnrollment", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateEnrollmentForm(string id, enrollmentforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"updateEnrollment/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteEnrollmentForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteOne/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Delivery
        public async Task<List<deliveryforms>> GetAllDeliveryForms()
        {
           try
            {
                var response = await _http.GetAsync("getDelivery");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<deliveryforms>(); // Return empty list instead of crashing
                }else
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<List<deliveryforms>>() ?? new List<deliveryforms>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ApiClient] GetAllDeliveryForms error: {ex}");
                return new List<deliveryforms>();
            }
        }

        public async Task CreateDeliveryForm(deliveryforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("createDelivery", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateDeliveryForm(string id, deliveryforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"updateDelivery/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteDeliveryForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteDelivery/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Closeout
        public async Task<List<closeoutforms>> GetAllCloseoutForms()
        {
            try
            {
                var response = await _http.GetAsync("getCloseout");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<closeoutforms>(); // Return empty list instead of crashing
                }else
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<List<closeoutforms>>() ?? new List<closeoutforms>();
                }
            }
            catch
            {
                return new List<closeoutforms>();
            }
        }

        public async Task CreateCloseoutForm(closeoutforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("createCloseout", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateCloseoutForm(string id, closeoutforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"updateCloseout/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteCloseoutForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteCloseout/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // ANC
        public async Task<List<ancvisits>> GetAllAncVisits()
        {
            try
            {
                var response = await _http.GetAsync("getAncVisit");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<ancvisits>(); // Return empty list instead of crashing
                }else
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<List<ancvisits>>() ?? new List<ancvisits>();
                }
            }
            catch
            {
                return new List<ancvisits>();
            }
        }

        public async Task CreateAncVisit(ancvisits record, string userInitials)
        {
            await _http.PostAsJsonAsync("createAncVisit", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task DeleteAncVisit(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteAnc/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Gestation Age
        public async Task<List<gestationages>> GetAllGestAge()
        {
            try
            {
                var response = await _http.GetAsync("getGestAge");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<gestationages>(); // Return empty list instead of crashing
                }else
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<List<gestationages>>() ?? new List<gestationages>();
                }
            }
            catch
            {
                return new List<gestationages>();
            }
        }

        public async Task CreateGestAge(gestationages record, string userInitials)
        {
            await _http.PostAsJsonAsync("createGestAge", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateGestAge(string id, gestationages record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"updateGestAge/{id}", new { record, userInitials, reason });
        }

        // Audit Logs
        public async Task<List<auditlogs>> GetAllAuditLogs()
        {
            try
            {
                var response = await _http.GetAsync("getAuditLog");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<auditlogs>();
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(jsonString))
                    {
                        return new List<auditlogs>();
                    }

                    var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    if (jsonString.TrimStart().StartsWith("["))
                    {
                        var logs = System.Text.Json.JsonSerializer.Deserialize<List<auditlogs>>(jsonString, options);
                        return logs ?? new List<auditlogs>();
                    }
                    else
                    {
                        var wrapper = System.Text.Json.JsonSerializer.Deserialize<AuditLogsResponse>(jsonString, options);
                        return wrapper?.data ?? new List<auditlogs>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ApiClient] GetAllAuditLogs error: {ex}");
                return new List<auditlogs>();
            }
        }
        
        public async Task<List<Login>> GetAllLogins()
        {
            try
            {
                var response = await _http.GetAsync("allLogin");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<Login>();
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<List<Login>>() ?? new List<Login>();
                }
            }
            catch
            {
                return new List<Login>();
            }
        }
        
        // Login
        public async Task<LoginResponse> UserLogin(string email, string userName, string fullName, string password)
        {
            var response = await _http.PostAsJsonAsync("userLogin", new { email, userName, fullName, password, dateLoggedIn = DateTime.Now });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoginResponse>() ?? throw new Exception("Invalid login response");
        }
    }

    public class ApiResponse<T>
    {
        public T? data { get; set; }
        public string? message { get; set; }
        public string? error { get; set; }
    }
    
    public class LoginResponse
    {
        public UserData? user { get; set; }
    }
    
    public class UserData
    {
        public string userRole { get; set; } = string.Empty;
    }

    public class ScreeningFormsResponse
    {
        [JsonPropertyName("screeningDocs")]
        public List<screeningforms>? screeningDocs { get; set; }
    }

    public class AuditLogsResponse
    {
        [JsonPropertyName("data")]
        public List<auditlogs>? data { get; set; }
    }
    
    public class DatabaseState
    {
        public List<screeningforms> Screening { get; set; } = new();
        public List<enrollmentforms> Enrolment { get; set; } = new();
        public List<deliveryforms> Delivery { get; set; } = new();
        public List<closeoutforms> Closeout { get; set; } = new();
        public List<gestationages> Gestation { get; set; } = new();
        public List<ancvisits> Anc { get; set; } = new();
        public List<auditlogs> AuditLogs { get; set; } = new();
        public List<Login> Logins { get; set; } = new();
    }
    
    public class CurrentUser
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Initials { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
