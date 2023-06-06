using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionChanger : MonoBehaviour {
    public int _MinimumDimensionTime = 3;
    public int _MaximumDimensionTime = 5;
    private int _dimension = 0;
    public int _controlTime = 0;
    public int _controlIncrement;
    public GameObject _d1;
    public GameObject _d2;
    private GameObject _gameManager;

    // Start is called before the first frame update
    void Start() {
        _gameManager = GameObject.Find("GameManager");
        StartCoroutine(SwitchDimension(Random.Range(_MinimumDimensionTime, _MaximumDimensionTime)));
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator SwitchDimension(int time) {
        yield return new WaitForSeconds(time);
        if(_dimension == 0)  {
            Camera.main.transform.Translate(30, 0, 0);
            _dimension = 1;
            _d1.SetActive(false);
            _d2.SetActive(true);
            _gameManager.GetComponent<PlotManager>()._currentDimension = 2;
            _gameManager.GetComponent<PlotManager>().ResetAlly();
            _gameManager.GetComponent<PlotManager>().ResetValue();
            _gameManager.GetComponent<PlotManager>().ResetMine();
        }
        else {
            Camera.main.transform.Translate(-30, 0, 0);
            _dimension = 0;
            _d1.SetActive(true);
            _d2.SetActive(false);
            _gameManager.GetComponent<PlotManager>()._currentDimension = 1;
            _gameManager.GetComponent<PlotManager>().ResetAlly();
            _gameManager.GetComponent<PlotManager>().ResetValue();
            _gameManager.GetComponent<PlotManager>().ResetMine();
        }
        _controlIncrement += 1;
        if(_controlIncrement == 10) {
            _controlTime += 1;
            _controlIncrement = 0;
        }
        StartCoroutine(SwitchDimension(Random.Range(_MinimumDimensionTime + _controlTime, _MaximumDimensionTime + _controlTime)));
    }
}