using Unity.Netcode;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Game.UI.SettingUI
{
    public class SurrenderPanel : MonoBehaviour
    {
        [SerializeField] private Button _surrenderButton;
        [SerializeField] private Transform _surrenderConfirmPanel;
        
        
        void Start()
        {
            _surrenderButton.onClick.AddListener(ReturnToHome);
        }

        
        
        private void ReturnToHome()
        {
            NetworkManager.Singleton.Shutdown();
            
            AssetSceneManager.LoadScene(AssetSceneManager.AssetScene.LobbyScene.ToString());
            
        }
        
        
    }
}