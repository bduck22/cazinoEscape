using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coincount : MonoBehaviour
{
    public coin coin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "È½¼ö : " + coin.count.ToString("#,###");
    }
}
