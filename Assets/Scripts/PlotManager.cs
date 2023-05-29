using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour {
    public GameObject _curentAlly;
    public int _curentValue;
    public bool _mine = false;
    public int _currentDimension = 1;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] public GameObject[] _summomPointsD1;
    [SerializeField] public GameObject[] _summomPointsD2;
    private GameObject[] _currentSummomPoints;
    void Awake() {
        _summomPointsD1 = GameObject.FindGameObjectsWithTag("SummomPointD1");
        _summomPointsD2 = GameObject.FindGameObjectsWithTag("SummomPointD2");
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetAlly(GameObject ally) {
        _curentAlly = ally;
        if(_currentDimension == 1) _currentSummomPoints = _summomPointsD1;
        else if(_currentDimension == 2) _currentSummomPoints = _summomPointsD2;
        if(_mine) {
            foreach (var point in _currentSummomPoints) {
                if(point.GetComponent<Plot>()._mine) point.SetActive(true);
                else point.SetActive(false);
            }
        }
        else {
            foreach (var point in _currentSummomPoints) {
                if(!point.GetComponent<Plot>()._mine) point.SetActive(true);
                else point.SetActive(false);
            }
        }
    }

    public void ResetAlly() {
        _curentAlly = null;
        if(_currentDimension == 1) _currentSummomPoints = _summomPointsD1;
        else if(_currentDimension == 2) _currentSummomPoints = _summomPointsD2;
        foreach (var point in _currentSummomPoints) {
            point.SetActive(false);
        }
    }

    public void SetValue(int value) {
        _curentValue = value;
    }

    public void ResetValue() {
        _curentValue = 0;
    }

    public void SetMine() {
        _mine = true;
    }

    public void ResetMine() {
        _mine = false;
    }
}
