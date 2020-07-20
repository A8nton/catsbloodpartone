using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    void Start() {
        StartCoroutine(Intr());
    }

    IEnumerator Intr() {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
    }
}
