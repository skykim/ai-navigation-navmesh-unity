using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveSphere : MonoBehaviour
{
    private Vector3 _centerPosition;
    private const float Radius = 2.0f;

    private void Start()
    {
        _centerPosition = this.transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(Radius * Mathf.Cos(Time.time) + _centerPosition.x, _centerPosition.y, Radius * Mathf.Sin(Time.time) + _centerPosition.z);
    }
}
