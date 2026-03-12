using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingscroll : MonoBehaviour
{
    bool stop;
    void Start()
    {
        stop = true;
        StartCoroutine(stopmove());
    }

    void Update()
    {
        if(transform.position.y <= -100.5f)
        {
            transform.position = new Vector2(0, -100.5f);
            stop = false;
        }
        if (stop)
        {
            transform.Translate(0, -1.5f * Time.deltaTime, 0);
        }
    }
    IEnumerator stopmove()
    {
        yield return new WaitForSeconds(9.3f);
        stop = false;
        yield return new WaitForSeconds(1.2f);
        stop = true;
        yield return new WaitForSeconds(3.5f);
        stop = false;
        yield return new WaitForSeconds(1);
        stop = true;
        yield return new WaitForSeconds(3f);
        stop = false;
        yield return new WaitForSeconds(0.9f);
        stop = true;
        yield return new WaitForSeconds(8.4f);
        stop = false;
        yield return new WaitForSeconds(0.7f);
        stop = true;
        yield return new WaitForSeconds(0.1f);
        stop = false;
        yield return new WaitForSeconds(0.7f);
        stop = true;
        yield return new WaitForSeconds(16.1f);
        stop = false;
        yield return new WaitForSeconds(0.55f);
        stop = true;
        yield return new WaitForSeconds(0.12f);
        stop = false;
        yield return new WaitForSeconds(0.7f);
        stop = true;
        yield return new WaitForSeconds(0.23f);
        stop = false;
        yield return new WaitForSeconds(1f);
        stop = true;
        yield return new WaitForSeconds(0.9f);
        stop = false;
        yield return new WaitForSeconds(0.9f);
        stop = true;
        yield return new WaitForSeconds(5.9f);
        stop = false;
        yield return new WaitForSeconds(0.8f);
        stop = true;
        yield return new WaitForSeconds(1.5f);
        stop = false;
        yield return new WaitForSeconds(0.59f);
        stop = true;
        yield return new WaitForSeconds(0.13f);
        stop = false;
        yield return new WaitForSeconds(0.47f);
        stop = true;
        yield return new WaitForSeconds(0.09f);
        stop = false;
        yield return new WaitForSeconds(0.5f);
        stop = true;
        yield return new WaitForSeconds(3.5f);
        stop = false;
        yield return new WaitForSeconds(0.5f);
        stop = true;
        yield return new WaitForSeconds(3.9f);
        stop = false;
        yield return new WaitForSeconds(2.6f);
        stop = true;
        yield return new WaitForSeconds(15f);
        Application.Quit();
    }
}
