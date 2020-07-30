using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    private GameObject propManager;

    private void Awake()
    {
        propManager = GameObject.Find("PropManager");
    }

    void OnTouch()
    {
        foreach (Transform tran in propManager.GetComponentsInChildren<Transform>(true))
        {//遍历当前物体及其所有子物体
            Debug.Log(tran.gameObject.tag);

            if (tran.gameObject.CompareTag(gameObject.tag))
            {
                tran.gameObject.SetActive(true);
            }
        }

        gameObject.SetActive(false);
    }
}
