using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour {
    public int _maxLife;
    public float _currentLife;
    public float _attackDelay = 0;
    FloatingHeathBar _heathBar;
    // Start is called before the first frame update
    void Start() {
        _heathBar = GetComponentInChildren<FloatingHeathBar>();
    }

    void FixedUpdate() {
        _currentLife -= 0.045f;
    }

    // Update is called once per frame
    void Update() {
        _heathBar.UpdateHelthBar(_currentLife, _maxLife);
        if(_currentLife <= 0) Destroy(this.gameObject);
    }
}