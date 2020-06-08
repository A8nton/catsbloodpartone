using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    [SerializeField]
    private Text text;

    void Start() {
        StartCoroutine(CreditsCoroutine());
    }

    IEnumerator CreditsCoroutine() {
        yield return new WaitForSeconds(2);
        Destroy(text);
        yield return new WaitForSeconds(37);
        Application.LoadLevel(0);
    }
}
