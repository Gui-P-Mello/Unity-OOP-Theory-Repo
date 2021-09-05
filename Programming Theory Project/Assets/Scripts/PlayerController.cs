using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private Camera mainCamera;
    private Rigidbody playerRb;
    private Vector3 moveInput;
    private Vector3 mousePos;
    private Vector3 moveSpeed;
    public float speed =  12;
    private float shotCooldownTime = 0.18f;
    private bool spaceInput;
    private bool canShoot;
    public static PlayerController Instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        canShoot = true;
        mainCamera = FindObjectOfType<Camera>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        mousePos = Input.mousePosition;
        spaceInput = Input.GetKeyDown(KeyCode.Space);
        Shoot();
    }
    void FixedUpdate()
    {
        MovePlayer();
        PlayerLookDirection();
    }

    void MovePlayer()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveSpeed = moveInput * speed;
        playerRb.velocity = moveSpeed;
    }

    void Shoot()
    {
        float projectileY = 0.5f;
        Vector3 projectileOrigin = new Vector3 (transform.position.x, projectileY, transform.position.z);
        if(spaceInput && canShoot)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            canShoot = false;
            StartCoroutine(shotCooldown());
        }
    }
    
    void PlayerLookDirection()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(mousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            Vector3 currentLookDirection = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
            transform.LookAt(currentLookDirection);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator shotCooldown()
    {
        yield return new WaitForSeconds(shotCooldownTime);
        canShoot = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            Debug.Log("Player got hit!");
            SceneManager.LoadScene(0);
        }
    }
}