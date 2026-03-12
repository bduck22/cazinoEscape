using UnityEngine;
using UnityEngine.UI;


public enum Upgrade
{
    A,
    B
}
public class Store : MonoBehaviour
{
    PlayerData PD;
    [SerializeField] Transform Warnning;
    void Start()
    {
        PD = GameManager.Instance.PD;
        PD.NotDie = true;
    }
    void Update()
    {

    }

    public void BuyItem(int number)
    {
        if (GameManager.Instance.Money >= GameManager.Instance.ItemPrice[number] || GameManager.Instance.FREE)
        {
            if (PD.AddItem(number))
            {
                if(!GameManager.Instance.FREE)GameManager.Instance.Money -= GameManager.Instance.ItemPrice[number];
            }else warn(2);
        }
        else warn(0);
    }

    public void upgrade(int Type)
    {
        switch ((Upgrade)Type)
        {
            case Upgrade.A:
                if (GameManager.Instance.AirLevel < 3)
                {
                    if (GameManager.Instance.Money >= 300||GameManager.Instance.FREE)
                    {
                        if (!GameManager.Instance.FREE) GameManager.Instance.Money -= 200;
                        GameManager.Instance.AirLevel++;
                        PD.maxAir += 100;
                    }
                    else warn(0);
                }
                else
                {
                    warn(1);
                }
                break;
            case Upgrade.B:
                if (GameManager.Instance.BagLevel < 3)
                {
                    if (GameManager.Instance.Money >= 300 || GameManager.Instance.FREE)
                    {
                        if (!GameManager.Instance.FREE) GameManager.Instance.Money -= 200;
                        GameManager.Instance.BagLevel++;
                        PD.InvenSize += 2;
                        PD.maxWeight += 150;
                        PD.InvenLoad();
                    }else warn(0);
                }
                else warn(1);
                break;
        }
    }/*

*/
    void warn(int type)
    {
        
        switch (type)
        {
            case 0:Warnning.GetChild(0).GetComponent<Text>().text = "돈이 부족합니다";
                break;
            case 1: Warnning.GetChild(0).GetComponent<Text>().text = "이미 최대레벨입니다"; break;
            case 2: Warnning.GetChild(0).GetComponent<Text>().text = "공간이 부족합니다"; break;
        }
        Warnning.gameObject.SetActive(true);
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        PD.NotDie = false;
        PD.PlayerInit();
        GameManager.Instance.Save();
        Warnning.gameObject.SetActive(false);
        gameObject.SetActive(false);
        GameManager.Instance.Init();
    }
}
