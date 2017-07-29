using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour {

    private const float miniDelay = 0.0005f;
    private const float speed = 4f;
    private const float proximity = 0.05f;
    private const float followSpeed = 0.02f;

    public void TranslateAToB(Transform ObjectToAnimate, Vector3 a, Vector3 b)
    {
        StartCoroutine(StartTranslating(ObjectToAnimate, a, b));
    }

    public void TranslateAToBWithHelpers(Transform ObjectToAnimate, Transform A, Transform B)
    {
        Vector3 a = A.position;
        Vector3 b = B.position;
        StartCoroutine(StartTranslating(ObjectToAnimate, a, b));
    }

    public void FollowB(Transform ObjectToAnimate, Transform B)
    {
        StartCoroutine(StartFollowing(ObjectToAnimate, B));
    }

    IEnumerator StartTranslating(Transform ObjectToAnimate, Vector3 a, Vector3 b)
    {
        float distCovered, fracJourney = 0, journeyLength = Vector3.Distance(a, b);
        float startTime = Time.time;
        while (fracJourney < 1f)
        {
            distCovered = (Time.time - startTime) * speed;
            fracJourney = distCovered / journeyLength;
            ObjectToAnimate.position = Vector3.Lerp(a, b, fracJourney);
            Debug.Log("fracJourney : " + fracJourney);
            yield return new WaitForSecondsRealtime(miniDelay);
        }
        Debug.Log("xfracJourney : " + fracJourney);
        yield return null;

    }

    IEnumerator StartFollowing(Transform ObjectToAnimate, Transform B)
    {
        float distCovered, fracJourney = 0, journeyLength, startTime = Time.time;
        Vector3 a, b;
        a = ObjectToAnimate.position;
        b = B.position;
       // while (b.x - a.x >= proximity)
        //{
        while (fracJourney < 1f)
        {
            a = ObjectToAnimate.position;
            b = B.position;
            journeyLength = Vector3.Distance(a, b);
            distCovered = (Time.time - startTime) * followSpeed;
            fracJourney = distCovered / journeyLength;
            ObjectToAnimate.position = Vector3.Lerp(a, b, fracJourney);
           // ObjectToAnimate.position += (b - a) * 0.005f;
            Debug.Log("fracJourney : " + fracJourney);
            yield return new WaitForSecondsRealtime(miniDelay);
        }
        Debug.Log("xfracJourney : " + fracJourney);
        yield return null;

    }
}
