using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public float _MinimumSpawnTime = 0f;
    public float _MaximumSpawnTime = 1.5f;
    public GameObject[] _enemies;
    public int _dimension;
    private int _enemyType;
    public bool _canSpawn = true;
    public bool _canSpawn2 = true;
    public int _delayToStart;
    public float _controlSpawnTime = 0f;
    private bool _waitedDelay = false;
    private GameObject[] _enemiesRange;
    [SerializeField] private bool _shortRange;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(WaitInitialTime());
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        _enemiesRange = GameObject.FindGameObjectsWithTag("Enemy");
        _canSpawn2 = true;
        foreach (var enemy in _enemiesRange) {
            if(Vector3.Distance(this.transform.position, enemy.transform.position) < 10.5f) _canSpawn2 = false;
        }
        if(_canSpawn2 && _waitedDelay) StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        if(_canSpawn) {
            _canSpawn = false;
            yield return new WaitForSeconds(UnityEngine.Random.Range(_MinimumSpawnTime, _MaximumSpawnTime - _controlSpawnTime));
            if(_shortRange && _controlSpawnTime < _MaximumSpawnTime) _controlSpawnTime += 0.05f;
            if(!_shortRange && _controlSpawnTime < 8) _controlSpawnTime += 0.05f;
            _enemyType = UnityEngine.Random.Range(0, _enemies.Length);
            GameObject _enemy = Instantiate(_enemies[_enemyType], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            if(_dimension == 1) _enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
            _canSpawn = true;
        }
    }

    IEnumerator WaitInitialTime() {
        yield return new WaitForSeconds(_delayToStart);
        _waitedDelay = true;
    }
}
