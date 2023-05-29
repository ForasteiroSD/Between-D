using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHeathBar : MonoBehaviour {
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    public void UpdateHelthBar(float currentLife, float maxLife) {
        _slider.value = currentLife / maxLife;
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = _target.position + _offset;
    }
}
