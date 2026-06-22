using BlazorFrontend.Models;

namespace BlazorFrontend.Services
{
    public class AppState
    {
        public CurrentUser CurrentUser { get; private set; }
        
        public event Action OnChange;
        
        public void Login(CurrentUser user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }
        
        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
