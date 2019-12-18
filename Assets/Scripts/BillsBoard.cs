﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillsBoard : MonoBehaviour
{
	public Camera m_Camera;
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
