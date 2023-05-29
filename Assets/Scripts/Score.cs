using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
    public int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreTextD1;
    [SerializeField] private TextMeshProUGUI _scoreTextD2;
    [SerializeField] private TextMeshProUGUI _finalScore;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void UpdatreScore(int amount){  //para ganhar dinheiros
        _score += amount;
        _scoreTextD1.text = "Score: " + _score;
        _scoreTextD2.text = "Score: " + _score;
        _finalScore.text = "Score: " + _score;
    }
}
