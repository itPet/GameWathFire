using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestScript : MonoBehaviour {

    public GameObject redSquare;

    Collider2D greenCollider;
    Collider2D redCollider;

    SpriteRenderer spriteRenderer;
    Color startColor;

    private void Start()
    {
        greenCollider = GetComponent<Collider2D>();
        redCollider = redSquare.GetComponent<Collider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;

        //greenCollider.isTrigger = true;
        //redCollider.isTrigger = true;
    }

    private void Update() {
        if (redCollider.IsTouching(greenCollider)) {
            spriteRenderer.color = Color.yellow;   
        } else {
            spriteRenderer.color = startColor;
        }
    }
}
