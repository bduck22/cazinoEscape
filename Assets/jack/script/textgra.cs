using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class textgra : MonoBehaviour
{
    TMP_Text Q;
    TMP_Text A;
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        Q = transform.GetChild(0).GetComponent<TMP_Text>();
        A = transform.GetChild(1).GetComponent<TMP_Text>();
        int o = Random.Range(0, data.goodtext.Length);
        Q.color = new Color32(255, 255, 255, 0);
        A.color = new Color32(255, 255, 255, 0);
        Q.text = data.goodtext[o][0];
        A.text = data.goodtext[o][1];
        StartCoroutine(goodtext());
    }
    void Update()
    {
        
    }
    IEnumerator goodtext()
    {
        data.act = Act.Sleep;
        byte p = 0;
        yield return new WaitForSeconds(1);
        while(Q.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            Color color = new Color32(255, 255, 255, p);
            p += 5;
            Q.color = color;
        }
        p = 0;
        yield return new WaitForSeconds(1);
        while (A.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            Color color = new Color32(255, 255, 255, p);
            p += 5;
            A.color = color;
        }
        transform.GetChild(2).GetComponent<EventTrigger>().enabled = true;
        transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "카지노 가기";
        transform.GetChild(2).GetComponent<Image>().color = new Color32(247, 237, 105, 255);
    }
}
