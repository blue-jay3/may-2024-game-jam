using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class colliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] lightPoints= GetComponent<Light2D>().shapePath;
        Vector2[] points = new Vector2[lightPoints.Length];
        for(int i = 0; i < lightPoints.Length; i++)
        {
            points[i] = new Vector2(lightPoints[i].x, lightPoints[i].y);
        }
        GetComponent<PolygonCollider2D>().points = points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
