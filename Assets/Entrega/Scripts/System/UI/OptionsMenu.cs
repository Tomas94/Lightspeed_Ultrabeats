using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Toggle _vibrationAllowed;
    [SerializeField] Image _brightnessBG;
    [SerializeField] Slider _brightnessSlider;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Toggle soundToggle;


    private void Start()
    {
        //_brightnessSlider.value = GameManager.instance.brigthnessValue;
        //_vibrationAllowed.isOn = GameManager.instance.vibration;
        soundToggle.isOn = IsSoundOn();
    }

    public void VibrationSwapState()
    {
        //GameManager.instance.vibration = _vibrationAllowed.isOn;
        PlayerPrefs.SetInt("Vibration", _vibrationAllowed ? 1 : 0);
    }

    public void Vibrate() { if (_vibrationAllowed) Handheld.Vibrate(); }

    public void BrightnessSet()
    {
        _brightnessBG.color = new Color(_brightnessBG.color.r, _brightnessBG.color.g, _brightnessBG.color.b, _brightnessSlider.value);
        //GameManager.instance.brigthnessValue = _brightnessSlider.value;
        PlayerPrefs.SetFloat("BrightnessValue", _brightnessSlider.value);
    }

    #region Volumen
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ToggleSound()
    {
        bool soundOn = soundToggle.isOn;
        SetSoundState(soundOn);
    }

    private bool IsSoundOn()
    {
        float volume;
        audioMixer.GetFloat("Volume", out volume);
        return volume > -80;
    }

    private void SetSoundState(bool soundOn)
    {
        float volume = soundOn ? 0.0f : -80.0f;
        SetVolume(volume);
    }
    #endregion

}
