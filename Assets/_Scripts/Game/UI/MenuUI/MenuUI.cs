using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuUI : MonoBehaviour
{
    [FormerlySerializedAs("optionMenu")] public GameObject OptionMenu;
    [FormerlySerializedAs("mainMenu")] public GameObject MainMenu;
    public GameObject LoginMenu;
    public GameObject RegisterMenu;

    public void LoadLobby()
    {
        MainMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(Play);
    }

    public void Awake()
    {
        MainMenu.transform.localScale = new Vector3(0,0,0);
        MainMenu.LeanScale(Vector2.one, 1f).setEaseInOutBounce();
    }

    public void OnOptionOpen()
    {
        MainMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(OptionEnable);
        OptionMenu.LeanScale(Vector2.one, 0.5f);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }

    public void OnOptionClose()
    {
        OptionMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(OptionDisable);
        MainMenu.LeanScale(Vector2.one, 0.5f);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }
    
    public void OnLoginOpen()
    {
        MainMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(LoginEnable);
        LoginMenu.LeanScale(Vector2.one, 0.5f);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }
    
    public void OnLoginClose()
    {
        LoginMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(LoginDisable);
        MainMenu.LeanScale(Vector2.one, 0.5f);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }
    
    public void OnRegisterOpen()
    {
        MainMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(RegisterEnable);
        RegisterMenu.LeanScale(Vector2.one, 0.5f);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }
    
    public void OnRegisterClose()
    {
        RegisterMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(RegisterDisable);
        MainMenu.LeanScale(Vector2.one, 0.5f);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }

    public void Quit()
    {
        Application.Quit();
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
        }
    }

    public void OptionEnable()
    {
        OptionMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OptionDisable()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    
    public void LoginEnable()
    {
        LoginMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    
    public void LoginDisable()
    {
        LoginMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    
    public void RegisterEnable()
    {
        RegisterMenu.SetActive(true);
        LoginMenu.SetActive(false);
    }
    
    public void RegisterDisable()
    {
        RegisterMenu.SetActive(false);
        LoginMenu.SetActive(true);
    }

    public void MainMenuEnable()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void MainMenuDisable()
    {
        OptionMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    private void Play()
    {
        AssetSceneManager.LoadScene(AssetSceneManager.AssetScene.LobbyScene.ToString());
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
        }
    }

    public void OnAwakeCompleted()
    {
        Debug.Log("Shows Game's Tittle");
    }
}
