using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject jumperPrefab;
    public GameObject fireman;
    public LifeViewController lifeViewController;

    Collider2D firemanCollider;

	// Use this for initialization
	void Start () {
        firemanCollider = fireman.GetComponentInChildren<Collider2D>();
        lifeViewController.RestoreAllLives();
        NewJumper();
	}

    void NewJumper() {
        GameObject newJumper = Instantiate(jumperPrefab);
        newJumper.GetComponentInChildren<JumperController>().gameManager = this;
    }

    public bool Crash(GameObject jumper) {
        Collider2D jumperCollider = jumper.GetComponent<Collider2D>();

        if (jumperCollider.IsTouching(firemanCollider)) {
            return false;
        } 
        else {
            LoseOneLife();
            return true;
        }
    }

    void LoseOneLife() {
        if (!lifeViewController.RemoveLife()) {
            Debug.Log("Game Over!");
        } else {
            NewJumper();    
        }
    }







    //private void Update() {
    //    if ( firemanCollider.IsTouching(tempJumperCollider)) {
    //        fireman.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
    //    } else {
    //        fireman.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    //    }
    //}
}
