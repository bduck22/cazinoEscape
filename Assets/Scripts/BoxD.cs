using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxD : MonoBehaviour
{
    Vector2 Position;
    void Start()
    {
        Position = transform.position;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            back();
        }
    }
    public void back()
    {
        transform.position = Position;
    }
}
