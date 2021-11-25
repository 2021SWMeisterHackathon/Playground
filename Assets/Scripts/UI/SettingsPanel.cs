using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsPanel : MonoBehaviour
    {
        private const int MaxVolumeValue = 10;
        private const float VolumeRatio = 1 / (float)MaxVolumeValue;

        [SerializeField] private Text bgmSliderValueText;
        [SerializeField] private Text sfxSliderValueText;
        
        public void OnBGMSliderValueChange(float value)
        {
            AudioManager.Instance.BGMVolume = value * VolumeRatio;
            bgmSliderValueText.text = value.ToString();
        }
        
        public void OnSFXSliderValueChange(float value)
        {
            AudioManager.Instance.SFXVolume = value * VolumeRatio;
            sfxSliderValueText.text = value.ToString();
        }
    }
}