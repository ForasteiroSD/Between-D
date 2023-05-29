using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
    public int _coreLife = 100;
    [SerializeField] public GameObject _healthBar1;
    [SerializeField] public GameObject _healthBar2;
    // Start is called before the first frame update
    [SerializeField] private GameObject _gameOver;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        _healthBar1.GetComponent<CoreLife>().UpdateHelthBar(_coreLife, 100);
        _healthBar2.GetComponent<CoreLife>().UpdateHelthBar(_coreLife, 100);
        if(_coreLife <= 0) {
            _gameOver.SetActive(true);
            Camera.main.GetComponent<AudioSource>().mute = true;
            Time.timeScale = 0;
        }
    }
}
