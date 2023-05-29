using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour {
    public GameObject _ally;
    private int _value;
    private GameObject _currentAlly;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _hoverColor;
    public bool _mine;
    private GameObject _store;
    private Color _lastColor;
    private GameObject _gameManager;
    private GameObject[] _summomPoints;

    // Start is called before the first frame update
    void Start() {
        this.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager");
        _store = GameObject.Find("Store");
    }

    void OnMouseEnter() {
        if(_ally != null) {
            _lastColor = _sr.color;
            _sr.color = _hoverColor;
        }
    }

    void OnMouseExit() {
        if(_ally != null) {
            _sr.color = _lastColor;
        }
    }

    // Update is called once per frame
    void Update() {
        _ally = _gameManager.GetComponent<PlotManager>()._curentAlly;
        _value = _gameManager.GetComponent<PlotManager>()._curentValue;
    }

    void OnMouseDown() {
        if(_currentAlly != null || _ally == null || !_store.GetComponent<Store>().CanBuy(_value)) return;

        _currentAlly = Instantiate(_ally, transform.position, transform.rotation);
        _store.GetComponent<Store>().SpendCurrency(_value);
        _gameManager.GetComponent<PlotManager>().ResetAlly();
        _gameManager.GetComponent<PlotManager>().ResetValue();
    }
}