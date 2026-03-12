using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class main : MonoBehaviour
{
    void Start()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
        string fileName2 = "clear.csv";
        string path2 = Application.dataPath;
        path2 = path2.Substring(0, path2.LastIndexOf('/'));
        string filepath2 = Path.Combine(path2, "Assets", "Resources/");
        using (StreamReader sr = new StreamReader(filepath2 + fileName2))
        {
            string source = sr.ReadLine();
            if(int.Parse(source) == 1)
            {
                transform.GetChild(5).gameObject.SetActive(true);
            }
            source = sr.ReadLine();
            if(int.Parse(source) == 0)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        
    }
    public void credit()
    {
        SceneManager.LoadScene(7);
    }
    public void light(int num)
    {
        transform.GetChild(num).GetComponent<TMP_Text>().color = Color.yellow;
    }
    public void lightoff(int num)
    {
        transform.GetChild(num).GetComponent<TMP_Text>().color = Color.white;
    }
    public void NewGame()
    {
        string fileName = "Gamedata.csv";
        string path = Application.dataPath;
        path = path.Substring(0, path.LastIndexOf('/'));
        string filepath = Path.Combine(path, "Assets", "Resources/");


        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }

        StreamWriter outStream = new StreamWriter(filepath + fileName);
        string text = "1000000;1;1";
        outStream.WriteLine(text);
        text = "5;5;1;10000000;2000000;1";
        outStream.WriteLine(text);
        int[] p = new int[3];
        bool onlyone = true;
        for(int i = 0; i < 3; i++)
        {
            float num = Random.Range(0, 20);
            if (num < 1 && onlyone)
            {
                onlyone = false;
                p[i] = 5;
            }
            else if (num < 3)
            {
                p[i] = 4;
            }
            else if (num < 6)
            {
                p[i] = 3;
            }
            else if (num < 12)
            {
                p[i] = 2;
            }
            else
            {
                p[i] = 1;
            }
        }
        text = $"0,0,0;{p[0]},{p[1]},{p[2]}";
        outStream.WriteLine(text);
        for(int i = 0; i < 6; i++)
        {
            text = ";;;;";
            outStream.WriteLine(text);
        }
        for(int i = 0; i < 38; i++)
        {
            text = "0";
            outStream.WriteLine(text);
        }
        outStream.Close();
        string fileName2 = "clear.csv";
        string path2 = Application.dataPath;
        path2 = path2.Substring(0, path2.LastIndexOf('/'));
        string filepath2 = Path.Combine(path2, "Assets", "Resources/");

        if (!Directory.Exists(filepath2))
        {
            Directory.CreateDirectory(filepath2);
        }
        int k = 0;
        using (StreamReader sr = new StreamReader(filepath2 + fileName2))
        {
            string source = sr.ReadLine();
            k = int.Parse(source);
        }
        StreamWriter outStream2 = new StreamWriter(filepath2 + fileName2);
        outStream2.WriteLine(k.ToString());
        outStream2.WriteLine("0");
        outStream2.Close();
        StartCoroutine(movescene());
    }
    IEnumerator movescene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
