using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public string _target;
    public int _damage = 100;
    public float _range = 1f;
    public float _delayToDestroy;
    private GameObject[] _enemiesInRange;
    private Animator _animator;
    // Start is called before the first frame update
    void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == _target) {
            // _enemiesInRange = GameObject.FindGameObjectsWithTag("Enemy");
            // foreach (var enemy in _enemiesInRange) {
            //     if(Vector3.Distance(this.transform.position, enemy.transform.position) < _range) enemy.GetComponent<Enemy>()._currentLife -= _damage;
            //     Debug.Log(enemy);
            //     Debug.Log(_damage);
            // }
            _animator.SetTrigger("Explode");
            StartCoroutine(SelfDestroy(collision));
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator SelfDestroy(Collider2D collision) {
        yield return new WaitForSeconds(_delayToDestroy/2);
        collision.GetComponent<Enemy>()._currentLife -= _damage;
        yield return new WaitForSeconds(_delayToDestroy/2);
        Destroy(transform.parent.gameObject);
    }
}
