using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class power : MonoBehaviour
{
    Rigidbody2D ob;
    public Image Gage;
    public GameObject spring;
    bool trigger;
    bool shootcheck;
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        shootcheck = true;
        trigger = true;
    }
    void shoot(float power)
    {
        spring.GetComponent<BoxCollider2D>().enabled = false;
        spring.GetComponent<Animator>().enabled = true;
        ob = GetComponent<Rigidbody2D>();
        ob.AddForce(Vector3.up * power);
    }
    void Update()
    {
        if (shootcheck)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (trigger)
                {
                    if (Gage.fillAmount >= 1) trigger = false;
                    Gage.fillAmount += 1.2f * Time.deltaTime;
                }
                else
                {
                    if (Gage.fillAmount <= 0) trigger = true;
                    Gage.fillAmount -= 1.2f * Time.deltaTime;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                GetComponent<AudioSource>().enabled = true;
                GetComponent<AudioSource>().Play();
                shootcheck = false;
                shoot(Gage.fillAmount * 350 + 150);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q)&&GetComponent<Rigidbody2D>())
            {
                Destroy(GetComponent<Rigidbody2D>());
                data.multi = 0;
                data.elog.ballquit++;
                StartCoroutine(data.result());
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "goal")
        {
            transform.GetComponent<CircleCollider2D>().sharedMaterial = null;
            data.multi = float.Parse(collision.transform.name);
            switch (float.Parse(collision.transform.name))
            {
                case 0:data.elog.ball0times++; break;
                case 1: data.elog.ball1times++; break;
                case 1.2f: data.elog.ball1_2times++; break;
                case 1.5f: data.elog.ball1_5times++; break;
            }
            StartCoroutine(data.result());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
