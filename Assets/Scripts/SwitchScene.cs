using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {
    [SerializeField] private int _scene;
    [SerializeField] private bool _gameOver;
    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
        if(_scene == 2 && !_gameOver) StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update() {
        if(_gameOver) {
            if(Input.GetKey(KeyCode.Return)) SceneManager.LoadScene(2);
            if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        }
        else {
            if(_scene == 1) if(Input.GetKey(KeyCode.Return)) SceneManager.LoadScene(_scene);
            if(_scene == 2) if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(_scene);
        }
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(62);
        SceneManager.LoadScene(_scene);
    }
}
