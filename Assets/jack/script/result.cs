using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour
{
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
