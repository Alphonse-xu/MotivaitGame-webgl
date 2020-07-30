using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEffectVol : MonoBehaviour
{
    private Slider slider;
    public AudioSettingData audioSettingData;
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = audioSettingData.effectVol;
    }
}
