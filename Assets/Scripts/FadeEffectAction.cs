using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FadeEffect))]
public class FadeEffectAction : MonoBehaviour {

    public GameObject Cube;

	// Use this for initialization
	void Start () {
        Invoke("StartFade", 1f);
        Invoke("MakeVisible", 4f);
    }
	
	// Update is called once per frame
	void StartFade () {
        gameObject.GetComponent<FadeEffect>().FadeOut(Cube);
    }

    void MakeVisible()
    {
        gameObject.GetComponent<FadeEffect>().MakeVisible(Cube);
    }
}
