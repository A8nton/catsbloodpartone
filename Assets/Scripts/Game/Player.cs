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
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private float _fallMultiplier = 2.5f;
    [SerializeField]
    private float _lowJumpMultiplier = 2f;

    [SerializeField]
    [Range(1, 20)]
    private float _jumpVelocity = 10;

    public bool isGrounded;

    private Rigidbody rb;

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;
        }

        if (collision.collider.tag == "Ghost") {
            _camera.transform.position = new Vector3(transform.position.x, -30, transform.position.z);
            _restart.SetActive(true);
        }
    }

    public void OnCollisionExit(Collision collision) {
        isGrounded = false;
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
        Jump();
        if (transform.position.y >= 16) {
            transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _moveSpeed;
    }

    void Jump() {
        if (isGrounded == true) {
            rb = GetComponent<Rigidbody>();
            if (Input.GetButtonDown("Jump")) {
                GetComponent<Rigidbody>().velocity = Vector3.up * _jumpVelocity;
                rb.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    IEnumerator UziPickup() {
        _uziPickupText.SetActive(true);
        _gun.SetActive(true);
        yield return new WaitForSeconds(2);
        _uziPickupText.SetActive(false);
    }
}
