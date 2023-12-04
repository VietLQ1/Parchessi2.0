using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.GameUI
{
    public class TimerSpin : MonoBehaviour
    {
        [SerializeField] private RectTransform _hourHand;
        [SerializeField] private float _spinDuration = 5f;
        [SerializeField] private Ease _spinEase = Ease.OutElastic;

        
        void Start()
        {
            // Call the SpinClockHour function to start the animation
            SpinClockHour();
        }

        void SpinClockHour()
        {
            // Set up the rotation animation for the hour hand
            _hourHand.transform.DORotate(new Vector3(0f, 0f, 180), _spinDuration, RotateMode.FastBeyond360)
                .SetEase(_spinEase)
                .OnComplete(() =>
                {
                    // Reset the rotation and loop the animation

                    _hourHand.transform.DORotate(new Vector3(0f, 0f, 360), _spinDuration, RotateMode.FastBeyond360)
                        .SetEase( _spinEase)
                        .OnComplete(()=>
                        {
                            _hourHand.transform.rotation = Quaternion.identity;
                            SpinClockHour();
                        });
                    
                    
                });
        }
        
    }
}