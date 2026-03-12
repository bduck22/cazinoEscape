using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class follow : MonoBehaviour
{
    Vector3 wid;
    public Camera camera;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void mousewid()
    {
        wid = new Vector3(Input.mousePosition.x, Input.mousePosition.y)- new Vector3(transform.position.x, transform.position.y);
    }
    public void Follow()
    {
        if(Input.mousePosition.x>0&& Input.mousePosition.x < 1920&& Input.mousePosition.y>0&& Input.mousePosition.y < 1080)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) - wid;
        }
    }
}
