using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    
    public Slider senssivitySlider;
    public float maxSenssivity = 5f;
    void OnEnable()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("AudioSetting");
        senssivitySlider.value = PlayerPrefs.GetFloat("SensibilitySetting")/maxSenssivity;
    }

    public void SliderChangeValue()
    {
        GameManager.instance.ChangeAudio(volumeSlider.value);
    }

    public void SliderChangeSenssibility()
    {
        GameManager.instance.ChangeSenssibilty(senssivitySlider.value * maxSenssivity);
    }
}
