using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class store : MonoBehaviour
{
    public int[] windowitem;
    bool onlyone;
    data_manager data;
    int[] price;
    private void Awake()
    {
        price = new int[5];
        price[0] = 50000;
        price[1] = 150000;
        price[2] = 400000;
        price[3] = 1000000;
        price[4] = 2000000;
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        onlyone = true;
        windowitem = new int[3];
    }
    void Start()
    {

    }
    void Update()
    {
        soldout();
    }
    public void Rotation()
    {
        onlyone = true;
        for (int i = 0; i < 3; i++)
        {
            float num = Random.Range(0, 20);
            if (num < 1 && onlyone)
            {
                onlyone = false;
                windowitem[i] = 5;
            }
            else if (num < 3)
            {
                windowitem[i] = 4;
            }
            else if (num < 6)
            {
                windowitem[i] = 3;
            }
            else if (num < 12)
            {
                windowitem[i] = 2;
            }
            else
            {
                windowitem[i] = 1;
            }
            transform.GetChild(i + 1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"item{windowitem[i]}");
            transform.GetChild(i+1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "구매하기";
            transform.GetChild(i+1).GetChild(0).GetComponent<EventTrigger>().enabled = true;
            transform.GetChild(i+1).GetChild(0).GetComponent<Image>().color = Color.yellow;
        }
    }
    public void buy(int num)
    {
        if (data.act == Act.Wait)
        {
            if (windowitem[num] != 0)
            {
                if (price[windowitem[num] - 1] <= data.money)
                {
                    GetComponent<AudioSource>().resource = Resources.Load<AudioResource>("chaaa");
                    GetComponent<AudioSource>().Play();
                    data.money -= price[windowitem[num] - 1];
                    data.log.Enqueue(new Money_log(0, windowitem[num] + 3, 1, price[windowitem[num] - 1], data.week, data.day, data.time));
                    if (windowitem[num] > 2)
                    {
                        switch(windowitem[num] - 3)
                        {
                            case 0:data.elog.buydouble++; break;
                            case 1: data.elog.buyinsurance++; break;
                            case 2: data.elog.buyhotel++; break;
                        }
                        data.items[windowitem[num] - 3]++;
                    }
                    else
                    {
                        switch (windowitem[num])
                        {
                            case 1:
                                {
                                    data.elog.buygacha++;
                                    float numm = Random.Range(0, 200);
                                    if (numm < 5)
                                    {
                                        data.elog.getgacha++;
                                        data.infotext(5, true);
                                        GetComponent<AudioSource>().resource = Resources.Load<AudioResource>("corrrrect");
                                        GetComponent<AudioSource>().Play();
                                        data.money += 10000000;
                                        data.elog.getmoney += 10000000;
                                        data.log.Enqueue(new Money_log(0, windowitem[num] + 3, 2, 10000000, data.week, data.day, data.time));
                                    }
                                    else data.infotext(4, true);
                                    break;
                                }
                            case 2:
                                {
                                    data.elog.drink++;
                                    data.infotext(6, true);
                                    data.energyup();
                                    break;
                                }
                        }
                    }
                    windowitem[num] = 0;
                    StartCoroutine(data.Savedata());
                }
                else
                {
                    data.infotext(2, false);
                }
            }
            else
            {
                data.infotext(3, false);
            }
        }
    }
    public void soldout()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (windowitem[i - 1] == 0)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("soldout");
                transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "매진";
                transform.GetChild(i).GetChild(0).GetComponent<EventTrigger>().enabled = false;
                transform.GetChild(i).GetChild(0).GetComponent<Image>().color = Color.red;
            }
            else
            {
                if(transform.GetChild(i).GetComponent<Image>().sprite!= Resources.Load<Sprite>($"item{windowitem[i-1]}")) transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>($"item{windowitem[i-1]}");
                if(transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text!= "구매하기") transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "구매하기";
                if(!transform.GetChild(i).GetChild(0).GetComponent<EventTrigger>().enabled) transform.GetChild(i).GetChild(0).GetComponent<EventTrigger>().enabled = true;
                if(transform.GetChild(i).GetChild(0).GetComponent<Image>().color!= Color.red) transform.GetChild(i).GetChild(0).GetComponent<Image>().color = Color.yellow;
            }
        }
    }
    public void light(int num)
    {
        if (data.act == Act.Wait) transform.GetChild(num).GetChild(0).GetComponent<Image>().color = Color.red;
    }
    public void lightoff(int num)
    {
        if (data.act == Act.Wait) transform.GetChild(num).GetChild(0).GetComponent<Image>().color = Color.yellow;
    }
}
