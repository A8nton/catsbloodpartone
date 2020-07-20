using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField]
    private GameObject _rocket;
    [SerializeField]
    private GameObject _cat;
    [SerializeField]
    private GameObject _bCat;
    [SerializeField]
    private GameObject _wCat;

    private bool _canFly;

    void Update() {
        if (_cat.activeSelf == false && _bCat.activeSelf == false && _wCat.activeSelf == false) {
            StartCoroutine(Wait());
            if (_canFly == true)
                _rocket.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
        _canFly = true;
    }
}
