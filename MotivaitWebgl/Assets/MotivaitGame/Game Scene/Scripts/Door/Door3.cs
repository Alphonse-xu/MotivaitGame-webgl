using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// door3 open close router room
/// </summary>

public class Door3 : Door
{
    private void Awake()
    {
        EventCenter.AddListener(EventType.redkey, DoorPlay);
    }
}
