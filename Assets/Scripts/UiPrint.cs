using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UiType
{
    Hp,
    Air,
    Weight,
    Money,
    ALevel,
    BLevel,
    MA,
    Time
}
public class UiPrint : MonoBehaviour
{
    PlayerData PD;
    [SerializeField] UiType Type;
    Text text;
    Image image;
    void Start()
    {
        PD = GameManager.Instance.PD;
        text = transform.GetChild(0).GetComponent<Text>();
        image = GetComponent<Image>();
    }
    void Update()
    {
        switch (Type)
        {
            case UiType.Hp:text.text = PD.Hp + " / " + PD.maxHp;
                image.fillAmount =  PD.Hp / PD.maxHp;
                break;
            case UiType.Air:
                text.text = (int)PD.Air + " / " + PD.maxAir;
                image.fillAmount =  PD.Air / PD.maxAir;
                break;
            case UiType.Weight:
                text.text = PD.Weight + "kg / " + PD.maxWeight + "kg";
                break;
            case UiType.Money:
                text.text = GameManager.Instance.Money.ToString("#,##0$");
                break;
            case UiType.ALevel:
                text.text = "산소통 강화 Lv." + GameManager.Instance.AirLevel + " (Max.3)";
                break;
            case UiType.BLevel:
                text.text = "배낭 강화 Lv." + GameManager.Instance.BagLevel + " (Max.3)";
                break;
            case UiType.MA:
                text.text = "현재 상소 최대치 : " + PD.maxAir;
                break;
            case UiType.Time:
                text.text = GameManager.Instance.time.ToString("#,##0.##");
                break;
        }
    }
}
