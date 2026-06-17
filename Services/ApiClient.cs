using System.Net.Http.Json;
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
            return await _http.GetFromJsonAsync<List<screeningforms>>("api/getScreeninForms") ?? new List<screeningforms>();
        }

        public async Task CreateScreeningForm(screeningforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("api/createScreeningForm", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateScreeningForm(string id, screeningforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"api/updateScreeningForm/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteScreeningForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/deleteScreeningForm/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Enrollment
        public async Task<List<enrollmentforms>> GetAllEnrollmentForms()
        {
            return await _http.GetFromJsonAsync<List<enrollmentforms>>("api/getEnrollment") ?? new List<enrollmentforms>();
        }

        public async Task CreateEnrollmentForm(enrollmentforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("api/createEnrollment", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateEnrollmentForm(string id, enrollmentforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"api/updateEnrollment/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteEnrollmentForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/deleteEnrollment/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Delivery
        public async Task<List<deliveryforms>> GetAllDeliveryForms()
        {
            return await _http.GetFromJsonAsync<List<deliveryforms>>("api/getDelivery") ?? new List<deliveryforms>();
        }

        public async Task CreateDeliveryForm(deliveryforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("api/createDelivery", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateDeliveryForm(string id, deliveryforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"api/updateDelivery/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteDeliveryForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/deleteDelivery/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Closeout
        public async Task<List<closeoutforms>> GetAllCloseoutForms()
        {
            return await _http.GetFromJsonAsync<List<closeoutforms>>("api/getCloseout") ?? new List<closeoutforms>();
        }

        public async Task CreateCloseoutForm(closeoutforms record, string userInitials)
        {
            await _http.PostAsJsonAsync("api/createCloseout", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateCloseoutForm(string id, closeoutforms record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"api/updateCloseout/{id}", new { record, userInitials, reason });
        }

        public async Task DeleteCloseoutForm(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/deleteCloseout/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // ANC
        public async Task<List<ancvisits>> GetAllAncVisits()
        {
            return await _http.GetFromJsonAsync<List<ancvisits>>("api/getAncVisit") ?? new List<ancvisits>();
        }

        public async Task CreateAncVisit(ancvisits record, string userInitials)
        {
            await _http.PostAsJsonAsync("api/createAncVisit", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task DeleteAncVisit(string id, string userInitials, string reason)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/deleteAnc/{id}")
            {
                Content = JsonContent.Create(new { userInitials, reason })
            };
            await _http.SendAsync(request);
        }

        // Gestation Age
        public async Task<List<gestationages>> GetAllGestAge()
        {
            return await _http.GetFromJsonAsync<List<gestationages>>("api/getGestAge") ?? new List<gestationages>();
        }

        public async Task CreateGestAge(gestationages record, string userInitials)
        {
            await _http.PostAsJsonAsync("api/createGestAge", new { record, userInitials, reason = "Initial Entry" });
        }

        public async Task UpdateGestAge(string id, gestationages record, string userInitials, string reason)
        {
            await _http.PutAsJsonAsync($"api/updateGestAge/{id}", new { record, userInitials, reason });
        }

        // Audit Logs
        public async Task<List<auditlogs>> GetAllAuditLogs()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<auditlogs>>("api/getAuditLog") ?? new List<auditlogs>();
            }
            catch
            {
                return new List<auditlogs>();
            }
        }
        
        // Login
        public async Task<LoginResponse> UserLogin(string email, string userName, string fullName, string password)
        {
            var response = await _http.PostAsJsonAsync("api/userLogin", new { email, userName, fullName, password, dateLoggedIn = DateTime.Now });
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
    
    public class DatabaseState
    {
        public List<screeningforms> Screening { get; set; } = new();
        public List<enrollmentforms> Enrolment { get; set; } = new();
        public List<deliveryforms> Delivery { get; set; } = new();
        public List<closeoutforms> Closeout { get; set; } = new();
        public List<gestationages> Gestation { get; set; } = new();
        public List<ancvisits> Anc { get; set; } = new();
        public List<auditlogs> AuditLogs { get; set; } = new();
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
