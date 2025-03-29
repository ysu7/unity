using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerRoate : MonoBehaviour
{   
    [SerializeField] private GameObject crosshair;
    
    public Image[] crosshairImages; 

    public float regularFOV = 60f; // Standard camera field of view
    public float aimingFOV = 50f; // Aiming field of view. Creates zoom in effect
    public float currentFOV = 60f;  
    public float aimingSpeed = 10f; // Speed at which we change the field of view

    public float rotationSensitivity = 700f; 
    public Transform playerBody; // The transform of our player body/mesh

    float xRotation = 0f; // Define our x rotation variable
    [SerializeField] private float clampDegreeUp = 70f; 
    [SerializeField] private float clampDegreeDown = -90f; 



    // Start is called before the first frame update
     private void Start() // Called at game start
    {
        Cursor.visible = false; // Cursor will be hidden during play. Press Escape in Unity editor during play mode to change
        Cursor.lockState = CursorLockMode.Locked; // Cursor will be locked at the center of the screen during play. Press Escape in Unity editor during play mode to change
    }

    // Update is called once per frame
    void Update()
    {   
        float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime; // Gets the horizontal mouse input
        float mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime; // Gets the vertical mouse input

        xRotation -= mouseY; // Our x rotation variable equals our vertical mouse input multiplied by -1
        xRotation = Mathf.Clamp(xRotation, clampDegreeDown, clampDegreeUp); // Clamp our x rotation by a minimum and maximum value (How far the player can look up and down in degrees)

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Implement the local rotation of the camera using our x rotation variable
        playerBody.Rotate(Vector3.up * mouseX); // Rotate our player body/mesh on the Y axis based on the horizontal mouse input

        if (crosshair.GetComponent<CrosshairScript1>().Aiming) // If the "Aiming" boolean of the "CrosshiarScript" is equal to true
        {
            currentFOV = Mathf.Lerp(currentFOV, aimingFOV, Time.deltaTime * aimingSpeed); // Lerp the "CurrentFOV" float to "aimingFOV" float
        }
        else // If the "Aiming" boolean of the "CrosshiarScript" is equal to false
        {
            currentFOV = Mathf.Lerp(currentFOV, regularFOV, Time.deltaTime * aimingSpeed); // Lerp the "CurrentFOV" float to "regularFOV" float
        }

        this.gameObject.GetComponentInParent<Camera>().fieldOfView = currentFOV; 





        RaycastHit hit; // Define our Raycast
        if (Physics.Raycast(transform.position, transform.forward, out hit, 200f)) // Set our Raycast from our FPS camera's position to 200 units forward
        {
            if (hit.transform.gameObject.CompareTag("Enemy")) // If our Raycast is hitting an object that is tagged as "Enemy"
            {
                foreach(Image crosshairImage in crosshairImages) // For each one of our crosshair images
                {
                    crosshairImage.color = new Color(1f, 0f, 0f, 1f); // Set the color of our crosshair images to red
                }
            }
            else // If our Raycast is not hitting an object that is tagged as "Enemy"
            {
                foreach (Image crosshairImage in crosshairImages) // For each one of our crosshair images
                {
                    crosshairImage.color = new Color(0.8f, 0.8f, 0.8f, 1f); // Set the color of our crosshair images to a light gray
                }
            }
        }
        else
        {
            foreach (Image crosshairImage in crosshairImages) // For each one of our crosshair images
            {
                crosshairImage.color = new Color(0.8f, 0.8f, 0.8f, 1f); // Set the color of our crosshair images to a light gray
            }
        }
    }
}
