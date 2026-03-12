using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    PlayerData PD;
    void Start()
    {
        PD = GameManager.Instance.PD;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!PD.Dark)
            {
                transform.GetChild(0).GetComponent<Enemy>().Target = collision.transform;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.GetChild(0).GetComponent<Enemy>().Target = null;
        }
    }
}
