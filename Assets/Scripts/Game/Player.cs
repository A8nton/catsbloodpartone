using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    private GameObject _bullet;
    [SerializeField]
    private GameObject _firePoint;
    [SerializeField]
    private GameObject _rocketCamera;
    [SerializeField]
    private GameObject _cat;
    [SerializeField]
    private GameObject _wowT;
    [SerializeField]
    private GameObject _info;

    public bool _canMove = true;

    [SerializeField]
    [Range(1, 20)]
    private float _jumpVelocity = 10;
    private Transform _transform;
    private Rigidbody rb;
    private GameObject _instance;

    public bool isGrounded;
    private bool _uzi;
    private bool _canFire;

    public void Start() {
        _transform = this.gameObject.transform;
        StartCoroutine(Info());
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ghost" || collision.collider.tag == "Fall" || collision.collider.tag == "Boss") {
            _camera.transform.position = new Vector3(transform.position.x, -100, transform.position.z);
            _restart.SetActive(true);
        }
        if (collision.collider.tag == "Rocket") {
            StartCoroutine(RR());
            _rocketCamera.SetActive(true);
            _camera.SetActive(false);
            _cat.SetActive(false);
            _canMove = false;
        }
    }

    public void OnCollisionExit(Collision collision) {
        isGrounded = false;
    }

    public void OnCollisionStay(Collision collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;
        }
        if (collision.collider.tag == "Hatch") {
            _pressE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                _uzi = true;
                Destroy(_hatch.gameObject);
                StartCoroutine(UziPickup());
            }

        } else {
            _pressE.SetActive(false);
        }
    }

    void Update() {
        /*if (Input.GetKeyDown("d")) {
            _cat.transform.Rotate(transform.rotation.x, 180, transform.rotation.z);
            _camera.transform.Rotate(0, -180, 0);
            _camera.transform.position = new Vector3(-7.5f, 8.3f, 48.6f);
        }
        if (Input.GetKeyDown("a")) {
            _cat.transform.Rotate(transform.rotation.x, 0, transform.rotation.z);
            _camera.transform.position = new Vector3(-7.5f, 8.3f, -48.6f);
        }*/

        if (_canMove == true) {
            Jump();
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * _moveSpeed;

            if (Input.GetKeyDown(KeyCode.F)) {
                if (_canFire == true) {
                    print("Q Pressed");
                    _instance = Instantiate(_bullet, new Vector3(_transform.position.x + 2, _firePoint.transform.position.y, _firePoint.transform.position.z), Quaternion.identity);
                    StartCoroutine(CFire());
                }
            }
        }
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
        _canFire = true;
        _uziPickupText.SetActive(true);
        _gun.SetActive(true);
        yield return new WaitForSeconds(2);
        _uziPickupText.SetActive(false);
    }

    IEnumerator CFire() {
        _canFire = false;
        yield return new WaitForSeconds(1.5f);
        _canFire = true;
        Destroy(_instance);
    }
    IEnumerator Info() {
        _info.SetActive(true);
        yield return new WaitForSeconds(3);
        _info.SetActive(false);
    }
    IEnumerator RR() {
        _wowT.SetActive(true);
        yield return new WaitForSeconds(3);
        _wowT.SetActive(false);
    }
}
