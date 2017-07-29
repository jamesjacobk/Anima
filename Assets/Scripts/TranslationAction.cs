using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationAction : MonoBehaviour {

    public Transform Cube;
    public Transform A;
    public Transform B;
    Vector3 a = new Vector3(-5f, 0, 0);
    Vector3 b = new Vector3(5f, 0, 0);

    // Use this for initialization
    void Start () {
        
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSecondsRealtime(2f);
        gameObject.GetComponent<Translation>().FollowB(Cube, B);
    }

}
