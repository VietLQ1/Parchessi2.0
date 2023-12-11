using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour 
{
    [FormerlySerializedAs("mainMenuButton")] [SerializeField] private Button _mainMenuButton;
    [FormerlySerializedAs("createLobbyButton")] [SerializeField] private Button _createLobbyButton;
    [FormerlySerializedAs("quickJoinButton")] [SerializeField] private Button _quickJoinButton;
    [FormerlySerializedAs("joinCodeButton")] [SerializeField] private Button _joinCodeButton;
    [FormerlySerializedAs("joinCodeInputField")] [SerializeField] private TMP_InputField _joinCodeInputField;
    [FormerlySerializedAs("playerNameInputField")] [SerializeField] private TMP_InputField _playerNameInputField;
    [FormerlySerializedAs("lobbyCreateUI")] [SerializeField] private LobbyCreateUI _lobbyCreateUI;
    [FormerlySerializedAs("lobbyContainer")] [SerializeField] private Transform _lobbyContainer;
    [FormerlySerializedAs("lobbyTemplate")] [SerializeField] private Transform _lobbyTemplate;


    private void Awake() {
        _mainMenuButton.onClick.AddListener(() => {
            UnityRelayLobbyServiceManager.Instance.LeaveLobby();
            AssetSceneManager.LoadScene(AssetSceneManager.AssetScene.MainMenuScene.ToString());
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
                
            }
        });
        _createLobbyButton.onClick.AddListener(() => {
            _lobbyCreateUI.Show();
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
                AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);

            }
        });
        _quickJoinButton.onClick.AddListener(() => {
            UnityRelayLobbyServiceManager.Instance.QuickJoin();
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Click);
            }
        });
        _joinCodeButton.onClick.AddListener(() => {
            UnityRelayLobbyServiceManager.Instance.JoinWithCode(_joinCodeInputField.text);
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Tab);
            }
        });

        _lobbyTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        _playerNameInputField.text = GameMultiplayerManager.Instance.GetPlayerName();
        _playerNameInputField.onValueChanged.AddListener((string newText) => {
            GameMultiplayerManager.Instance.SetPlayerName(newText);
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioResourceManager.Instance.Type);
            }
        });

        UnityRelayLobbyServiceManager.Instance.OnLobbyListChanged += KitchenGameLobby_OnLobbyListChanged;
        UpdateLobbyList(new List<Lobby>());
    }

    private void KitchenGameLobby_OnLobbyListChanged(object sender, UnityRelayLobbyServiceManager.OnLobbyListChangedEventArgs e) {
        UpdateLobbyList(e.LobbyList);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList) {
        foreach (Transform child in _lobbyContainer) {
            if (child == _lobbyTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Lobby lobby in lobbyList) {
            Transform lobbyTransform = Instantiate(_lobbyTemplate, _lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }

    private void OnDestroy() {
        UnityRelayLobbyServiceManager.Instance.OnLobbyListChanged -= KitchenGameLobby_OnLobbyListChanged;
    }

}