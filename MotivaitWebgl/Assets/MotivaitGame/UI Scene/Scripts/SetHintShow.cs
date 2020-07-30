using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SetHintShow : MonoBehaviour, IPointerEnterHandler
{
    public GameObject setHintObj;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        setHintObj.SetActive(true);
        audioSource.Play();
    }
}
