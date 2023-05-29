using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisca : MonoBehaviour {
    public float _time = 1f;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(PiscaText());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator PiscaText() {
        Debug.Log(!gameObject.activeSelf);
        yield return new WaitForSeconds(_time);
        this.gameObject.SetActive(!gameObject.activeSelf);
        StartCoroutine(PiscaText());
    }
}
