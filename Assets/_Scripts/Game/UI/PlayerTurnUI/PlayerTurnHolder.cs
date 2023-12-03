using DG.Tweening;
using UnityEngine;

namespace _Scripts.Game.UI.PlayerTurnUI
{
    
    
    
    public class PlayerTurnHolder : MonoBehaviour
    {
        [SerializeField] private float _moveDuration = 0.25f;
        [SerializeField] private Ease _moveEase = Ease.OutBack;

        [SerializeField] private Vector3 _originOffset = new Vector3(180f, 0f, 0f);
        [SerializeField] private float _highlightScale = 1.2f;
        
        
        private Tween _moveTween;
        private Tween _scaleTween;
        [HideInInspector] public PlayerTurnPanel PlayerTurnPanel;
        
        public void SetHighlight(bool highlightScale)
        {
            transform.localScale = transform.localScale * (highlightScale ? _highlightScale : 1f);
        }
        
        public void AddPanel(PlayerTurnPanel playerTurnPanel)
        {
            playerTurnPanel.transform.SetParent(transform);
            
            _moveTween = playerTurnPanel.transform.DOLocalMove(_originOffset * _highlightScale, _moveDuration).SetEase(_moveEase);
            _scaleTween = playerTurnPanel.transform.DOScale(transform.localScale, _moveDuration).SetEase(_moveEase);
            
            
            PlayerTurnPanel = playerTurnPanel;
        }
        
        public void RemovePanel()
        {
            _moveTween.Kill();
            _scaleTween.Kill();
            
            PlayerTurnPanel = null;
        }
        
        
    }
}