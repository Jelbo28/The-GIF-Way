﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GIFPlayer : MonoBehaviour
{

    [SerializeField] private int health = 12;

    [SerializeField]
    int equipmentCount = 2;
    [SerializeField]
    Transform currEquip;

    private Image[] heartBits;
    [SerializeField] private float damageBuffer;
    private float origDamageBuffer;
    private int heartIndex = 0;
    private bool damaged = false;
    [SerializeField]
    private Transform[] equipment = new Transform[2];
    void Start()
    {
        for (int i = 0; i < equipmentCount; i++)
        {
            equipment[i] = transform.GetChild(0).GetChild(0).GetChild(i);
        } 
        origDamageBuffer = damageBuffer;
        heartBits = GameObject.Find("HeartBits").GetComponentsInChildren<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage();
        if (damageBuffer > 0)
        {
            damageBuffer -= Time.deltaTime;
            if (damaged && heartIndex < heartBits.Count())
            {
                heartBits[heartIndex].enabled = false;
                heartIndex++;
                health--;
                damaged = false;
            }
        }

    }

    public void TakeDamage()
    {
        if (damageBuffer <= 0)
        {
            damageBuffer = origDamageBuffer;
            damaged = true;
        }
        else
        {
            Debug.Log("You're invulnerable.");
        }

    }
}
