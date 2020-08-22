using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC action
/// </summary>

public class NPC1 : MonoBehaviour
{
    private void Awake()
    {
        EventCenter.AddListener<GameObject>(EventType.nplayertalk, TeachingRule);
        EventCenter.AddListener(EventType.startgame, SetPosition);
    }

    private void TeachingRule(GameObject gameObject)
    {
        EventCenter.Broadcast<bool>(EventType.teachingrule, true);
        Cursor.lockState = CursorLockMode.None;
        gameObject.layer = 0;
    }

    private void SetPosition()
    {
        transform.position = new Vector3(-11.21f,0.04f,-7.33f);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<GameObject>(EventType.nplayertalk, TeachingRule);
        EventCenter.RemoveListener(EventType.startgame, SetPosition);
    }
}
