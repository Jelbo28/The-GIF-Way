using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    // General
    [SerializeField] public string name;

    // Currency
    [SerializeField] public int value = 0;
    [SerializeField] private bool ignorePlayerColl = false;

    // AI Stuff
    [SerializeField]
    public float health = 100f;

    [SerializeField] private float speed;
    [SerializeField]
    private Vector2 moveTimer;
    [SerializeField] private float damageValue;
    [SerializeField] private Vector2 attackTimer;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
