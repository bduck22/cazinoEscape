using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class select : MonoBehaviour
{
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
    }
    void Update()
    {
        
    }
    public void light(int num)
    {
        if(data.act == Act.Wait)
        {
            transform.GetChild(num).GetComponent<Outline>().effectColor = Color.red;
        }
    }
    public void lightoff(int num)
    {
        transform.GetChild(num).GetComponent<Outline>().effectColor = Color.black;
    }
    public void Move(int num)
    {
        if (data.act == Act.Wait)
        {
            SceneManager.LoadScene(num);
        }
    }
    public void Hover()
    {
        if (data.act == Act.Wait)
        {
            Cursor.SetCursor(Resources.Load<Texture2D>("hover"), Vector2.zero, CursorMode.Auto);
        }
    }
    public void exit()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
    }
    public void nextday()
    {
        data.dayup();
    }
}
