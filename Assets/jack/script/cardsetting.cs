using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class cardsetting : MonoBehaviour
{
    data_manager data;
    int[] card;
    public GameObject Card;
    GameObject[] Cards;
    bool start;
    bool draw;
    bool m_third;
    bool d_third;
    public TMP_Text dealer;
    public TMP_Text me;
    public TMP_Text result_text;
    public EventTrigger trigger;
    int dealnum;
    int mynum;
    bool mA;
    bool dA;
    bool result;
    bool WAait;
    bool gameended;
    bool once;
    bool[] fliped;
    void Start()
    {
        //float seed = Random.Range(0f, 100f);
        //Random.InitState((int)seed);
        once = true;
        gameended = false;
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        WAait = false;
        result = false;
        mA = false;
        dA = false;
        dealnum = 0;
        mynum = 0;
        m_third = false;
        d_third = false;
        draw = false;
        start = false;
        card = new int[6];
        fliped = new bool[6];
        for(int i = 0; i < 6; i++)
        {
            fliped[i] = false;
        }
        bool yes = false;
        Cards = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            yes = false;
            card[i] = UnityEngine.Random.Range(0, 40);
            while (!yes)
            {
                yes = true;
                for (int j = 0; j < i; j++)
                {
                    if (card[i] == card[j])
                    {
                        card[i] = UnityEngine.Random.Range(0, 40);
                        yes = false;
                    }
                }
            }
            int wid = 0;
            switch (i)
            {
                case 5:
                case 3: wid = 5; break;
                case 4:
                case 2: wid = 2; break;
                case 1:
                case 0: wid = -1; break;
            }
            Cards[i] = Instantiate(Card, new Vector3(wid, (i < 4 && i != 0 ? 3 : -3), 0.01f), transform.rotation);//5 3 : 5    4 2 : 2   1 0 : -1
            Cards[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("tromp (2)")[card[i]];
        }
        StartCoroutine(carddraw());
        Cards[5].GetComponent<Animator>().SetInteger("i", 1);
        Cards[4].GetComponent<Animator>().SetInteger("i", 2);
        Cards[5].tag = "my";
        Cards[4].tag = "my";
        Cards[3].GetComponent<Animator>().SetInteger("you", 1);
        Cards[2].GetComponent<Animator>().SetInteger("you", 2);
        StartCoroutine(wait(3));
        if (card[3]%10 == 0 || card[2]%10==0)dA = true;
    }
    IEnumerator carddraw()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        if (Cards[5].transform.rotation.y == 0) fliped[5] = true;
        if (Cards[5].transform.rotation.y == 0) fliped[4] = true;
        if (!result) textload();
        if (start)
        {
            if (Cards[5].transform.rotation.y == 0 && Cards[4].transform.rotation.y == 0 && !draw)
            {
                GameObject.FindWithTag("canvas").transform.GetChild(4).gameObject.SetActive(true);
                trigger.enabled = true;
                draw = true;
            }
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!WAait)
            {
                if (Physics2D.Raycast(pos, Vector2.zero, 0f))
                {
                    once = true;
                    Cursor.SetCursor(Resources.Load<Texture2D>("hover"), Vector2.zero, CursorMode.Auto);
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                        if (draw && !m_third)
                        {
                            if (hit.transform.position.y == 0 && trigger.enabled)
                            {
                                StartCoroutine(carddraw());
                                m_third = true;
                                Cards[0].transform.GetComponent<Animator>().SetInteger("i", 3);
                                WAait = true;
                                data.elog.flip++;
                                StartCoroutine(wait(0));
                            }
                        }
                        if (hit.transform.CompareTag("my"))
                        {
                            if(hit.transform.gameObject == Cards[5])
                            {
                                if (!fliped[5]) data.elog.flip++;
                                fliped[5] = true;
                            }
                            if (hit.transform.gameObject == Cards[4])
                            {
                                if (!fliped[4]) data.elog.flip++;
                                fliped[4] = true;
                            }
                            hit.transform.GetComponent<Animator>().SetTrigger("flip");
                        }
                    }
                }
                else if (once)
                {
                    once = false;
                    Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
                }
            }
        }
        else if (Cards[5].transform.rotation.y == 0 && Cards[4].transform.rotation.y == 0)
        {
            start = !start;
            StartCoroutine(wait(2));
            if (((!dA && ((card[3] % 10 + 1) + (card[2] % 10 + 1)) < 17) || (dA && ((card[3] % 10 + 1) + (card[2] % 10 + 1) + 10) < 17))&&!d_third)
            {
                Debug.Log(!dA && ((card[3] % 10 + 1) + (card[2] % 10 + 1)) < 17);
                Debug.Log((dA && ((card[3] % 10 + 1) + (card[2] % 10 + 1) + 10) < 17));
                d_third = true;
                StartCoroutine(third_dealer());
            }
            if (!gameended) StartCoroutine(Judge());
        }
    }
    public void surren()
    {
        if (draw && !m_third && !WAait)
        {
            data.elog.cardquit++;
            GameObject.FindWithTag("canvas").transform.GetChild(4).GetComponent<EventTrigger>().enabled = false;
            data.multi = 0.5f;
            StartCoroutine(data.result());
            result_text.gameObject.SetActive(true);
            result_text.text = "Surrender";
            GetComponent<cardsetting>().enabled = false;
        }
    }
    IEnumerator third_dealer()
    {
        yield return new WaitForSeconds(6);
        StartCoroutine(carddraw());
        Cards[1].GetComponent<Animator>().SetInteger("you", 3);
        StartCoroutine(wait(1));
    }
    void textload()
    {
        dealnum = 0;
        mynum = 0;
        dealnum += isA(3, false) ? (card[3] % 10 + 1) : 0;
        dealnum += isA(2, false) ? (card[2] % 10 + 1) : 0;
        dealnum += (d_third && isA(1, false) ? card[1] % 10 + 1 : 0);
        dealer.text = dealnum.ToString();
        if (isA(3, true) || isA(2, true) || (d_third && isA(1, true)))
        {
            dealer.text += " or " + ((isA(3, false) ? (card[3] % 10 + 1) : 0) + (isA(2, false) ? (card[2] % 10 + 1) : 0) + ((d_third && isA(1, false) ? card[1] % 10 + 1 : 0)) + (dA ? 10 : 0)).ToString();
        }

        mynum += isA(5, false) ? (card[5] % 10 + 1) : 0;
        mynum += isA(4, false) ? (card[4] % 10 + 1) : 0;
        mynum += (m_third && isA(0, false) ? card[0] % 10 + 1 : 0);
        me.text = mynum.ToString();
        if (isA(5, true) || isA(4, true) || (m_third && isA(0, true)))
        {
            if (!mA) mA = true;
            me.text += " or " + ((isA(5, false) ? (card[5] % 10 + 1) : 0) + (isA(4, false) ? (card[4] % 10 + 1) : 0) + ((m_third && isA(0, false) ? card[0] % 10 + 1 : 0)) + (mA ? 10 : 0)).ToString();
        }
    }
    bool isA(int num, bool A)
    {
        if (Cards[num].transform.rotation.y == 0 && (card[num] % 10 == 0 || !A)) return true;
        else return false;
    }
    IEnumerator wait(int a)
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
        yield return new WaitForSeconds(4);
        Cards[a].GetComponent<Animator>().SetTrigger("flip");
        start = !start;
    }
    IEnumerator Judge()
    {
        gameended = true;
        yield return new WaitForSeconds(13);
        result = true;
        dealnum = 0;
        mynum = 0;
        dealnum += (card[3] % 10 + 1);
        dealnum += (card[2] % 10 + 1);
        dealnum += (d_third ? card[1] % 10 + 1 : 0);
        if (dA && dealnum <= 11)
        {
            dealnum += 10;
        }

        mynum += (card[5] % 10 + 1);
        mynum += (card[4] % 10 + 1);
        mynum += (m_third ? card[0] % 10 + 1 : 0);
        if (mA && mynum <= 11)
        {
            mynum += 10;
        }
        if (mynum == 21) data.elog.blackjack++;
        dealer.text = dealnum.ToString();
        me.text = mynum.ToString();
        result_text.gameObject.SetActive(true);
        if (dealnum == mynum)
        {
            data.elog.carddraw++;
            data.multi = 1;
            StartCoroutine(data.result());
            dealer.color = Color.gray;
            me.color = Color.gray;
            result_text.color = Color.black;
            result_text.text = "DRAW";
        }
        else if (mynum <= 21 && dealnum < mynum || dealnum > 21)
        {
            data.elog.cardwin++;
            data.multi = 2;
            StartCoroutine(data.result());
            dealer.color = Color.red;
            me.color = Color.green;
            result_text.color = Color.green;
            result_text.text = "WIN";
        }
        else
        {
            data.elog.cardlose++;
            data.multi = 0;
            StartCoroutine(data.result());
            dealer.color = Color.green;
            me.color = Color.red;
            result_text.color = Color.red;
            result_text.text = "LOSE";
        }
    }
    public void dealercard()
    {
        if (draw)
        {
            WAait = true;
            StartCoroutine(wait(2));
        }
    }
}
