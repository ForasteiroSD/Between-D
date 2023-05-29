using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int _maxLife;
    public int _currentLife;
    public bool _shortRange;
    public float _attackDelay = 0;
    public int _moneyDrop;
    public int _scoreDrop;
    private GameObject _store;
    private GameObject _gameManager;
    FloatingHeathBar _heathBar;
    // Start is called before the first frame update
    void Start() {
        _store = GameObject.Find("Store");
        _gameManager = GameObject.Find("GameManager");
        _heathBar = GetComponentInChildren<FloatingHeathBar>();
    }

    // Update is called once per frame
    void Update() {
        _heathBar.UpdateHelthBar(_currentLife, _maxLife);
        if(_currentLife <= 0) {
            Destroy(this.gameObject);
            _store.GetComponent<Store>().IncreaseCurrency(_moneyDrop);
            _gameManager.GetComponent<Score>().UpdatreScore(_scoreDrop);
        }
    }
}
