using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    float timeSinceFired = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceFired += Time.deltaTime;
        if( timeSinceFired > 2 )
        {
            gameObject.SetActive(false);
            timeSinceFired = 0f;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.transform.name);
    }




}
