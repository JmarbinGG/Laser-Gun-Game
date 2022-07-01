using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject prefabs;
    
    public float count = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
       
    }
   

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            //SpawnEnemy
            
            
                yield return new WaitForSeconds(count);
                Instantiate(prefabs, transform.position, Quaternion.identity);
            
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
