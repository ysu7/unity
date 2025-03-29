using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("collided with " + collision.gameObject.name);

        anim.SetBool("isHit",true);

        bool isDead =  GetComponentInParent<EnemyScript>().TakeDamage(1);

        if(isDead){
            Debug.Log("dead");
            anim.SetBool("isDead",true);
            gameObject.SetActive(false);
            
        }

    }

    void playSound(){
        GetComponent<AudioSource>().Play();
    }

    void Unflinch(){
        anim.SetBool("isHit",false);
    }



}
