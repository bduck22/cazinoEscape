using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class manual : MonoBehaviour
{
    int pagenum;
    TMP_Text page;
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        page = GetComponent<TMP_Text>();
        pagenum = 1;
        Loadingpage();
    }
    void Loadingpage()
    {
        if (pagenum - 1 < 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else transform.GetChild(0).gameObject.SetActive(true);
        if (pagenum + 1 > 9)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else transform.GetChild(1).gameObject.SetActive(true);
        page.text = $"-{pagenum}-";
        transform.parent.GetChild(pagenum).gameObject.SetActive(true);
        StartCoroutine(data.Savedata());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && pagenum>1)
        {
            pagech(true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&&pagenum<9)
        {
            pagech(false);
        }
    }
    public void pagech(bool Left_Right)
    {
        data.elog.manualmove++;
        GetComponent<AudioSource>().Play();
        if (Left_Right)
        {
            transform.parent.GetChild(pagenum--).gameObject.SetActive(false);
        }
        else
        {
            transform.parent.GetChild(pagenum++).gameObject.SetActive(false);
        }
        Loadingpage();
    }
}
