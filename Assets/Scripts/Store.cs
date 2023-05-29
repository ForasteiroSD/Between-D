using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Store : MonoBehaviour {
    public int _currency = 100;
    public TextMeshProUGUI _moneyTextD1;
    public TextMeshProUGUI _moneyTextD2;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public bool CanBuy(int value){  //para ganhar dinheiros
        if(value <= _currency) return true;
        else return false;
    }

    public void IncreaseCurrency(int amount){  //para ganhar dinheiros
        _currency += amount;
        _moneyTextD1.text = "$" + _currency;
        _moneyTextD2.text = "$" + _currency;
    }

    public bool SpendCurrency(int amount){  // situação para comprar,caso de retorna 1 caso contrario retona 0
        if(amount <= _currency) {
            _currency -= amount;
            _moneyTextD1.text = "$" + _currency;
            _moneyTextD2.text = "$" + _currency;
            return true;
        } else {
            Debug.Log("Dinheiro insuficiente");
            return false;
        }
    }
}
