using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inven : MonoBehaviour
{
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
    }
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetComponent<TMP_Text>().text = ": " + data.items[i].ToString("#,##0");
        }
    }
}
