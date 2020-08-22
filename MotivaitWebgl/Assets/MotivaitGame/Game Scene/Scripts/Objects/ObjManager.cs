using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive Object manager
/// </summary>

public class ObjManager : MonoBehaviour
{
    private readonly Dictionary<GameObject,bool> m_interobjState = new Dictionary<GameObject, bool>();
    private readonly Dictionary<GameObject,GameObject> m_interobjPair = new Dictionary<GameObject, GameObject>();

    public GameObject cameraScript;
    public GameObject playerScript;
    public GameObject paper;
    public ObserveObj focus;
    public GameObject num3;

    private void Awake()
    {
        EventCenter.AddListener<GameObject>(EventType.picktool, PickupTool);
        EventCenter.AddListener<GameObject>(EventType.usedevice, UseDevice);
        EventCenter.AddListener<GameObject>(EventType.usetool, UseTool);
        EventCenter.AddListener<GameObject>(EventType.watchobj, WatchObj);
        EventCenter.AddListener(EventType.outwatchobj, OutWatchObj);

        RegisterObjstate(GameObject.Find("BlueKey"), GameObject.Find("door2"));
        RegisterObjstate(GameObject.Find("RedKey"), GameObject.Find("door3"));
        RegisterObjstate(GameObject.Find("Screwdriver"), GameObject.Find("Printer"));
        RegisterObjstate(GameObject.Find("ProjecterSwitch"), GameObject.Find("Whiteboard"));
        RegisterObjstate(GameObject.Find("RouterSwitch"), GameObject.Find("LaptopUse"));
        
    }

    private void RegisterObjstate(GameObject gameObject1,GameObject gameObject2)
    {
        m_interobjState.Add(gameObject1, false);
        m_interobjPair.Add(gameObject2, gameObject1);
    }

    private void PickupTool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        m_interobjState[gameObject] = true;
    }

    private void UseDevice(GameObject gameObject)
    {
        m_interobjState[gameObject] = true;
    }

    private void UseTool(GameObject gameObject)
    {
        if (m_interobjState[m_interobjPair[gameObject]])
        {
            if (gameObject.name.Equals("Printer"))
            {
                paper.SetActive(true);
                gameObject.layer = LayerMask.NameToLayer("Default");
            }

            if (gameObject.name.Equals("door2"))
            {
                EventCenter.Broadcast(EventType.bluekey);
            }

            if (gameObject.name.Equals("door3"))
            {
                EventCenter.Broadcast(EventType.redkey);
            }

            if (gameObject.name.Equals("door1"))
            {
                EventCenter.Broadcast(EventType.escapedoor);
            }

            if (gameObject.name.Equals("LaptopUse"))
            {
                EventCenter.Broadcast(EventType.laptopuse);
            }

            if (gameObject.name.Equals("Whiteboard"))
            {
                num3.SetActive(true);
            }

        }
        else
        {
            string s = "Lack " + m_interobjPair[gameObject].name;
            Debug.Log(s);
            EventCenter.Broadcast<string>(EventType.lacktool, s);
        }
    }

    private void WatchObj(GameObject gameObject)
    {
        EnableScript(false);
        ObserveObj.pivot = gameObject.transform;
        focus.SetFocused(gameObject);
    }

    private void OutWatchObj()
    {
        EnableScript(true);
        focus.SetFocused(null);
    }

    private void EnableScript(bool enable)
    {
        cameraScript.GetComponent<PlayerLook>().enabled = enable; // unable playerlook
        playerScript.GetComponent<PlayerMove>().enabled = enable;//unable playermove
    }

    private void PrinterPaperShow()
    {

    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<GameObject>(EventType.picktool, PickupTool);
        EventCenter.RemoveListener<GameObject>(EventType.usedevice, UseDevice);
        EventCenter.RemoveListener<GameObject>(EventType.usetool, UseTool);
        EventCenter.RemoveListener<GameObject>(EventType.watchobj, WatchObj);
        EventCenter.RemoveListener(EventType.outwatchobj, OutWatchObj);
    }

}
