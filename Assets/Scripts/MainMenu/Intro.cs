using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    void Start() {
        StartCoroutine(Intr());
    }

    IEnumerator Intr() {
        yield return new WaitForSeconds(8f);
        Application.LoadLevel(0);
    }
}
