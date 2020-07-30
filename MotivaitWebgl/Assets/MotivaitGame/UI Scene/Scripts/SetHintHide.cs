using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetHintHide : MonoBehaviour, IPointerExitHandler
{
    public GameObject setHintObj;
    public void OnPointerExit(PointerEventData eventData)
    {
        setHintObj.SetActive(false);
    }
}
