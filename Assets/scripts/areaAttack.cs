using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaAttack : MonoBehaviour
{
    public GameObject playerHitbox;
    public float areaDamage = 1;

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
        if (collision.gameObject == playerHitbox)
        {
            //deal damage to the player
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.health -= areaDamage;
                Debug.Log(player.health);
            }
        }
    }
}
