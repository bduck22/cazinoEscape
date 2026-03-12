using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(Fade());
    }
    void Update()
    {
        
    }
    IEnumerator Fade()
    {
        float p = 1;
        yield return new WaitForSeconds(0.2f);
        Color color = image.color;
        while (color.a > 0)
        {
            yield return new WaitForSeconds(0.02f);
            color.a = p;
            p -= 0.05f;
            image.color = color;
        }
        Destroy(gameObject);
    }
}
