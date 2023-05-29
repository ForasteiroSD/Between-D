using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour {
    public bool _canWalk = true;
    // Start is called before the first frame update
    void Start() {
        // StartCoroutine(ResetWalk());
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            _canWalk = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            _canWalk = true;
        }
    }

    // IEnumerator ResetWalk() {
    //     yield return new WaitForSeconds(2f);
    //     _canWalk = true;
    //     StartCoroutine(ResetWalk());
    // }
}
