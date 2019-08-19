using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeTransform : MonoBehaviour
{

    RectTransform rectTransform;
    float t;
    Vector2 startSize;
    Vector2 target;
    float timeToReachTarget;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startSize = target = rectTransform.sizeDelta;

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        float width = Mathf.Lerp(startSize.x, target.x, t);
        float height = Mathf.Lerp(startSize.y, target.y, t);
        rectTransform.sizeDelta = new Vector2(width, height);
    }

    public void SetDestination(Vector2 endSize, float time)
    {
        t = 0;
        startSize = rectTransform.sizeDelta;
        timeToReachTarget = time;
        target = endSize;
    }

}
