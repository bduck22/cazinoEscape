using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    PlayerData PD;
    [SerializeField] int Damage;
    void Start()
    {
        PD = GameManager.Instance.PD;
    }
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PD.Hit(Damage);
        }
    }
}
