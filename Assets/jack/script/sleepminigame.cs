using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class sleepminigame : MonoBehaviour
{
    int collect;
    TMP_Text collected;
    public GameObject[] old_paper;
    bool once;
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        once = true;
        UnityEngine.Random.InitState((int)(DateTime.Now.Ticks));
        collected = transform.GetChild(0).GetComponent<TMP_Text>();
        collect = 0;
        for (int i=0;i< 5; i++)
        {
            int type = UnityEngine.Random.Range(0, 5);
            float x = UnityEngine.Random.Range(-5.5f, 5.51f);
            float y = UnityEngine.Random.Range(-4, 4f);
            Instantiate(old_paper[type]).transform.position = new Vector3(x, y, i);
        }
    }
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Physics2D.Raycast(pos, Vector2.zero, 0f))
        {
            once = true;
            Cursor.SetCursor(Resources.Load<Texture2D>("hover"), Vector2.zero, CursorMode.Auto);
            if (Input.GetMouseButtonDown(0))
            {
                data.elog.paperget++;
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                collect++;
                StartCoroutine(collectani(hit.transform));
            }
        }
        else if(once)
        {
            once = false;
            Cursor.SetCursor(Resources.Load<Texture2D>("origi"), Vector2.zero, CursorMode.Auto);
        }
    }
    IEnumerator collectani(Transform ob)
    {
        if (ob.GetComponent<PolygonCollider2D>() || ob.GetComponent<BoxCollider2D>())
        {
            if (ob.GetComponent<PolygonCollider2D>()) ob.GetComponent<PolygonCollider2D>().enabled = false;
            else ob.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
            ob.localScale = new Vector2(0.9f, 0.9f);
            yield return new WaitForSeconds(0.1f);
            ob.localScale = new Vector2(1.1f, 1.1f);
            yield return new WaitForSeconds(0.1f);
            collected.text = $"¸ðÀº ÆóÁö {collect} / 5";
            Destroy(ob.gameObject);
            if (collect == 5)
            {
                yield return new WaitForSeconds(0.2f);
                transform.GetChild(1).gameObject.SetActive(true);

                Destroy(transform.GetComponent<sleepminigame>());
            }
        }
    }
}
