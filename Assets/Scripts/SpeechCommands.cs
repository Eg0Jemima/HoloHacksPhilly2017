﻿using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class SpeechCommands : MonoBehaviour, IInputClickHandler {
    Vector3 originalPosition;
    GameObject spiderCollection;

    // Use this for initialization
    void Start() {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
        spiderCollection = GameObject.Find("Spiders");
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    public void OnInput() {
        
    }

    // Called by SpeechManager when the user says the "Reset world" command
    public void OnReset() {
        EndGame();
        RestoreHealth();
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    public void OnDrop() {
        // Just do the same logic as a Select gesture.
        
    }

    public void EndGame() {
        spiderCollection.SetActive(false);
        //foreach (Transform child in spiderCollection.transform) {
          //  Destroy(child.gameObject);
        //}
    }

    public void RestoreHealth() {
        GameManager.instance.playerHealth = 100;
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>()) {
            Rigidbody rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = true;
        }
    }
}