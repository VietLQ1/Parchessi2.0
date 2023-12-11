
using System;
using _Scripts.UI.GameUI;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _errorText;
    [SerializeField] private Image _errorImage;
    [SerializeField] private PhaseTimer _timerBar;
    
    [Header("Move Tween")]
    [SerializeField] private Transform _hidePosition;
    [SerializeField] private Transform _showPosition;
    
    [SerializeField] private float _showTime = 3f;
    [SerializeField] private float _moveTime = 0.5f;
    [SerializeField] private Ease _moveEase = Ease.OutBack;
    
    
    
    private void Awake()
    {
        _errorText = GetComponentInChildren<TextMeshProUGUI>();
        _errorImage = GetComponentInChildren<Image>();
        _timerBar = GetComponentInChildren<PhaseTimer>();
    }

    
    public void Show(string errorText)
    {
        _errorText.text = errorText;
        
        transform.DOMove(_showPosition.position, _moveTime).SetEase(_moveEase);
        
        _timerBar.ResetTimer(_showTime, Hide, _showTime);
        _timerBar.SetTimerActive(true);
    }

    private void Hide()
    {
        transform.DOMove(_hidePosition.position, _moveTime).SetEase(_moveEase);


    }
    
    
    
}
