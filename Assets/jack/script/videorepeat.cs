using NUnit.Framework.Internal.Commands;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class videorepeat : MonoBehaviour
{
    VideoPlayer player;
    public Image gage;
    bool wait;
    bool fir_tri;
    data_manager data;
    public GameObject effect;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        fir_tri = true;
        wait = false;
        player = GetComponent<VideoPlayer>();
    }
    void Update()
    {
        gage.fillAmount = (float)(player.time / player.length);
        if (!player.isPlaying&&!wait)
        {
            if (!fir_tri)
            {
                GetComponent<AudioSource>().Play();
                data.money += ((float)(player.length / 1.5f)) * 100;
                data.elog.watchadd++;
                effect.GetComponent<TMP_Text>().text = "+" + (((float)(player.length / 1.5f))*100).ToString("#,###");
                data.log.Enqueue(new Money_log(1, 3, 2, ((float)(player.length / 1.5f)) * 100, data.week, data.day, data.time));
                data.elog.getmoney += ((float)(player.length / 1.5f)) * 100;
                effect.SetActive(false);
                effect.SetActive(true);                
                StartCoroutine(data.Savedata());
            }
            else fir_tri = false;
            wait = true;
            //float seed = Random.Range(0f, 100f);
            //Random.InitState((int)seed);
            int ran = Random.Range(0, 36);
            player.clip = Resources.Load<VideoClip>($"video{ran}");
            player.Play();
        }
        else if(player.isPlaying) wait = false;
    }
}
