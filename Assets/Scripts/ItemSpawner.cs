using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int Itemnumber;
    public void Load()
    {
        Itemnumber = Random.Range(0, 7);
        transform.GetChild(0).GetComponent<Interact>().enabled = true;
        transform.GetChild(0).GetComponent<Interact>().number = Itemnumber;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = GameManager.Instance.ItemImages[Itemnumber];
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void Start()
    {
        Load();
    }
}
