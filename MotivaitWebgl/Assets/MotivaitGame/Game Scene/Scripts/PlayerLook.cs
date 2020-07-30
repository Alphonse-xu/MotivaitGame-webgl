using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float mouseSensitivity;
    public Transform playerBody;
    private float minimumY; 
    private float maximumY;
    private float xAxisClamp;
    private int layerMask;

    private GameObject useText;
    private GameObject useImage;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0F;
        mouseSensitivity = 150.0F;
        layerMask = 1 << 9;
        minimumY = -60f;
        maximumY = 60f;
        useText = UIManager.Instance.gamePanel.transform.GetChild(3).GetChild(1).gameObject;
        useImage = UIManager.Instance.gamePanel.transform.GetChild(3).GetChild(0).gameObject;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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
            useText.SetActive(true);
            useImage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.SendMessage("OnTouch");
            }
        }
        else
        {
            useText.SetActive(false);
            useImage.SetActive(false);
        }
    }


}
