using System;
using System.Collections.Generic;
using _Scripts.NetworkContainter;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Scripts.Game.UI.PlayerTurnUI
{
    public class PlayerTurnContent : MonoBehaviour
    {
        [SerializeField] private PlayerTurnPanel _playerTurnPanelPrefab;
        [SerializeField] private PlayerTurnHolder _playerTurnHolderPrefab;
        
        [SerializeField] private LayoutGroup _playerTurnPanelLayoutGroup;
        
        private readonly List<PlayerTurnPanel> _playerTurnPanels = new List<PlayerTurnPanel>();
        private readonly List<PlayerTurnHolder> _playerTurnHolders = new List<PlayerTurnHolder>();
        
        private void Awake()
        {
            GameManager.Instance.OnGameStart += LoadPlayerTurnPanel;
            GameManager.Instance.OnPlayerTurnStart += ReorderPlayerTurn;
            
        }

        private void LoadPlayerTurnPanel()
        {
            
            foreach (var playerController in GameManager.Instance.PlayerControllers)
            {
                var playerTurnHolder = Instantiate(_playerTurnHolderPrefab, _playerTurnPanelLayoutGroup.transform);
                
                PlayerContainer playerContainer;
                if(GameMultiplayerManager.Instance != null)
                    playerContainer = GameMultiplayerManager.Instance.GetPlayerContainerFromPlayerIndex((int) playerController.OwnerClientId);
                else
                {
                    playerContainer = PlayerContainer.CreateMockPlayerContainer(playerController.OwnerClientId);
                }
                
                var playerTurnPanel = Instantiate(_playerTurnPanelPrefab, playerTurnHolder.transform);
                playerTurnPanel.Initialize(playerController, playerContainer);
                
                _playerTurnPanels.Add(playerTurnPanel);
                _playerTurnHolders.Add(playerTurnHolder);
                
                playerTurnHolder.AddPanel(playerTurnPanel);
            }
            
            _playerTurnHolders[0].SetHighlight(true);
        }
        
        
        private void ReorderPlayerTurn(PlayerController playingPlayerController)
        {
            var lastPlayerTurnPanel = _playerTurnHolders[0].PlayerTurnPanel;
            
            for (var index = 0; index < _playerTurnHolders.Count - 1; index++)
            {
                int nextIndex = (index + 1) % _playerTurnHolders.Count;
                
                var playerTurnHolder = _playerTurnHolders[index];
                var nextPlayerTurnHolder = _playerTurnHolders[nextIndex];
                
                playerTurnHolder.RemovePanel();

                playerTurnHolder.AddPanel(nextPlayerTurnHolder.PlayerTurnPanel);
            }
            
            _playerTurnHolders[^1].RemovePanel();
            _playerTurnHolders[^1].AddPanel(lastPlayerTurnPanel);
        }

    }
}