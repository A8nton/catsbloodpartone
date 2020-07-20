using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTracker : MonoBehaviour {

    [SerializeField]
    private GameObject _cat;
    [SerializeField]
    private GameObject _bCat;
    [SerializeField]
    private GameObject _wCat;

    [SerializeField]
    private Text _day;
    [SerializeField]
    private Text _month;

    public void Start() {
        var currentDate = System.DateTime.Now;
        _day.text = currentDate.Day.ToString();
        _month.text = currentDate.Month.ToString();

        if (_day.text == "11" && _month.text == "7")
            _bCat.SetActive(true);
        else if (_month.text == "12" || _month.text == "1" || _month.text == "2")
            _wCat.SetActive(true);
        else
            _cat.SetActive(true);
    }
}

