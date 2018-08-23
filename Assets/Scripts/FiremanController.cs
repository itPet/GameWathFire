﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {
    
    public List<Transform> positions;

    int currentPosition = 0;

    private void OnEnable() {
        Input.OnLeftPressed += Input_OnLeftPressed;
        Input.OnRightPressed += Input_OnRightPressed;
    }

    private void OnDisable() {
        Input.OnLeftPressed -= Input_OnLeftPressed;
        Input.OnRightPressed -= Input_OnRightPressed;
    }

    private void Start() {
        transform.position = positions[currentPosition].position;
    }

    void Input_OnLeftPressed() {
        if (currentPosition > 0) {
            currentPosition--;
            transform.position = positions[currentPosition].position;
        }   
    }

    void Input_OnRightPressed()
    {
        if (currentPosition < positions.Count - 1)
        {
            currentPosition++;
            transform.position = positions[currentPosition].position;
        }
    }

}
