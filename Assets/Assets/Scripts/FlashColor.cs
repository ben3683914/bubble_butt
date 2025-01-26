using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public Color flashColor = Color.red;
    public Color resetColor = Color.white;
    public float flashDuration = 0.1f;
    public List<SpriteRenderer> sprites;

    public void Do()
    {
        StartCoroutine(Flash());
    }

    void SetColors(Color color)
    {
        foreach(var sprite in sprites)
        {
            sprite.color = color;
        }
    }

    IEnumerator Flash()
    {
        SetColors(flashColor);
        yield return new WaitForSeconds(flashDuration);
        SetColors(resetColor);
        yield return null;
    }

}
