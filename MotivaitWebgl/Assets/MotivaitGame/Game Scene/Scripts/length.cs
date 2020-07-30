using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class length : MonoBehaviour
{
    public GameObject terrain;
    // Start is called before the first frame update
    void Start()
    {


        float terrainWidth = terrain.GetComponent<Collider>().bounds.size.x;

        float terrainLength = terrain.GetComponent<Collider>().bounds.size.y;

        float terrainHeight = terrain.GetComponent<Collider>().bounds.size.z;

        Debug.Log("x:" + terrainWidth + " y:" + terrainLength + " z" + terrainHeight);
    }

    // Update is called once per frame

}
