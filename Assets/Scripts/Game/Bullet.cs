using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _transform;
    private float _speed = 20;

        public void Start() {
        _transform = transform;
    }

    void Update() {
        _transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other) {
        print(other.tag);
        if (other.CompareTag("Ghost"))
            Destroy(other.gameObject);
    }
}
