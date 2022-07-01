using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class droneController : MonoBehaviour
{
    GameObject player;
    GameObject enemyes;
    NavMeshAgent nav;
    public GameObject sameOBJ;
    EnemyController script;

      // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        nav = GetComponent<NavMeshAgent>();
        script = sameOBJ.GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

     void Move()
    {
       
        if (!script.isDead){
            Vector3 target = player.transform.position;
            nav.SetDestination(target);
        }
            
    }

   
}
