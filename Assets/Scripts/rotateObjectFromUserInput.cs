﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObjectFromUserInput : MonoBehaviour
{
    public float angle;


    private void OnMouseDrag()
    {
        float x= Input.GetAxis("Mouse X");
        transform.GetChild(0).transform.RotateAround(transform.position, new Vector3(0, 1 , 0)*Time.deltaTime*(-1)* x, angle);
    }
}
