using System;
using System.Text.RegularExpressions;
using _Scripts.Managers.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Unity.Services.Authentication;
public class LoginMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private Button _loginButton;
    [SerializeField] private Button _loginAsGuestButton;

    private ErrorPanel _errorPanel;
    private void Awake()
    {
        _loginButton.onClick.AddListener(Login);
        _loginAsGuestButton.onClick.AddListener(LoginAsGuest);
        
        _errorPanel = FindObjectOfType<ErrorPanel>();
    }

    private async void Login()
    {
        string username = _usernameInputField.text;
        
        string password = _passwordInputField.text;
        
        if (username.Length == 0 || password.Length == 0)
        {
            _errorPanel.Show("Username and password cannot be empty");
            return;
        }
        
        if (username.Length < 3 || username.Length > 20)
        {
            _errorPanel.Show("Invalid username length. Username must be between 3 and 20 characters");
            return;
        }
        
        if (password.Length < 8 || password.Length > 30)
        {
            _errorPanel.Show("Invalid password length. Password must be between 8 and 30 characters");
            return;
        }
        
        if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$"))
        {
            _errorPanel.Show("Invalid password format. Ensure it has at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character");
            return;
        }

        
        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9.,_@-]+$"))
        {
            _errorPanel.Show("Invalid characters in the username. Use only letters, digits, and symbols among {., -, _, @}");
            return;
        }

        
        
        try
        {
            await UnityAuthenticationServiceManager.SignInWithUsernamePasswordAsync(_usernameInputField.text,
                _passwordInputField.text);
            
            FindObjectOfType<MenuUI>().LoadLobby();
            
        }
        catch (AuthenticationException e)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            
            _errorPanel.Show(e.Message);
            
            Debug.LogError(e.Message);
        }
        catch (Exception e)
        {
            _errorPanel.Show(e.Message);
            
            Debug.LogError(e.Message);
    
        }
        
    }
    
    private async void LoginAsGuest()
    {
        try
        {
            await UnityAuthenticationServiceManager.SignInAnonymously();
            
            FindObjectOfType<MenuUI>().LoadLobby();
        }
        catch (Exception e)
        {
            _errorPanel.Show(e.Message);
            
            Debug.LogError(e.Message);
    
            throw;
        }
        
    }
    
    
}
