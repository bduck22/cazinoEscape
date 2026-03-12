using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void NewGame()
    {
        SType.Instance.New = true;
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SType.Instance.New = false;
        SceneManager.LoadScene(1);
    }

    public void Rankking()
    {

    }

    public void GameEnd()
    {
        Application.Quit();
    }
}
