using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorScript : MonoBehaviour {

    [SerializeField]
    private GameObject _loading;
    [SerializeField]
    private GameObject _errors;

    void Start() {
        StartCoroutine(Error());
    }

    IEnumerator Error() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(5);
        _loading.SetActive(false);
        _errors.SetActive(true);
    }
}
