﻿using UnityEngine;
using System.Collections;

public class VercitalBulletMover : MonoBehaviour {

    [SerializeField]
    float verticalSpped = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, verticalSpped * Time.deltaTime, 0);

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y <= 0)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
