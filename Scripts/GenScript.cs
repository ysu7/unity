using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenScript : MonoBehaviour
{
    public GameObject prefab;
    public float time_delay = 5f;
    private float gen_timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        gen_timer += Time.deltaTime;
        if (gen_timer > time_delay){
            gen_timer = 0;
            GameObject clone = Instantiate(prefab);
            EnemyScript sc = clone.GetComponent<EnemyScript>();
            sc.player = player.transform;
        }
    }
}
