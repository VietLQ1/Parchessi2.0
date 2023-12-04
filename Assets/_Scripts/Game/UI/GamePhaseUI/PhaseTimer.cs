using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.GameUI
{
    public class PhaseTimer : MonoBehaviour
    {

        [SerializeField] private Slider _timerSlider;

        [SerializeField] private float _timerAnimationSpeed = 0.5f;
        
        private float _currentTime;
        private float _maxTime;

        // Callback to be invoked when the timer completes
        public Action OnTimerComplete;

        private bool _isAnimationRunning;
        private bool _isTimerRunning;
        
        
        
        private void Update()
        {
            if(_isAnimationRunning || !_isTimerRunning) return;
            
            RunTimer();
        }
        
        public void SetTimerActive(bool isActive)
        {
            _isTimerRunning = isActive;
        }

        private void RunTimer()
        {
            _currentTime -= Time.deltaTime;
            
            _timerSlider.value = _currentTime / _maxTime;

            // Check if the timer has reached zero
            if (_currentTime <= 0f)
            {
                // Invoke the OnTimerComplete callback
                OnTimerComplete?.Invoke();
            }
        }
        
        public void ResetTimer(float maxTime, Action onTimerComplete)
        {
            _maxTime = maxTime;
            OnTimerComplete = onTimerComplete;
        
            
            MoveTimerBar(_currentTime, _maxTime);
        }
        
        public void AddTime(float timeToAdd)
        {
            
            MoveTimerBar(_currentTime, _currentTime+timeToAdd);
        }

        public void MoveTimerBar(float startTime, float endTime)
        {
            
            _timerSlider.value = _currentTime / _maxTime;
            _currentTime = endTime;
            _isAnimationRunning = true;

            // Use OnComplete callback to trigger actions when the animation completes
            _timerSlider.DOValue(endTime / _maxTime,( (endTime - startTime)/(endTime*_timerAnimationSpeed)))
                .OnComplete(() =>
                {
                    // Optionally, you can perform additional actions here
                    Debug.Log("Timer animation completed!");
                    
                    _isAnimationRunning = false;
                });
        }
        
        
    }
}