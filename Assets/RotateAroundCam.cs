using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCam : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        float dX = Input.GetAxis("Horizontal");
        transform.RotateAround(_target.position, Vector3.down, dX * 50f * Time.deltaTime);
        transform.LookAt(_target);
    }
}
