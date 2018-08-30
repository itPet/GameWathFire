using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject jumperPrefab;
    public GameObject fireman;
    public LifeViewController lifeViewController;
    public PointsController pointsView;

    Collider2D firemanCollider;

	
	void Start () {
        firemanCollider = fireman.GetComponentInChildren<Collider2D>();
        lifeViewController.RestoreAllLives();
        NewJumper();
	}

    void NewJumper() {
        GameObject newJumper = Instantiate(jumperPrefab);
        newJumper.GetComponentInChildren<JumperController>().gameManager = this;
    }

    public void JumperSaved() {
        pointsView.AddPoints();
    }

    public bool Crash(GameObject jumper) {
        Collider2D jumperCollider = jumper.GetComponent<Collider2D>();

        LayerMask mask = LayerMask.GetMask("Fireman");
        RaycastHit2D hit = Physics2D.Raycast(jumper.transform.position, Vector2.down, Mathf.Infinity, mask);

        if (hit.collider != null) {
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
