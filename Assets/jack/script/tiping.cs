using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tiping : MonoBehaviour
{
    TMP_Text text;
    public float cool;
    public string Text;
    public string startText;
    public float startcool;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(Tiping());
    }
    IEnumerator Tiping()
    {
        text.text = startText;
        yield return new WaitForSeconds(startcool);
        foreach(char c in Text)
        {
            text.text += c;
            yield return new WaitForSeconds(cool);
        }
    }
}
