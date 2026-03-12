using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Circle")
        {
            transform.GetComponent<PolygonCollider2D>().isTrigger = false;
            transform.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
