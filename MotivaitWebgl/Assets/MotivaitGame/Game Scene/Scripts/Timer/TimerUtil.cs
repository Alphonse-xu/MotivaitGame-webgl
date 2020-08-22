using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// timer tool
/// </summary>

public class TimerUtil
{
    private static float timer = -1;
    private static float oldTimer= -1;
    
    public static int Timer
    {
        get { return (int)timer; }
    }

    public static void SetTimerUtil(float timer)
    {
        oldTimer = timer;
        TimerUtil.timer = oldTimer;
    }

    public static void Update()
    {
        timer -= Time.deltaTime;
    }

    public static void ResetTimer()
    {
        timer = oldTimer;
    }

    public static void SetDefault()
    {
        timer = -1;
    }
}
