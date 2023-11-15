using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Setting.UI
{
    [RequireComponent(typeof(Slider))]
    public class SFXAudioSlider : MonoBehaviour
    {
        private Slider _slider;
        private void Awake()
        {
            
            _slider = GetComponent<Slider>();
            
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            AudioManager.Instance.ChangeSfxVolume(value);
        }

    }
}