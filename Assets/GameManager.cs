﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int playerHealth = 100;
    public Text playerHealthText;
    public Text killText;
    public static GameManager instance;
    public float spawnRate = 0.5f;
    [HideInInspector] public GameObject spiders;
    [HideInInspector] public int killCount = 0;

    private void Awake() {
        instance = this;
        spiders = GameObject.Find("Spiders");
    }

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Spawn() {
        GameObject newSpider = Instantiate(Resources.Load<GameObject>("Prefabs/SpiderAndWeb"));
        newSpider.transform.parent = spiders.transform;
        //newSpider.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), 0);
        newSpider.transform.rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
        if(spiders.transform.childCount > 20) {
            Destroy(spiders.transform.GetChild(0).gameObject);
        }
    }
}
