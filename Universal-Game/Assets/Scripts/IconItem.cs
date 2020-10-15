using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconItem : MonoBehaviour
{
    public Image img;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        img.color = new Color(1, 1, 1, 0);
    }

    public void Change()
    {
        StartCoroutine(MarkEffect());
    }

    private IEnumerator MarkEffect()
    {
        float alpha = 0;
        Color color = img.color;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / duration;
            color.a = alpha;
            img.color = color;
            yield return null;
        }
    }
}
