using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public Transform Box;
    public Transform Chest;
    public bool on;
    void Start()
    {
        on = false;
    }
    void Update()
    {
        if (on)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            Chest.gameObject.SetActive(true);
            enabled = false;
        }else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Chest.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform == Box)
        {
            on = true;
        }
    }
}
