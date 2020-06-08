using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public void ChangeScene(string game) {
        Application.LoadLevel(game);
    }
}
