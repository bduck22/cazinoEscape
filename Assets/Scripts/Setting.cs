using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private Transform setting;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setting.gameObject.SetActive(!setting.gameObject.activeSelf);
        }
    }
    public void Exit()
    {
        setting.gameObject.SetActive(false);
    }
    public void GameInit()
    {
        GameManager.Instance.DataInit();
    }
    public void LoopReset()
    {
        GameManager.Instance.Init();
    }
}
