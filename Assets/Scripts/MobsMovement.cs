using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsMovement : MonoBehaviour  {
    [SerializeField] public GameObject[] _path;
    public float _speed = 2f;
    public float _rotationSpeed = 2f;
    private int _pathIndex = 0;
    private Animator _animator;
    public int _dimension;
    // Start is called before the first frame update
    void Start() {
        _path = GameObject.FindGameObjectsWithTag("Path" + _dimension);
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if(_pathIndex <= _path.Length - 1) {
            if(GetComponent<Enemy>()._shortRange || (this.transform.GetChild(1).gameObject.GetComponent<Shoot>()._canWalk && this.transform.GetChild(2).gameObject.GetComponent<StopMovement>()._canWalk)) {
                _animator.SetBool("Walking", true);
                _animator.ResetTrigger("Attacking");
                //Rotation
                float angle = Mathf.Atan2(_path[_pathIndex].transform.position.y - transform.position.y, _path[_pathIndex].transform.position.x - transform.position.x) * Mathf.Rad2Deg + 90;

                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

                transform.rotation = rotation;
                
                //Moving
                transform.position = Vector2.MoveTowards(transform.position, _path[_pathIndex].transform.position, _speed * Time.deltaTime);

                if(transform.position == new Vector3(_path[_pathIndex].transform.position.x, _path[_pathIndex].transform.position.y, 0)) _pathIndex++;
            } else {
                _animator.SetBool("Walking", false);
            }

        } else {
            Destroy(gameObject);
            GameObject.Find("Core").GetComponent<Core>()._coreLife -= 5;
        }
    }
}
