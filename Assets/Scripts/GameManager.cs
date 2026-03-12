using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float time;
    public static GameManager Instance;
    public PlayerData PD;
    public Transform Setting;
    public bool FREE;
    public bool End;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadTime();
        if (SType.Instance.New)
        {
            DataInit();
        }
    }
    public int Stage;

    public Sprite[] ItemImages;
    public int[] ItemPrice;
    public int[] ItemWeight;

    public Transform[] Stage1;
    public Transform[] Stage2;
    public Transform[] Stage3;
    public Transform[] Stage4;
    public Transform[] Stage5;


    public Transform[] ItemSpawners;

    public float[] data;
    public float[] data2;
    public void LoadTime()
    {
        string rank = PlayerPrefs.GetString("Rank");
        string[] r = rank.Split("\n");
        for (int i = 0; i < r.Length - 1; i++)
        {
            data[i] = float.Parse(r[i]);
        }
        
        for(int i = 0; i < data.Length; i++)
        {
            
        }
        //PlayerPrefs.SetString("Rank", time.ToString("0.##\n"));

    }
    public void Init()
    {
        StartCoroutine(Load());
        Stage = 1;
        Setting.gameObject.SetActive(false);
        foreach (Transform t in ItemSpawners)
        {
            t.GetComponent<ItemSpawner>().Load();
        }
    }
    public void Exit()
    {
        for (int i = 0; PD.Inventory.Count > 0;)
        {
            if (PD.Inventory[i] > 6)
            {
                Money += ItemPrice[PD.Inventory[i]];

            }
            PD.Inventory.RemoveAt(i);
        }
        PD.PlayerInit();
        Save();
    }

    public int BagLevel;
    public int AirLevel;

    public int Money;
    private void Update()
    {
        if (!End)
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                FREE = !FREE;
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                PD.MoveStage(true);
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                Stage -= 2;
                PD.MoveStage(true);
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            }
            time += Time.deltaTime;
        }
    }

    public void Save()
    {
        /* 가방레벨
         * 산소레벨
         * 돈
         * 시간
         * 인
         * 벤
         * 토
         * 리
         * 공
         * 간
         * 임
         * ㅇ
         */
        string player = "";
        player += BagLevel + "\n";
        player += AirLevel + "\n";
        player += Money + "\n";
        player += time + "\n";
        for (int i = 0; i < PD.Inventory.Count; i++)
        {
            player += PD.Inventory[i] + "\n";
        }
        PlayerPrefs.SetString("Player", player);

        string stage1 = "";
        /* 레버
         * 상자
         * 상자
         * 상자
         * 상자
         */
        for (int i = 0; i < Stage1.Length; i++)
        {
            if (Stage1[i].GetComponent<Animator>())
            {
                stage1 += (Stage1[i].GetComponent<Interact>().enabled ? 0 : 1) + "\n";
            }
            else
            {
                stage1 += (Stage1[i].gameObject.activeSelf ? 1 : 0) + "\n";
            }
        }
        PlayerPrefs.SetString("Stage1", stage1);

        string stage2 = "";
        for(int i = 0; i < Stage2.Length; i++)
        {
            if (Stage2[i].GetComponent<Animator>())
            {
                stage2 += (Stage2[i].GetComponent<Interact>().enabled ? 0 : 1) + "\n";
            }
            else
            {
                stage2 += (Stage2[i].gameObject.activeSelf ? 1 : 0) + "\n";
            }
        }
        PlayerPrefs.SetString("Stage2", stage2);

        string stage3 = "";
        for (int i = 0; i < Stage3.Length; i++)
        {
            if (Stage3[i].GetComponent<BoxMove>())
            {
                stage3 += (Stage3[i].GetComponent<BoxMove>().on ? 1 : 0) + "\n";
            }
            else
            {
                stage3 += (Stage3[i].gameObject.activeSelf ? 1 : 0) + "\n";
            }
        }
        PlayerPrefs.SetString("Stage3", stage3);
    }
    public IEnumerator Load()
    {
        yield return new WaitForSeconds(0.05f);
        PD.Inventory.Clear();
        string player = PlayerPrefs.GetString("Player");
        string[] p = player.Split("\n");
        BagLevel = int.Parse(p[0]);
        AirLevel = int.Parse(p[1]);
        PD.maxAir = AirLevel * 100;
        PD.maxWeight = 150 * (BagLevel - 1) + 100;
        PD.InvenSize = 2 + BagLevel * 2;
        Money = int.Parse(p[2]);
        time = float.Parse(p[3]);
        for (int i = 4; i < p.Length - 1; i++)
        {
            PD.Inventory.Add(int.Parse(p[i]));
        }
        PD.PlayerInit();
        //플레이어 불러오기

        string stage1 = PlayerPrefs.GetString("Stage1");
        string[] s1 = stage1.Split("\n");
        if (s1[0] == "1")
        {
            Stage1[0].GetComponent<Interact>().intaract();
        }
        else
        {
            Stage1[0].GetComponent<Interact>().back();
        }
        for (int i = 1; i < 5; i++)
        {
            Stage1[i].gameObject.SetActive(s1[i] == "1");
            Stage1[i].GetComponent<Interact>().enabled = true;
        }

        string stage2 = PlayerPrefs.GetString("Stage2");
        string[] s2 = stage2.Split("\n");
        for(int i = 0; i < 3; i++)
        {
            if (s2[i] == "1")
            {
                Stage2[i].GetComponent<Interact>().intaract();
            }
            else
            {
                Stage2[i].GetComponent<Interact>().back();
            }
        }
        for (int i = 3; i < 7; i++)
        {
            Stage2[i].gameObject.SetActive(s2[i] == "1");
            Stage2[i].GetComponent<Interact>().enabled = true;
        }

        string stage3 = PlayerPrefs.GetString("Stage3");
        string[] s3 = stage3.Split("\n");
        if (s3[0] == "1")
        {
            Stage3[0].GetComponent<BoxMove>().on = true;
            Stage3[0].GetComponent<BoxMove>().Box.transform.position = Stage3[0].position;
        }
        else
        {
            Stage3[0].GetComponent<BoxMove>().Box.GetComponent<BoxD>().back();
            Stage3[0].GetComponent<BoxMove>().on = false;
            Stage3[0].GetComponent<BoxMove>().enabled = true;
        }
        for (int i = 1; i < 5; i++)
        {
            Stage3[i].gameObject.SetActive(s2[i] == "1");
            Stage3[i].GetComponent<Interact>().enabled = true;
        }
    }

    public void DataInit()
    {
        string player = "";
        player += 1 + "\n";
        player += 1 + "\n";
        player += 0 + "\n";
        player += 0 + "\n";
        string stage1 = "";
        stage1 += "0\n";
        for (int i = 1; i < 5; i++)
        {
            stage1 += "1\n";
        }
        string stage2 = "";
        stage2 += "0\n0\n0\n";
        for (int i = 3; i < 7; i++)
        {
            stage2 += "1\n";
        }
        string stage3 = "";
        stage3 += "0\n";
        for (int i = 1; i < 5; i++)
        {
            stage3 += "1\n";
        }
        PlayerPrefs.SetString("Stage1", stage1);
        PlayerPrefs.SetString("Stage2", stage2);
        PlayerPrefs.SetString("Stage3", stage3);
        PlayerPrefs.SetString("Player", player);
        Init();
    }
}
