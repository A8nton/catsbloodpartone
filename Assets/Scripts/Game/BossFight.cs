using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour {

    [SerializeField]
    private GameObject _bossbar;
    [SerializeField]
    private Text _bossText;
    [SerializeField]
    private GameObject _boss;
    [SerializeField]
    private GameObject _exit;
    [SerializeField]
    private int HP = 5;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private GameObject _wowT;

    private float _speed = 0.6f;
    private bool _bossOff;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            if (HP == 5) {
                HP = 4;
                _bossText.text = "▀▀▀▀▀▀▀▀";
            } else if (HP == 4) {
                HP = 3;
                _bossText.text = "▀▀▀▀▀▀";
            } else if (HP == 3) {
                HP = 2;
                _bossText.text = "▀▀▀▀";
            } else if (HP == 2) {
                HP = 1;
                _bossText.text = "▀▀";
            } else if (HP == 1) {
                HP = 0;
                _bossbar.SetActive(false);
                Destroy(_exit);
                _boss.SetActive(false);
            }
        }
    }

    public void Update() {
        if (_bossOff == true) {
            _boss.transform.position = new Vector3(transform.position.x, 999, transform.position.z);
        }
    }
}
