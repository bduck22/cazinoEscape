using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SType : MonoBehaviour
{
    public static SType Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    public bool New;

    public void OpenRankking()
    {
        //GameObject.FindFirstObjectByType<Rankking>().gameObject.SetActive(true);
    }
}
