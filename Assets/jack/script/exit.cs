using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Exit()
    {
        StartCoroutine(eexit());
    }
    IEnumerator eexit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
