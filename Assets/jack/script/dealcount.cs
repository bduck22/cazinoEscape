using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class dealcount : MonoBehaviour
{
    public float dealmoney;
    TMP_Text text;
    public float maxmoney;
    public float defaultmoney;
    public bool ancher;
    public float anchermoney;
    public int useenergy;
    public bool yes;
    data_manager data;
    public GameObject closeob;
    bool bank_pay;
    public bool bank;
    void Start()
    {
        bank_pay = true;
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        yes = false;
        dealmoney = defaultmoney;
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (ancher)
        {
            if (dealmoney != anchermoney) dealmoney = anchermoney;
        }
        else
        {
            if (dealmoney > maxmoney) dealmoney = maxmoney;
            if (bank)
            {
                if (bank_pay)
                {
                    if (data.dept < data.money)
                    {
                        maxmoney = data.dept;
                    }
                    else maxmoney = data.money;
                }
                else maxmoney = data.getmoney;
            }
            else if(maxmoney > data.money)maxmoney = ((int)(data.money / 10000)) * 10000;
        }
        if (dealmoney != 0 && useenergy <= data.stamina && (dealmoney <= data.money||!bank_pay))
        {
            if (!yes) yes = true;
        }
        else if (yes) yes = false;
        text.text = "±Ý¾× : " + dealmoney.ToString("###,0") + "¿ø";
    }
    public void upmoney()
    {
        if ((dealmoney + 10000) <= maxmoney||(bank&&!bank_pay&& (dealmoney + 10000)<=data.getmoney))dealmoney += 10000;
    }
    public void downmoney()
    {
        if((dealmoney-10000)>=0)dealmoney -= 10000;
    }
    public void bigupmoney()
    {
        if ((dealmoney + 100000) <= maxmoney|| (bank && !bank_pay && (dealmoney + 100000) <= data.getmoney)) dealmoney += 100000;
    }
    public void bigdownmoney()
    {
        if ((dealmoney - 100000) >= 0) dealmoney -= 100000;
    }
    public void hover()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("hover"), Vector2.zero, CursorMode.Auto);
    }
    public void exit()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
    }
    public void max()
    {
        if(maxmoney <= data.money)
        {
            if((bank && bank_pay))
            {
                dealmoney = maxmoney;
            }
            else dealmoney = ((int)(maxmoney / 10000)) * 10000;
        }
        else
        {
            if ((bank))
            {
                if (bank_pay)
                {
                    dealmoney = data.money;
                }
                else dealmoney = maxmoney;
            }
            else dealmoney = ((int)(data.money/10000))*10000;
        }
    }
    public void min()
    {
        dealmoney = 0;
    }
    public void betting()
    {
        if(yes)
        {
            if(closeob)closeob.SetActive(false);
            data.usemoney = dealmoney;
            data.money -= dealmoney;
            for (int i = 0; i < useenergy; i++)
            {
                data.energydown();
            }
            data.act = Act.Play;
        }
        else
        {
            if(dealmoney == 0)
            {
                data.infotext(0, false);
            }
            else if(useenergy > data.stamina)
            {
                data.infotext(1, false);
            }
            else
            {
                data.infotext(2, false);
            }
        }
    }
    public void pay()
    {
        transform.GetChild(4).GetComponent<Image>().color = Color.gray;
        transform.GetChild(5).GetComponent<Image>().color = Color.yellow;
        bank_pay = true;
    }
    public void get()
    {
        transform.GetChild(5).GetComponent<Image>().color = Color.gray;
        transform.GetChild(4).GetComponent<Image>().color = Color.yellow;
        bank_pay = false;
    }
    public void correct()
    {

        if (yes)
        {
            if (bank_pay)
            {
                data.log.Enqueue(new Money_log(2, 10, 1, dealmoney, data.week, data.day, data.time));
                data.elog.paydept += dealmoney;
                GetComponent<AudioSource>().resource = Resources.Load<AudioResource>("pay");
                GetComponent<AudioSource>().Play();
                data.money -= dealmoney;
                data.dept -= dealmoney;
            }
            else
            {
                data.log.Enqueue(new Money_log(2, 9, 2, dealmoney, data.week, data.day, data.time));
                data.elog.dept += dealmoney;
                GetComponent<AudioSource>().resource = Resources.Load<AudioResource>("get");
                GetComponent<AudioSource>().Play();
                data.getmoney -= dealmoney;
                data.money += dealmoney;
                data.dept += dealmoney;
            }
            dealmoney = 0;
            StartCoroutine(data.Savedata());
        }
        else
        {
            if (dealmoney == 0)
            {
                data.infotext(0, false);
            }
        }
    }
}
