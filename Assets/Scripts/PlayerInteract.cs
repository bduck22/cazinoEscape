using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerData PD;
    [SerializeField] GameObject E;
    void Start()
    {
        PD = GameManager.Instance.PD;
    }
    void Update()
    {
        if (PD.InteractOb)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PD.InteractOb.intaract();
            }
        }
        else E.SetActive(false);

        for(int i = 0; i < PD.Inventory.Count; i++)
        {
            if (Input.GetKeyDown((KeyCode)49+i))
            {
                PD.UseItem(i);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interact>())
        {
            if (collision.GetComponent<Interact>().enabled)
            {
                PD.InteractOb = collision.GetComponent<Interact>();
                E.transform.position = collision.transform.position + new Vector3(0, 1f, 0);
                E.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PD.InteractOb&&collision.GetComponent<Interact>())
        {
            E.SetActive(false);
            PD.InteractOb = null;
        }
    }
}
