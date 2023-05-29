using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreLife : MonoBehaviour {
    [SerializeField] private Slider _slider;
    public void UpdateHelthBar(float currentLife, float maxLife) {
        _slider.value = currentLife / maxLife;
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }  
}
