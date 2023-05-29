using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public bool _canWalk = true;
    public string _target;
    public int _attackDivision = 5;
    public float _attackSpeed = 2;
    public bool _canAttack = true;
    public float _attackCooldown = 1.5f;
    [SerializeField] public GameObject _attack;
    private GameObject _closestEnemy;
    private Rigidbody2D _rb;
    private float _angle;
    private Animator _animator;
    // Start is called before the first frame update
    void Start() {
        _animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == _target) {
            _canWalk = false;
            if(_closestEnemy == null) _closestEnemy = collision.gameObject;
            float distance = (transform.position - collision.transform.position).sqrMagnitude;
            if(distance < (transform.position - _closestEnemy.transform.position).sqrMagnitude) _closestEnemy = collision.gameObject;
            LookToEnemy(_closestEnemy);
            if(_canAttack) StartCoroutine(Attack(_closestEnemy));
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == _target) {
            _canWalk = true;
            // transform.parent.transform.position -= new Vector3(1f,0,0);
            // transform.parent.transform.position += new Vector3(1f,0,0);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {

    }

    void LookToEnemy(GameObject closestEnemy) {
        _angle = Mathf.Atan2(closestEnemy.transform.position.y - transform.position.y, closestEnemy.transform.position.x - transform.position.x);

        Quaternion targetRotation = Quaternion.AngleAxis(_angle * Mathf.Rad2Deg + 90, Vector3.forward);

        this.gameObject.transform.parent.transform.rotation = targetRotation;
    }

    IEnumerator Attack(GameObject closestEnemy) {
        _canAttack = false;

        _animator.ResetTrigger("Attacking");
        _animator.SetTrigger("Attacking");
        if(_target == "Enemy") yield return new WaitForSeconds(transform.parent.gameObject.GetComponent<Ally>()._attackDelay);
        else yield return new WaitForSeconds(transform.parent.gameObject.GetComponent<Enemy>()._attackDelay);
        Quaternion targetRotation = Quaternion.AngleAxis(_angle * Mathf.Rad2Deg, Vector3.forward);
        if(closestEnemy != null) {
            GameObject fireball = Instantiate(_attack, new Vector3(transform.position.x + (closestEnemy.transform.position.x - transform.position.x)/_attackDivision, transform.position.y + (closestEnemy.transform.position.y - transform.position.y)/_attackDivision, 0), targetRotation);
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(closestEnemy.transform.position.x - transform.position.x, closestEnemy.transform.position.y - transform.position.y) * _attackSpeed;
        }
        
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}   