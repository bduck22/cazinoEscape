using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadeOut : MonoBehaviour
{
    Image image;
    bool fade;
    private void OnEnable()
    {
        image = GetComponent<Image>();
        fade = false;
        image.color = Color.red + Color.blue * 0.5f + Color.green * 0.5f;
        StartCoroutine(Pade());
    }
    void Update()
    {
        if (fade)
        {
            image.color -= Color.black * Time.deltaTime;
            if (image.color.a <= 0) gameObject.SetActive(false);
        }
    }
    IEnumerator Pade()
    {
        yield return new WaitForSeconds(0.3f);
        fade = true;
    }
}
