using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Hp;
    SpriteRenderer sprite;
    [SerializeField] bool Follow;
    public Transform Target;
    [SerializeField] float Speed;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();  
    }
    void Update()
    {
        if (Follow)
        {
            if (Target)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, transform.parent.transform.position, Speed*Time.deltaTime);
            }
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            Hp--;
            StartCoroutine(Hit());
        }
    }
    IEnumerator Hit()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
        }
        sprite.color = Color.white;
    }
}
