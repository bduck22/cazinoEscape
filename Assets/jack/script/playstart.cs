using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playstart : MonoBehaviour
{
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
    }
    void Update()
    {
        
    }
    public void Pinball()
    {
        if(GameObject.FindWithTag("canvas").transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<dealcount>().yes)transform.GetComponent<power>().enabled = true;
    }
    public void Coin()
    {
        if (GameObject.FindWithTag("canvas").transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<dealcount>().yes)transform.GetComponent<Animator>().enabled = true;
        if (GameObject.FindWithTag("canvas").transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<dealcount>().yes) transform.GetComponent<AudioSource>().Play();
    }
    public void Hover()
    {
            Cursor.SetCursor(Resources.Load<Texture2D>("hover"), Vector2.zero, CursorMode.Auto);
    }
    public void exit()
    {
            Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
    }
    public void cardset()
    {
        if (GameObject.FindWithTag("canvas").transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<dealcount>().yes) transform.GetComponent<cardsetting>().enabled = true;
    }
}
