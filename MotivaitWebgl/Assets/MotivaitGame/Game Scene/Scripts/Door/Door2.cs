using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// door2 open close meeting room
/// </summary>

public class Door2 : Door
{
    private void Awake()
    {
        EventCenter.AddListener(EventType.bluekey, DoorPlay);
    }

}
