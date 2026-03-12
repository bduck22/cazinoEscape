using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTime : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "클리어한 시간 : " +  GameManager.Instance.time.ToString("#,##0.##") + "초";      
    }
    void Update()
    {
        
    }
}
