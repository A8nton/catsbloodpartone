using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {
    void Start() {
        StartCoroutine(Ending());
    }

    IEnumerator Ending() {
        yield return new WaitForSeconds(63);
        SceneManager.LoadScene(0);
    }
}
