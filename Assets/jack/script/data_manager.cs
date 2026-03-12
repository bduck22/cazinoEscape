using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public enum Act { Sleep, Wait, Play, Result, Bank }
public enum Map { hall, coin, ball, card, tree, money }
public class Money_log
{
    public int type;
    public int name;
    public int math_type;
    public float value;
    public int week;
    public int day;
    public int times;
    public Money_log(int type, int name, int math_type, float value, int week, int day, int times)
    {
        this.type = type;
        this.name = name;
        this.math_type = math_type;
        this.value = value;
        this.week = week;
        this.day = day;
        this.times = times;
    }
}
public class Ending_Log
{
    public float getmoney = 0;
    public float lostmoney = 0;
    public float adddept = 0;
    public float dept = 0;
    public float paydept = 0;//5
    public float week = 0;
    public float day = 0;
    public float ball1_5times = 0;
    public float ball1_2times = 0;
    public float ball1times = 0;//10
    public float ball0times = 0;
    public float ballquit = 0;
    public float coinmax = 0;
    public float coinwin = 0;
    public float coinlose = 0;//15
    public float flip = 0;
    public float cardwin = 0;
    public float cardquit = 0;
    public float cardlose = 0;
    public float carddraw = 0;//20
    public float blackjack = 0;
    public float paperget = 0;
    public float watchadd = 0;
    public float usestamina = 0;
    public float healstamina = 0;//25
    public float buygacha = 0;
    public float getgacha = 0;
    public float drink = 0;
    public float buydouble = 0;
    public float getdouble = 0;//30
    public float buyinsurance = 0;
    public float getinsurance = 0;
    public float buyhotel = 0;
    public float gobank = 0;
    public float manualopen = 0;
    public float manualmove = 0;//35
    public float resultclose = 0;
    public float manualclose = 0;//37
}
public class data_manager : MonoBehaviour
{
    public Queue log;
    public float money;
    public float stamina;
    public float max_stamina;
    public int day;
    public int week;
    public float multi;
    public float usemoney;
    public float dept;
    TMP_Text weekday;
    Image[] staminagage;
    public Map nowmap;
    public Act act;
    AudioSource audio;
    public int[] items;
    public int time;
    public float getmoney;
    store Store;

    public string[][] goodtext;
    public Ending_Log elog;
    public void infotext(int type, bool green)
    {
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(true);
        if (green)
        {
            transform.GetChild(5).GetComponent<Image>().color = new Color32(202, 255, 210, 200);
        }
        else
        {
            transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 202, 202, 200);
            transform.GetChild(5).GetComponent<AudioSource>().Play();
        }
        transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().color = new Color32(0, 0, 0, 255);
        switch (type)
        {
            case 0: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "금액을 설정해 주세요"; break;
            case 1: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "행동력이 부족합니다."; break;
            case 2: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "잔액이 부족합니다."; break;
            case 3: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "이미 판매된 물건입니다."; break;
            case 4: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "당첨 실패;;"; break;
            case 5: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "당첨 성공 1000만원획득!!"; break;
            case 6: transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "행동력 1 회복"; break;
        }
    }
    public IEnumerator Savedata()
    {
        yield return new WaitForSeconds(0f);
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
        using (StreamWriter outStream2 = new StreamWriter(filepath2 + fileName2))
        {
            outStream2.WriteLine($"{k}");
            outStream2.WriteLine("1");
            outStream2.Close();
        }

        string fileName = "Gamedata.csv";
        string path = Application.dataPath;
        path = path.Substring(0, path.LastIndexOf('/'));
        string filepath = Path.Combine(path, "Assets", "Resources/");


        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }

        StreamWriter outStream = new StreamWriter(filepath + fileName);
        string text = $"{money};{week};{day}";
        outStream.WriteLine(text);
        text = $"{stamina};{max_stamina};{(SceneManager.GetActiveScene().buildIndex)};{dept};{getmoney};{time}";
        outStream.WriteLine(text);
        text = $"{items[0]},{items[1]},{items[2]};{Store.windowitem[0]},{Store.windowitem[1]},{Store.windowitem[2]}";
        outStream.WriteLine(text);
        foreach (Money_log log in log)
        {
            text = $"{log.type};{log.name};{log.math_type};{log.value};{log.week},{log.day},{log.times}";
            outStream.WriteLine(text);
        }
        for (int i = 0; i < 6 - log.Count; i++)
        {
            text = ";;;;";
            outStream.WriteLine(text);
        }
        text = ((int)elog.getmoney).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.lostmoney).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.adddept).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.dept).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.paydept).ToString();//5
        outStream.WriteLine(text);
        text = ((int)elog.week).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.day).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.ball1_5times).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.ball1_2times).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.ball1times).ToString();//10
        outStream.WriteLine(text);
        text = ((int)elog.ball0times).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.ballquit).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.coinmax).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.coinwin).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.coinlose).ToString();//15
        outStream.WriteLine(text);
        text = ((int)elog.flip).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.cardwin).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.cardquit).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.cardlose).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.carddraw).ToString();//20
        outStream.WriteLine(text);
        text = ((int)elog.blackjack).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.paperget).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.watchadd).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.usestamina).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.healstamina).ToString();//25
        outStream.WriteLine(text);
        text = ((int)elog.buygacha).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.getgacha).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.drink).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.buydouble).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.getdouble).ToString();//30
        outStream.WriteLine(text);
        text = ((int)elog.buyinsurance).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.getinsurance).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.buyhotel).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.gobank).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.manualopen).ToString();//35
        outStream.WriteLine(text);
        text = ((int)elog.manualmove).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.resultclose).ToString();
        outStream.WriteLine(text);
        text = ((int)elog.manualclose).ToString();//38
        outStream.WriteLine(text);
        outStream.Close();
    }
    IEnumerator readdata()
    {
        //AssetDatabase.Refresh();
        yield return new WaitForSeconds(0);
        string fileName = "Gamedata.csv";
        string path = Application.dataPath;
        path = path.Substring(0, path.LastIndexOf('/'));
        string filepath = Path.Combine(path, "Assets", "Resources/", fileName);
        using (StreamReader sr = new StreamReader(filepath))
        {
            string source = sr.ReadLine();
            money = float.Parse(source.Split(';')[0]);
            week = int.Parse(source.Split(';')[1]);
            day = int.Parse(source.Split(';')[2]);

            source = sr.ReadLine();
            stamina = float.Parse(source.Split(';')[0]);
            max_stamina = float.Parse(source.Split(';')[1]);
            SceneManager.LoadScene(int.Parse(source.Split(';')[2]));
            dept = float.Parse(source.Split(';')[3]);
            getmoney = float.Parse(source.Split(';')[4]);
            time = int.Parse(source.Split(';')[5]);

            source = sr.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                items[i] = int.Parse(source.Split(';')[0].Split(',')[i]);
                Store.windowitem[i] = int.Parse(source.Split(';')[1].Split(',')[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                source = sr.ReadLine();
                if (int.TryParse(source.Split(';')[0], out int a))
                {
                    log.Enqueue(new Money_log(a, int.Parse(source.Split(';')[1]), int.Parse(source.Split(';')[2]), float.Parse(source.Split(';')[3]), int.Parse(source.Split(';')[4].Split(',')[0]), int.Parse(source.Split(';')[4].Split(',')[1]), int.Parse(source.Split(';')[4].Split(',')[2])));
                }
            }
            source = sr.ReadLine();
            elog.getmoney = int.Parse(source);
            source = sr.ReadLine();
            elog.lostmoney = int.Parse(source);
            source = sr.ReadLine();
            elog.adddept = int.Parse(source);
            source = sr.ReadLine();
            elog.dept = int.Parse(source);
            source = sr.ReadLine();
            elog.paydept = int.Parse(source);//5
            source = sr.ReadLine();
            elog.week = int.Parse(source);
            source = sr.ReadLine();
            elog.day = int.Parse(source);
            source = sr.ReadLine();
            elog.ball1_5times = int.Parse(source);
            source = sr.ReadLine();
            elog.ball1_2times = int.Parse(source);
            source = sr.ReadLine();
            elog.ball1times = int.Parse(source);//10
            source = sr.ReadLine();
            elog.ball0times = int.Parse(source);
            source = sr.ReadLine();
            elog.ballquit = int.Parse(source);
            source = sr.ReadLine();
            elog.coinmax = int.Parse(source);
            source = sr.ReadLine();
            elog.coinwin = int.Parse(source);
            source = sr.ReadLine();
            elog.coinlose = int.Parse(source);//15
            source = sr.ReadLine();
            elog.flip = int.Parse(source);
            source = sr.ReadLine();
            elog.cardwin = int.Parse(source);
            source = sr.ReadLine();
            elog.cardquit = int.Parse(source);
            source = sr.ReadLine();
            elog.cardlose = int.Parse(source);
            source = sr.ReadLine();
            elog.carddraw = int.Parse(source);//20
            source = sr.ReadLine();
            elog.blackjack = int.Parse(source);
            source = sr.ReadLine();
            elog.paperget = int.Parse(source);
            source = sr.ReadLine();
            elog.watchadd = int.Parse(source);
            source = sr.ReadLine();
            elog.usestamina = int.Parse(source);
            source = sr.ReadLine();
            elog.healstamina = int.Parse(source);//25
            source = sr.ReadLine();
            elog.buygacha = int.Parse(source);
            source = sr.ReadLine();
            elog.getgacha = int.Parse(source);
            source = sr.ReadLine();
            elog.drink = int.Parse(source);
            source = sr.ReadLine();
            elog.buydouble = int.Parse(source);
            source = sr.ReadLine();
            elog.getdouble = int.Parse(source);//30
            source = sr.ReadLine();
            elog.buyinsurance = int.Parse(source);
            source = sr.ReadLine();
            elog.getinsurance = int.Parse(source);
            source = sr.ReadLine();
            elog.buyhotel = int.Parse(source);
            source = sr.ReadLine();
            elog.gobank = int.Parse(source);
            source = sr.ReadLine();
            elog.manualopen = int.Parse(source);//35
            source = sr.ReadLine();
            elog.manualmove = int.Parse(source);
            source = sr.ReadLine();
            elog.resultclose = int.Parse(source);
            source = sr.ReadLine();
            elog.manualclose = int.Parse(source);//38
            for (int i = 1; i <= 3; i++)
            {
                Store.transform.GetChild(i).GetChild(0).GetComponent<Image>().color = Color.yellow;
            }
        }
    }
    void Start()
    {
        Store = transform.GetChild(0).GetChild(4).GetComponent<store>();
        goodtext = new string[49][];
        TextAsset sourcefile = Resources.Load<TextAsset>("goodtext");
        int l = 0;
        using (StringReader sr = new StringReader(sourcefile.text))
        {
            string source = sr.ReadLine();
            while (source != null)
            {
                goodtext[l] = new string[2];
                goodtext[l][0] = source.Split(';')[0];
                goodtext[l][1] = source.Split(';')[1];
                l++;
                source = sr.ReadLine();
            }
        }
        elog = new Ending_Log();
        log = new Queue();
        items = new int[3];
        audio = GetComponent<AudioSource>();
        staminagage = new Image[3];
        if (GameObject.FindWithTag("save") != gameObject)
        {
            Destroy(gameObject);
        }
        else DontDestroyOnLoad(gameObject);
        act = Act.Wait;
        multi = 0;
        usemoney = 0;
        weekday = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        for (int i = 0; i < 3; i++)
        {
            staminagage[i] = transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>();
        }
        StartCoroutine(readdata());
    }
    void OnApplicationQuit()
    {
        StartCoroutine(Savedata());
    }
    void Load()
    {
        for (int i = 0; log.Count > 6; i++)
        {
            log.Dequeue();
        }
        if (act == Act.Bank && nowmap != Map.money)
        {
            if (audio.volume != 0) audio.volume = 0f;
        }
        else if (audio.volume != 1 && nowmap != Map.money) audio.volume = 1f;
        if (nowmap != (Map)(SceneManager.GetActiveScene().buildIndex - 1))
        {
            if ((Map)(SceneManager.GetActiveScene().buildIndex - 1) == Map.money)
            {
                if (audio.volume != 0) audio.volume = 0f;
            }
            else if ((Map)(SceneManager.GetActiveScene().buildIndex - 1) == Map.tree)
            {
                audio.resource = Resources.Load<AudioResource>("media1");
                audio.Play();
                if (audio.volume != 1) audio.volume = 1f;
            }
            else if (nowmap == Map.money || nowmap == Map.tree)
            {
                audio.resource = Resources.Load<AudioResource>("media0");
                audio.Play();
                if (audio.volume != 1) audio.volume = 1f;
            }
            StartCoroutine(Savedata());
        }
        nowmap = (Map)(SceneManager.GetActiveScene().buildIndex - 1);
        weekday.text = week.ToString("#,###") + "주차\n" + day.ToString() + "일차";
        staminagage[0].fillAmount = stamina / 5;
        if (items[2] > 0)
        {
            staminagage[1].fillAmount = (stamina - 5) / 5;
            staminagage[2].fillAmount = (stamina - 10) / 5;
        }
        //moneytext.text = "돈 : " + money.ToString("#,###");
    }
    void Update()
    {
        if (dept == 0 && money >= 100000000)
        {
            if (!transform.GetChild(6).gameObject.activeSelf) transform.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            if (transform.GetChild(6).gameObject.activeSelf) transform.GetChild(6).gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            transform.GetChild(4).gameObject.SetActive(!transform.GetChild(4).gameObject.activeSelf);
            if (transform.GetChild(4).gameObject.activeSelf)
            {
                elog.manualopen++;
            }
            else elog.manualclose++;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            transform.GetChild(2).gameObject.SetActive(!transform.GetChild(2).gameObject.activeSelf);
            if (!transform.GetChild(2).gameObject.activeSelf)
            {
                elog.resultclose++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab) && (act == Act.Wait || act == Act.Bank))
        {
            transform.GetChild(3).gameObject.SetActive(!transform.GetChild(3).gameObject.activeSelf);
            if (transform.GetChild(3).gameObject.activeSelf)
            {
                elog.gobank++;
                act = Act.Bank;
            }
            else act = Act.Wait;
        }
        Load();
    }
    public IEnumerator result()
    {
        act = Act.Result;
        transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = "";
        transform.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text = "";
        transform.GetChild(2).GetChild(4).GetComponent<TMP_Text>().text = "";
        transform.GetChild(2).GetChild(5).GetComponent<TMP_Text>().text = "";
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).GetComponent<AudioSource>().resource = Resources.Load<AudioResource>("result1");
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.16f);
        transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = "배팅 금액 : " + usemoney.ToString("###,0") + "원";
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.16f);
        transform.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text = "배율 : " + multi.ToString("0.0") + "배";
        if (multi > 1 && items[0] > 0)
        {
            elog.getdouble++;
            items[0]--;
            transform.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text += $"(더블 * {multi.ToString("0.0")})";
            multi *= multi;
        }
        if (multi == 0 && items[1] > 0)
        {
            elog.getinsurance++;
            items[1]--;
            transform.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text += "(보험 + 0.5)";
            multi = 0.5f;
        }
        yield return new WaitForSeconds(1);
        transform.GetChild(2).GetComponent<AudioSource>().resource = Resources.Load<AudioResource>("result2");
        transform.GetChild(2).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.7f);
        transform.GetChild(2).GetChild(4).GetComponent<TMP_Text>().text = "\r\n                결과 : " + (usemoney * multi).ToString("###,0") + "원";
        money += usemoney * multi;
        transform.GetChild(2).GetChild(5).GetComponent<TMP_Text>().text = "잔액 : " + money.ToString("###,0") + "원";
        log.Enqueue(new Money_log(1, SceneManager.GetActiveScene().buildIndex - 2, multi > 1 ? 2 : 1, usemoney * (multi == 0 ? 1 : multi) - (multi > 1 ? usemoney : 0), week, day, time));
        if (multi > 1)
        {
            elog.getmoney += usemoney * multi - usemoney;
        }
        else if (multi == 0.5f)
        {
            elog.lostmoney += usemoney * multi;
        }
        else if (multi == 0)
        {
            elog.lostmoney += usemoney;
        }
        yield return new WaitForSeconds(1);
        time++;
        act = Act.Wait;
        StartCoroutine(Savedata());
    }
    public void dayup()
    {
        act = Act.Wait;
        if (dept == 0 && money >= 100000000)
        {
            act = Act.Sleep;
            Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
            elog.day = (week - 1) * 7 + day;
            elog.week = week - 1;
            GetComponent<Canvas>().enabled = false;
            GetComponent<AudioSource>().enabled = false;
            Debug.Log("aa");
            SceneManager.LoadScene(7);
            string fileName2 = "clear.csv";
            string path2 = Application.dataPath;
            path2 = path2.Substring(0, path2.LastIndexOf('/'));
            string filepath2 = Path.Combine(path2, "Assets", "Resources/");

            if (!Directory.Exists(filepath2))
            {
                Directory.CreateDirectory(filepath2);
            }
            StreamWriter outStream2 = new StreamWriter(filepath2 + fileName2);
            outStream2.WriteLine("1");
            outStream2.WriteLine("0");
            outStream2.Close();
        }
        else
        {
            time = 1;
            dept += dept * 0.025f;
            elog.adddept += dept * 0.025f;
            getmoney = 2000000;
            if (max_stamina == 15)
            {
                items[2]--;
            }
            if (++day >= 7)
            {
                day = 1;
                week++;
            }
            transform.GetChild(0).GetChild(4).GetComponent<store>().Rotation();
            if (items[2] > 0)
            {
                if (max_stamina == 5)
                {
                    max_stamina = 15;
                    transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(0).GetChild(2).GetChild(2).gameObject.SetActive(true);
                }
            }
            else
            {
                max_stamina = 5;
                transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(2).GetChild(2).gameObject.SetActive(false);
            }
            elog.healstamina += max_stamina - stamina;
            stamina = max_stamina;
            Load();
            StartCoroutine(Savedata());
        }
    }
    public bool energyup()
    {
        if (++stamina > max_stamina)
        {
            stamina--;
            Load();
            return false;
        }
        else
        {
            Load();
            return true;
        }
    }
    public bool energydown()
    {
        if (--stamina < 0)
        {
            stamina++;
            Load();
            return false;
        }
        else
        {
            elog.usestamina++;
            Load();
            return true;
        }
    }
}
