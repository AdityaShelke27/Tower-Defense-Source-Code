﻿using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;
    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}