using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour {

    public void ChangeScene(string game) {
        SceneManager.LoadScene(3);
    }
}
