using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    float angle;
    void Start()
    {
        angle = transform.rotation.eulerAngles.z;
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        angle += Time.deltaTime * 120;
    }
}
