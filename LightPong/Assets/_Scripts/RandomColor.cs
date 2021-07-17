using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{

    public Image BackGround;
    public bool IsEnable;

    private void Start()
    {
        randomColor(BackGround);
    }

    public void randomColor(Image i)
    {
        StartCoroutine(COR_RandomColor(i));
    }

    IEnumerator COR_RandomColor(Image i)
    {
        while (IsEnable)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            i.color= Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
