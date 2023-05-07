using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    private Camera mainCamera;
    public float gravityForce;
    private int currentHealth, maxHealth;
    private int currentMana, maxMana;
    public Transform FirePoint;
    public GameObject projectilePrefabA;
    public GameObject projectilePrefabB;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 75;
        maxHealth = 100;
        currentMana = 75;
        maxMana = 100;
        controller = GetComponent<CharacterController>();
        mainCamera = FindObjectOfType<Camera>();

        UpdateHealth();
        UpdateMana();
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if (controller.isGrounded)
        {
            moveDirection.y = -gravityForce;
            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityForce * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Points Player at Mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //Projectiles
        if (Input.GetMouseButtonDown(0) && FindObjectOfType<ManaManager>().manaAmount >= 10)
        {
            FindObjectOfType<ManaManager>().manaLoss(10);
            var projectileLight = Instantiate(projectilePrefabA, FirePoint.position, FirePoint.rotation);
        }

        if (Input.GetMouseButtonDown(1) && FindObjectOfType<ManaManager>().manaAmount >= 30)
        {
            FindObjectOfType<ManaManager>().manaLoss(30);
            var projectileLight = Instantiate(projectilePrefabB, FirePoint.position, FirePoint.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }


    private void UpdateHealth()
    {
        GUIManager.instance.UpdateHealthBar((float)currentHealth / maxHealth);
    }
    private void UpdateMana()
    {
        GUIManager.instance.UpdateHealthBar((float)currentMana / maxMana);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            audioSource.PlayOneShot(clip, volume);
        }

    }
}
