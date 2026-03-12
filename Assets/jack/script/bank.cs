using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class bank : MonoBehaviour
{
    data_manager data;
    void Start()
    {
    }
    private void OnEnable()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
    }
    void init()
    {

        transform.GetChild(1).GetComponent<TMP_Text>().text = "보유 돈 : " + data.money.ToString("###,0") + "원";
        transform.GetChild(2).GetComponent<TMP_Text>().text = "빚 : " + data.dept.ToString("###,0") + "원";
        transform.GetChild(3).GetComponent<TMP_Text>().text = "이자 : " + (data.dept*0.025f).ToString("###,0")+"원(2.5%)";
        transform.GetChild(8).GetComponent<TMP_Text>().text = "대출 가능 : " + data.getmoney.ToString("#,##0") + "원 / 2,000,000원";
    }
    void Update()
    {
        init();
    }
}
