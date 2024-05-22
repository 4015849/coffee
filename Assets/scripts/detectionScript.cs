using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = enemy.GetComponent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == enemyScript.playerHitbox)
        {
            enemyScript.canAreaAttack = true;
        }
    }
}
