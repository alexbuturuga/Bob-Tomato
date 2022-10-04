using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform stanga, dreapta;
    public int wave, stage, enemyCount;
    public float spawntime = 1000f;
    public float cooldown = 5000f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
       if (enemyCount > 0)
        {
            spawntime--;
            if (spawntime <= 0)
            {
                int poz = Random.Range(1, 100);

                {
                    if (poz <= 50)
                    {

                        GameObject _enemy = Instantiate(enemy, stanga.position, Quaternion.identity);
                        _enemy.tag = "Enemy";
                        _enemy.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y, 0);
                    }
                    else
                    {

                        GameObject _enemy = Instantiate(enemy, dreapta.position, Quaternion.identity);
                        _enemy.tag = "Enemy";
                        _enemy.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y, 0);
                    }
                    enemyCount--;
                }
                spawntime = 1000f;
            }
        }
        else
        {
            
            
            cooldown--;
            if (cooldown <= 0)
            {
                wave++;
                enemyCount = 5 * wave * stage;
                cooldown = 5000f;
                if (wave == 5)
                {

                    wave = 1;
                    stage++;
                }
            }
        }
   
    }
 
    
}
