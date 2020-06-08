using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject _restart;
    [SerializeField]
    private GameObject _pressE;
    [SerializeField]
    private GameObject _gun;
    [SerializeField]
    private GameObject _hatch;
    [SerializeField]
    private GameObject _uziPickupText;

    public bool isGrounded;

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        if (collision.collider.tag == "Ghost") {
            transform.position = new Vector3(transform.position.x, -20, transform.position.z);
            _restart.SetActive(true);
        }
    }

    public void OnCollisionStay(Collision collision) {
        if (collision.collider.tag == "Hatch") {
            _pressE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                Destroy(_hatch.gameObject);
                StartCoroutine(UziPickup());
            }

        } else {
            _pressE.SetActive(false);
        }
    }

    void Update() {
        if (transform.position.y >= 16) {
            transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        }

        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _moveSpeed;
    }
    void Jump() {
        if (Input.GetButton("Jump") && isGrounded == true) {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
        }
    }

    IEnumerator UziPickup() {
        _uziPickupText.SetActive(true);
        _gun.SetActive(true);
        yield return new WaitForSeconds(2);
        _uziPickupText.SetActive(false);
    }
}
