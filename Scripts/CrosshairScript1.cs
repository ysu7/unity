using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript1 : MonoBehaviour
{
   [SerializeField] private RectTransform crosshair;

    //public GameObject player; // We will reference a boolean from the player's "PlayerMove" script 

    public float aimSize = 25f;
    public float idleSize = 50f;
    public float walkSize = 75f;
    
    public float currentSize = 50f; 
    public float speed = 15f; // Crosshair scaling speed

    private void Update() // Called once per frame
    {
        if (Aiming) // If "Aiming" boolean is set to true
        {
            currentSize = Mathf.Lerp(currentSize, aimSize, Time.deltaTime * speed); // Lerp the currentSize float to aimSize float
        }
        
        else if (Walking) // If "Walking" boolean is set to true
        {
            currentSize = Mathf.Lerp(currentSize, walkSize, Time.deltaTime * speed); // Lerp the currentSize float to walkSize float
        }

        else // if the player is idle
        {
            currentSize = Mathf.Lerp(currentSize, idleSize, Time.deltaTime * speed); // Lerp the currentSize float to idleSize float
        }

        crosshair.sizeDelta = new Vector2(currentSize, currentSize); // Resize the crosshair X and Y values to the currentSize float 
    }

    public bool Aiming // Define the "Aiming" boolean
    {
        get // Use the get method to return a value for the "Aiming" boolean
        {
            if (Input.GetMouseButton(1)) // If the right mouse button is pressed
            {
                if (!Walking ) 
                {
                    return true; 
                }
                else 
                {
                    return false; 
                }
            }
            else // If the right mouse button is not pressed
            {
                return false; // Return a false value for the aiming boolean
            }
        }
    }

    bool Walking // Define the "Walking" boolean
    {
        get // Use the get method to return a value for the "Walking" boolean
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // If Unity's input buttons for "Horizontal" and/or "Vertical" are being pressed
            {
                if (Input.GetKey(KeyCode.LeftShift) == false ) // If the left shift button is not being pressed 
                {
                    return true; 
                }
                else 
                {
                    return false; 
                }
            }
            else // If Unity's input buttons for "Horizontal" and/or "Vertical" are not being pressed
            {
                return false; 
            }
        }
    }




}
