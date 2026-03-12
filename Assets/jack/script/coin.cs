using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    data_manager data;
    bool selected;
    public int count;
    private void Awake()
    {
        //float seed = Random.Range(0f, 100f);
        //Random.InitState((int)seed);
        count = 1;
    }
    private void OnEnable()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        switch (Random.Range(0, 2))
        {
            case 0: selected = true; break;
            case 1: selected = false; break;
        }
        GameObject.FindWithTag("canvas").transform.GetChild(0).gameObject.SetActive(true);
    }
    public void show(bool select)
    {
        if (data.act == Act.Play)
        {
            GetComponent<Animator>().enabled = false;
            if (selected)
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 205, 0, 255);
                GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(0).GetComponent<Outline>().effectColor = Color.green;
                GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(1).GetComponent<Outline>().effectColor = Color.red;
                if (select)
                {
                    if (count == 1) data.multi = 1.2f;
                    else data.multi = 1 + ((count - 1) * 0.5f) + (count - 1) / 2 * 0.5f;
                    GameObject.FindWithTag("canvas").transform.GetChild(2).gameObject.SetActive(true);
                    if (data.elog.coinmax < count) data.elog.coinmax = count;
                    data.elog.coinwin ++;
                }
                else
                {
                    data.elog.coinlose++;
                    data.multi = 0;
                    StartCoroutine(data.result());
                }

            }
            else
            {

                transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(197, 164, 58, 255);
                GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(0).GetComponent<Outline>().effectColor = Color.red;
                GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(1).GetComponent<Outline>().effectColor = Color.green;
                if (!select)
                {
                    if (count == 1) data.multi = 1.2f;
                    else data.multi = 1 + ((count - 1) * 0.5f) + (count - 1) / 2 * 0.5f;
                    GameObject.FindWithTag("canvas").transform.GetChild(2).gameObject.SetActive(true);
                    if(data.elog.coinmax < count)data.elog.coinmax = count;
                    data.elog.coinwin++;
                }
                else
                {
                    data.elog.coinlose++;
                    data.multi = 0;
                    StartCoroutine(data.result());
                }
            }
        }
    }
    public void go()
    {
        if (data.stamina <= 0)
        {
            data.infotext(1, false);
            StartCoroutine(data.result());
        }
        else
        {
            data.energydown();
            count++;
            GetComponent<Animator>().enabled = true;
            GameObject.FindWithTag("canvas").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(0).GetComponent<Outline>().effectColor = Color.black;
            GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(1).GetComponent<Outline>().effectColor = Color.black;
            GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(0).GetComponent<EventTrigger>().enabled = true;
            GameObject.FindWithTag("canvas").transform.GetChild(0).GetChild(1).GetComponent<EventTrigger>().enabled = true;
            GetComponent<Animator>().Rebind();
            GetComponent<Animator>().enabled = false;
            GetComponent<Animator>().enabled = true;
            transform.GetComponent<AudioSource>().Play();
        }
    }
    public void stop()
    {
        StartCoroutine(data.result());
    }
}