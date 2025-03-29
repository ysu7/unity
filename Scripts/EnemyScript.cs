using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    public Transform player;
    public int hitPoints =7;

    UnityEngine.AI.NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
       
    }


     public bool TakeDamage(int amount){
        hitPoints -= amount;
        if(hitPoints <=0){
            return true;
        }
        return false;
     }



    // Update is called once per frame
    void Update()
    {
         agent.destination = player.position;
    }

   




}
