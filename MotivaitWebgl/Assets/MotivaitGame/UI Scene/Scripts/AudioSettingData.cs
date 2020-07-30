using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Setting Data", menuName = "Audio Setting", order = 1)]
public class AudioSettingData : ScriptableObject
{
    [Header("Music Vol")]
    public float musicVol = 0;

    [Header("Effect Vol")]
    public float effectVol = 0;
}
