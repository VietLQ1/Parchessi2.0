using _Scripts.NetworkContainter;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.PlayerTurnUI
{
    public class PlayerTurnPanel : MonoBehaviour
    {
        [SerializeField] private Image _playerAvatarImage;
        [SerializeField] private TextMeshProUGUI _playerCardCountText;
        [SerializeField] private TextMeshProUGUI _playerDiceCountText;
        [SerializeField] private TextMeshProUGUI _playerVictoryPointText;
        [SerializeField] private TextMeshProUGUI _playerNameText;

        public void Initialize(PlayerController playerController, PlayerContainer playerContainer)
        {
            var championDescription = GameResourceManager.Instance.GetChampionDescription(playerContainer.ChampionID);
            _playerAvatarImage.sprite = championDescription.ChampionSprite;
            _playerNameText.text = playerContainer.PlayerName.ToString();
            
            playerController.PlayerResourceController.TurnCardCount.OnChangeValue += OnChangeCardCount;
            playerController.PlayerResourceController.TurnDiceCount.OnChangeValue += OnChangeDiceCount;    
        }

        private void OnChangeCardCount(int _, int newValue)
        {
            _playerCardCountText.text = newValue.ToString();
        }
        
        private void OnChangeDiceCount(int _, int newValue)
        {
            _playerDiceCountText.text = newValue.ToString();
        }
        
    }
}