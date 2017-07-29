using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour {

    private const float microDelay = 0.005f;
    private const float fadeAmount = 0.05f;

    public void FadeOut(GameObject target)
    {
        SetMaterialProperties(target);
        StartCoroutine(StartFading(target));
    }

    public void MakeVisible(GameObject target)
    {
        StartCoroutine(StartMakingVisible(target));
    }

    private void SetMaterialProperties(GameObject target)
    {
        target.GetComponent<Renderer>().material.SetFloat("_Mode", 3);
        target.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        target.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        target.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
    }

    IEnumerator StartFading(GameObject target)
    {
        Color temp = target.GetComponent<Renderer>().material.color;
        while(temp.a > 0)
        {
            temp.a -= fadeAmount;
            target.GetComponent<Renderer>().material.color = temp;
            yield return new WaitForSecondsRealtime(microDelay);
        }
    }

    IEnumerator StartMakingVisible(GameObject target)
    {
        Color temp = target.GetComponent<Renderer>().material.color;
        while (temp.a < 1)
        {
            temp.a += fadeAmount;
            target.GetComponent<Renderer>().material.color = temp;
            yield return new WaitForSecondsRealtime(microDelay);
        }
    }
}
