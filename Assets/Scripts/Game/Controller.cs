using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public void ChangeScene(string game) {
        SceneManager.LoadScene(game);
    }
}
