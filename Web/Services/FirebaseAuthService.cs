using Microsoft.JSInterop;

namespace Web.Services
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "firebaseUserId";
        private const string DisplayNameKey = "firebaseDisplayName";
        public event Action? OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string?> SignInWithEmailPassword(string email, string password)
        {
            var uid = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailPassword", email, password);
            if (!string.IsNullOrEmpty(uid))
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, uid);
                OnChangeLogin?.Invoke();
            }
            return uid;
        }

        public async Task<string?> CreateUserWithEmailAndPassword(string email, string password, string displayName)
        {
            var uid = await _jsRuntime.InvokeAsync<string>("firebaseAuth.createUserWithEmailAndPassword", email, password, displayName);
            if (!string.IsNullOrEmpty(uid))
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, uid);
                OnChangeLogin?.Invoke();
            }
            return uid;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            OnChangeLogin?.Invoke();
        }

        public async Task<string?> GetUserId()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserId();
            return !string.IsNullOrEmpty(userId);
        }

        public async Task<string> GetDisplayName()
        {
            var name = await _jsRuntime.InvokeAsync<string>("firebaseAuth.getDisplayName");
            return name ?? string.Empty;
        }
    }
}
