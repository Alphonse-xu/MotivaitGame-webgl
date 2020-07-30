using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObserveObj : MonoBehaviour
{
    public static Transform pivot;
    public Vector3 pivotOffset = new Vector3(0,0.05f,0);
    public float distance = 0.3f;
    public float minDistance = 0.15f;
    public float maxDistance = 1f;
    public float zoomSpeed = 0.05f;
    public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;
    public bool  allowYTilt = true;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    private float x = 0.0f;
    private float y = 0.0f;
    private float targetX = 0f;
    private float targetY = 0f;
    public float targetDistance = 0f;
    private float xVelocity = 1f;
    private float yVelocity = 1f;
    private float zoomVelocity = 1f;

    private GameObject currentlyFocused;
    private int previousLayer;
    private GameObject rawImage;

    private void Awake()
    {
        rawImage = GameObject.Find("UI/GamePanel/ObjDisplayImage");
    }

    private void Start()
    {
        var angles = transform.eulerAngles;
        targetX = x = angles.x;
        targetY = y = ClampAngle(angles.y, yMinLimit, yMaxLimit);
        targetDistance = distance;

    }


    private void LateUpdate()
    {
        if (!pivot) return;
        var scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0.0f) 
            targetDistance -= zoomSpeed;
        else if (scroll < 0.0f)
            targetDistance += zoomSpeed;

        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);

        if (Input.GetMouseButton(1))
        {
            targetX += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            if (allowYTilt)
            {
                targetY -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                targetY = ClampAngle(targetY, yMinLimit, yMaxLimit);
            }
        }

        x = Mathf.SmoothDampAngle(x, targetX, ref xVelocity, 0.3f);
        y = allowYTilt ? Mathf.SmoothDampAngle(y, targetY, ref yVelocity, 0.3f) : targetY;
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        distance = Mathf.SmoothDamp(distance, targetDistance, ref zoomVelocity, 0.5f);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + pivot.position + pivotOffset;
        transform.rotation = rotation;
        transform.position = position;


        if (Input.GetMouseButton(0))
        {
            pivot.gameObject.SendMessage("OutTouch");
        }
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    public void SetFocused(GameObject obj)
    {
        gameObject.SetActive(true);
        
        if (currentlyFocused) currentlyFocused.layer = previousLayer;

        currentlyFocused = obj;

        if (currentlyFocused)
        {
            previousLayer = currentlyFocused.layer;
            foreach (Transform tran in currentlyFocused.GetComponentsInChildren<Transform>())
            {//遍历当前物体及其所有子物体
                tran.gameObject.layer = LayerMask.NameToLayer("Focused");//更改物体的Layer层
            }
            //currentlyFocused.layer = LayerMask.NameToLayer("Focused");
            rawImage.SetActive(true);
        }
        else
        {
            // if no object is focused disable the FocusCamera
            // and PostProcessingVolume for not wasting rendering resources
            OnDisable();
            gameObject.SetActive(false);
            rawImage.SetActive(false);
        }
    }

    // On disable make sure to reset the current object
    private void OnDisable()
    {
        if (currentlyFocused) currentlyFocused.layer = previousLayer;

        currentlyFocused = null;
    }
}
