using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButton : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void rankview()
    {
        SType.Instance.OpenRankking();
    }
    public void goLobby()
    {
        SceneManager.LoadScene(0);
    }
}
