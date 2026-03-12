using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    [SerializeField] Transform Store;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Store.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            GameManager.Instance.Exit();
            GameManager.Instance.PD.NotDie = true;
        }
    }
}
