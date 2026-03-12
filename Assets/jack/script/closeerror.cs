using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class closeerror : MonoBehaviour
{
    byte aa;
    void OnEnable()
    {
        aa = 200;
        StartCoroutine(close());
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(1.5f);
        while (transform.GetComponent<Image>().color.a > 0)
        {
            yield return new WaitForSeconds(0.01f);
            Color color = transform.GetComponent<Image>().color;
            color.a = aa;
            aa -=5;
            transform.GetComponent<Image>().color = color;
            transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(0, 0, 0, aa);
        }
        gameObject.SetActive(false);
    }
}
