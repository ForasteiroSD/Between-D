using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public int _damage;
    public string _target;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(AutoDestroy());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision != null && collision.gameObject.tag == _target) {
            if(_target == "Ally") collision.gameObject.GetComponent<Ally>()._currentLife -= _damage;
            if(_target == "Enemy") collision.gameObject.GetComponent<Enemy>()._currentLife -= _damage;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
