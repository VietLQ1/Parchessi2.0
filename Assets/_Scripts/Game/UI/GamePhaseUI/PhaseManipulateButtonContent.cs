using System;
using _Scripts.UI.GameUI;
using UnityEngine;
using UnityEngine.UI;

public class PhaseManipulateButtonContent : MonoBehaviour
{
    PlayerController _playerController;
    
    [SerializeField] private PhaseManipulateButtonController _waitButton;
    [SerializeField] private EndSubsequenceButtonController _endSubsequenceButtonController;
    [SerializeField] private EndRollButtonController _endRollButtonController;
    [SerializeField] private StartRollButtonController _startRollButtonController;
   
    [Header("Timer")]
    [SerializeField] private PhaseTimer _phaseTimer;
    [SerializeField] private float _timerMaxTime = 150f;
    
    private PhaseManipulateButtonController _currentActiveButton;

    private void Awake()
    {
        GameManager.Instance.OnClientPlayerControllerSetUp += GameSetUp;
        
        SetContent();
        DisableAllExceptWait();
    }

    private void GameSetUp()
    {
        _playerController = GameManager.Instance.ClientOwnerPlayerController;
        _playerController.PlayerTurnController.CurrentPlayerPhase.OnValueChanged += CurrentPlayerPhaseChanged;
    }

    private void SetContent()
    {
        _endSubsequenceButtonController.SetContent(this, _phaseTimer);
        _endRollButtonController.SetContent(this, _phaseTimer);
        _startRollButtonController.SetContent(this, _phaseTimer);
        
    }

    
    private void DisableAllExceptWait()
    {
        _endSubsequenceButtonController.gameObject.SetActive(false);
        _endRollButtonController.gameObject.SetActive(false);
        _startRollButtonController.gameObject.SetActive(false);
        _waitButton.gameObject.SetActive(true);
        
        _currentActiveButton = _waitButton;
    }
    
    private void CurrentPlayerPhaseChanged(PlayerTurnController.PlayerPhase previousValue, PlayerTurnController.PlayerPhase newValue)
    {
        switch (newValue)
        {
            case PlayerTurnController.PlayerPhase.WaitPhase:
                SwapButton(_waitButton);
                break;
            case PlayerTurnController.PlayerPhase.PreparationPhase:
                SwapButton(_startRollButtonController);
                break;
            case PlayerTurnController.PlayerPhase.RollPhase:
                SwapButton(_endRollButtonController);
                break;
            case PlayerTurnController.PlayerPhase.SubsequencePhase:
                SwapButton(_endSubsequenceButtonController);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newValue), newValue, null);
        }
        
        
    }

    private void SwapButton(PhaseManipulateButtonController newButton)
    {
        if (_currentActiveButton == null) return;

        _currentActiveButton.gameObject.SetActive(false);
        _currentActiveButton = newButton;
        _currentActiveButton.gameObject.SetActive(true);
        
        
        _phaseTimer.ResetTimer(_timerMaxTime, onTimerComplete: () =>
        {
            _currentActiveButton.TriggerEndPhase();
        });
        _phaseTimer.SetTimerActive(true);
    }
    
    
}
