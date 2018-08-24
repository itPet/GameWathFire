using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {

    public GameManager gameManager;
    public List<GameObject> positions;
    public float moveDelay = 0.5f;
    int currentPosition = 0;
    float lastMoveTime;

	// Use this for initialization
	void Start () {
        transform.position = positions[currentPosition].transform.position;
        lastMoveTime = Time.time;
        StartCoroutine(MoveJumper());
	}

    IEnumerator MoveJumper() {
        while (true) {
            yield return new WaitForSeconds(moveDelay);
            StartCoroutine(MoveToNextPosition());
        }
    }

    // Update is called once per frame
    //void Update () {
    //       if ( Time.time > lastMoveTime + moveDelay) {
    //           MoveToNextPosition();
    //       }
    //}

    // Helper function to MoveJumper()
    IEnumerator MoveToNextPosition() {
        currentPosition++;
        if (currentPosition >= positions.Count)
            currentPosition = 0;
        
        transform.position = positions[currentPosition].transform.position;
        lastMoveTime = Time.time;

        // Wait one frame until crach check is done so physics is calculatet
        yield return null;

        if (positions[currentPosition].GetComponent<JumperPosition>().dangerPosition) {
            if (gameManager.Crash(gameObject)) {
                Die();
            }
        }
    }

    void Die() {
        Destroy(transform.parent.gameObject);
    }

}
