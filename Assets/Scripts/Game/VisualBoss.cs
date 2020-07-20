using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class VisualBoss : MonoBehaviour {

    [SerializeField]
    private GameObject _vBoss;
    [SerializeField]
    private Player _cat;
    [SerializeField]
    private Player _bCat;
    [SerializeField]
    private Player _wCat;
    [SerializeField]
    private GameObject _first;
    [SerializeField]
    private GameObject _second;
    [SerializeField]
    private GameObject _earth;
    [SerializeField]
    private GameObject _boom;
    [SerializeField]
    private GameObject _trigger;


    [SerializeField]
    private GameObject five;
    [SerializeField]
    private GameObject four;
    [SerializeField]
    private GameObject three;
    [SerializeField]
    private GameObject two;
    [SerializeField]
    private GameObject one;
    [SerializeField]
    private GameObject start;

    private bool _frt = true;

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            _frt = false;
            StartCoroutine(Dialog());
        }
    }

    public void Update() {
        if (_frt == true) {
            _cat._canMove = true;
            _bCat._canMove = true;
            _wCat._canMove = true;
        } else {
            _cat._canMove = false;
            _bCat._canMove = false;
            _wCat._canMove = false;
        }
    }

    IEnumerator Dialog() {
        _first.SetActive(true);
        yield return new WaitForSeconds(5);
        _first.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        _second.SetActive(true);
        yield return new WaitForSeconds(5);
        _second.SetActive(false);
        five.SetActive(true);
        yield return new WaitForSeconds(1);
        five.SetActive(false);
        four.SetActive(true);
        yield return new WaitForSeconds(1);
        four.SetActive(false);
        three.SetActive(true);
        yield return new WaitForSeconds(1);
        three.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(1);
        two.SetActive(false);
        one.SetActive(true);
        yield return new WaitForSeconds(1);
        one.SetActive(false);
        start.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        start.SetActive(false);
        _boom.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _earth.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        _boom.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(_vBoss);
        SetTrue();
        yield return new WaitForSeconds(0.2f);
        Destroy(_trigger);
    }

    void SetTrue() {
        _frt = true;
    }
}
