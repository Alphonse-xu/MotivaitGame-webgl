using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    public GameObject musicComp;
    public GameObject effectComp;
    public AudioSettingData audioSettingData;
    private Slider slider;
    public void saveData()
    {
        slider = musicComp.GetComponent<Slider>();
        audioSettingData.musicVol = slider.value;
        slider = effectComp.GetComponent<Slider>();
        audioSettingData.effectVol = slider.value;
    }
}
