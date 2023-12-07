using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace _Scripts.Managers.Network
{
    public class AuthenticationManager : PersistentSingletonNetworkBehavior<AuthenticationManager>
    {

        public string PlayerName { get; set; }
        public string PlayerId { get; set; }

        protected override async void Awake()
        {
            base.Awake();
        }

        private async Task InitializeUnityService(string playerName = "")
        {
            if (UnityServices.State == ServicesInitializationState.Uninitialized)
            {
                // Create a profile for player
                InitializationOptions options = new InitializationOptions();
                if (playerName != "") options.SetProfile(playerName);

                await UnityServices.InitializeAsync(options);
            }

        }
    
        public async Task SignInAnonymously(string playerName = "")
        {
            await InitializeUnityService(playerName);
            
            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed in as " + AuthenticationService.Instance.PlayerId);
            };

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                PlayerId = AuthenticationService.Instance.PlayerId;
                PlayerName = playerName;
            }
        }
        
        
        public async Task SignInWithGoogleAsync(string idToken)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithGoogleAsync(idToken);
                Debug.Log("SignIn is successful.");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        
        }

        public async Task SignInWithAppleAsync(string idToken)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithAppleAsync(idToken);
                Debug.Log("SignIn is successful.");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

        public async Task SignInWithFacebookAsync(string accessToken)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithFacebookAsync(accessToken);
                Debug.Log("SignIn is successful.");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

        public async Task SignInWithSteamAsync(string ticket)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithSteamAsync(ticket);
                Debug.Log("SignIn is successful.");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

    }
}
