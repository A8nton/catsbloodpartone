using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject _bossBarrier;
    [SerializeField]
    private GameObject _bossbar;
    [SerializeField]
    private GameObject _bossTrigger;
    [SerializeField]
    private GameObject _boss;

    public bool _canHurt;

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            _canHurt = true;
            _bossBarrier.SetActive(true);
            _bossbar.SetActive(true);
            _boss.SetActive(true);
            Destroy(_bossTrigger);
        }
    }
}
