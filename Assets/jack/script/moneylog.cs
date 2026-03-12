using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class moneylog : MonoBehaviour
{
    data_manager data;
    TMP_Text text;
    private void Awake()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        text = GetComponent<TMP_Text>();
    }
    void Start()
    {
    }
    void Update()
    {
        loadlog();
    }
    private void OnEnable()
    {
        loadlog();
    }
    void loadlog()
    {
        text.text = "";
        foreach(Money_log log in data.log)
        {
            string sr = "";
            if (log.type == 0)
            {
                sr += "상점";
            }
            else if (log.type==1)
            {
                sr += "게임";
            }
            else
            {
                sr += "은행";
            }
            sr += " - ";
            switch (log.name)
            {
                case 0: sr += "동전 던지기"; break;//
                case 1: sr += "핀볼"; break;//
                case 2: sr += "블랙잭"; break;//
                case 3: sr += "광고시청"; break;//
                case 4: sr += "복권"; break;
                case 5: sr += "에너지 드링크"; break;
                case 6: sr += "묻고 따블"; break;
                case 7: sr += "보험 계약"; break;
                case 8: sr += "호텔 1일 숙박권"; break;
                case 9: sr += "대출";break;
                case 10: sr += "상환"; break;
            }
            sr += " $";
            switch (log.math_type)
            {
                case 1:sr += "-";break;
                case 2:sr += "+";break;
            }
            sr += log.value.ToString("#,###") + " : " +log.week.ToString("#,###") + "주차 " + log.day.ToString("#,###") + "일차 " + log.times.ToString("#,###") + "번째\n";
            text.text = text.text.Insert(0, sr);
        }
    }
}
