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
    private bool _canWalk = false;
    // Start is called before the first frame update
    void Awake() {
        Debug.Log(_path.Length);
        GameObject pathObj = GameObject.Find("Path" + _dimension);
        for(int i = 0; i < 16; i++) {
            _path[i] = pathObj.transform.GetChild(i).gameObject;
        }
        _canWalk = true;
        _animator = GetComponent<Animator>();
    }

    void Start() {
        // Debug.Log(pathObj);
        // Debug.Log(pathObj.transform.GetChild(0).gameObject);
        // Debug.Log(pathObj.transform.GetChild(1).gameObject);
        // Debug.Log(pathObj.transform.GetChild(2).gameObject);
        // Debug.Log(pathObj.transform.GetChild(3).gameObject);
        // Debug.Log(pathObj.transform.GetChild(4).gameObject);
        // Debug.Log(pathObj.transform.GetChild(5).gameObject);
        // Debug.Log(pathObj.transform.GetChild(6).gameObject);
        // Debug.Log(pathObj.transform.GetChild(7).gameObject);
        // Debug.Log(pathObj.transform.GetChild(8).gameObject);
        // Debug.Log(pathObj.transform.GetChild(9).gameObject);
        // Debug.Log(pathObj.transform.GetChild(10).gameObject);
        // Debug.Log(pathObj.transform.GetChild(11).gameObject);
        // Debug.Log(pathObj.transform.GetChild(12).gameObject);
        // Debug.Log(pathObj.transform.GetChild(13).gameObject);
        // Debug.Log(pathObj.transform.GetChild(14).gameObject);
        // Debug.Log(pathObj.transform.GetChild(15).gameObject);
        // GameObject[] _path = {pathObj.transform.GetChild(0).gameObject, pathObj.transform.GetChild(1).gameObject, pathObj.transform.GetChild(2).gameObject,
        // pathObj.transform.GetChild(3).gameObject, pathObj.transform.GetChild(4).gameObject, pathObj.transform.GetChild(5).gameObject,
        // pathObj.transform.GetChild(6).gameObject, pathObj.transform.GetChild(7).gameObject, pathObj.transform.GetChild(8).gameObject,
        // pathObj.transform.GetChild(9).gameObject, pathObj.transform.GetChild(10).gameObject, pathObj.transform.GetChild(11).gameObject,
        // pathObj.transform.GetChild(12).gameObject, pathObj.transform.GetChild(13).gameObject, pathObj.transform.GetChild(14).gameObject,
        // pathObj.transform.GetChild(15).gameObject};
        // _path[0] = pathObj.transform.GetChild(0).gameObject;
        // _path[1] = pathObj.transform.GetChild(1).gameObject;
        // _path[2] = pathObj.transform.GetChild(2).gameObject;
        // _path[3] = pathObj.transform.GetChild(3).gameObject;
        // _path[4] = pathObj.transform.GetChild(4).gameObject;
        // _path[5] = pathObj.transform.GetChild(5).gameObject;
        // _path[6] = pathObj.transform.GetChild(6).gameObject;
        // _path[7] = pathObj.transform.GetChild(7).gameObject;
        // _path[8] = pathObj.transform.GetChild(8).gameObject;
        // _path[9] = pathObj.transform.GetChild(9).gameObject;
        // _path[10] = pathObj.transform.GetChild(10).gameObject;
        // _path[11] = pathObj.transform.GetChild(11).gameObject;
        // _path[12] = pathObj.transform.GetChild(12).gameObject;
        // _path[13] = pathObj.transform.GetChild(13).gameObject;
        // _path[14] = pathObj.transform.GetChild(14).gameObject;
        // _path[15] = pathObj.transform.GetChild(15).gameObject;
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        if(_canWalk) Move();
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
