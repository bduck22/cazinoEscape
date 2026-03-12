using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class nextday : MonoBehaviour
{
    public float cool;
    data_manager data;
    public TMP_Text statetext;
    private void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        data.act = Act.Sleep;
        StartCoroutine(Up());
    }
    IEnumerator Up()
    {
        while(data.energyup())
        {
        }
        yield return new WaitForSeconds(cool);
        statetext.text = "카지노 가기";
        data.act = Act.Wait;
        Destroy(statetext.transform.GetComponent<tiping>());
        statetext.transform.parent.GetComponent<Image>().color = new Color32(247, 237, 105, 255);
        statetext.transform.parent.GetComponent<EventTrigger>().enabled = true;
    }
}
