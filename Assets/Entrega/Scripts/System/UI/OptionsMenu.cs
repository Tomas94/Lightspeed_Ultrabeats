using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Toggle _vibrationAllowed;
    [SerializeField] Image _brightnessBG;
    [SerializeField] Slider _brightnessSlider;

    private void Start()
    {
        _brightnessSlider.value = GameManager.Instance.brigthnessValue;
        _vibrationAllowed.isOn = GameManager.Instance.vibration;
    }

    public void VibrationSwapState()
    {
        GameManager.Instance.vibration = _vibrationAllowed.isOn;
        PlayerPrefs.SetInt("Vibration", _vibrationAllowed ? 1 : 0);
    }

    public void Vibrate() { if (_vibrationAllowed) Handheld.Vibrate(); }

    public void BrightnessSet()
    {
        _brightnessBG.color = new Color(_brightnessBG.color.r, _brightnessBG.color.g, _brightnessBG.color.b, _brightnessSlider.value);
        GameManager.Instance.brigthnessValue = _brightnessSlider.value;
        PlayerPrefs.SetFloat("BrightnessValue", _brightnessSlider.value);
    }
}
