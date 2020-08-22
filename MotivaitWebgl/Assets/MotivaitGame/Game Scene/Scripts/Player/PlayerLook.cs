using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// control player look around and try to cathch the object
/// </summary>

public class PlayerLook : MonoBehaviour
{
    private float mouseSensitivity = 150f;
    private float minimumY = -60f;
    private float maximumY = 60f;
    private float xAxisClamp = 0f;
    private int layerMask = 1 << 9;
    public Transform playerBody;

    void Update()
    {
        CameraRotation();
        RayHitObj();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;
        xAxisClamp = Mathf.Clamp( xAxisClamp,minimumY, maximumY);

        transform.eulerAngles = new Vector3(-xAxisClamp, transform.eulerAngles.y, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void RayHitObj()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f,layerMask))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            EventCenter.Broadcast<bool>(EventType.uitouchedobj,true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                EventCenter.Broadcast<GameObject>((EventType)Enum.Parse(typeof(EventType), hit.collider.gameObject.tag), hit.collider.gameObject);
                
            }
        }
        else
        {
            EventCenter.Broadcast<bool>(EventType.uitouchedobj, false);
        }
    }

}
