using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGM : MonoBehaviour
{
    void Start()
    {
        if(!SType.Instance.New)StartCoroutine(GameManager.Instance.Load());
    }
    void Update()
    {
        GameManager.Instance.enabled = true;   
    }
}
