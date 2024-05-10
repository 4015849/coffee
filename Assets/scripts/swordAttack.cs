using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    public GameObject enemyHitbox;
    public float swordDamage = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemyHitbox)
        {
            // deal damage to the enemy
            enemy enemy = collision.gameObject.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.health -= swordDamage;
                Debug.Log(enemy.health);
            }
        }
    }
}
