﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismPower : MonoBehaviour
{
    public MagnetismManager mag;
    public int decrement;
    private bool canMagnet;
    private RaycastHit hit;
    private void Start()
    {
        canMagnet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.tag == "Magnetisable")
                {
                    if (mag.GetValue() > 0) 
                    {
                        mag.UpdateAmount(-decrement);
                        canMagnet = true;
                    }
                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            canMagnet = false;
        }
        if (canMagnet)
        {
            hit.collider.gameObject.GetComponent<MagnetismEffect>().effect(this.transform);
        }
    }
}
