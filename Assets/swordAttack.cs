using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
    BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void attackDown()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.57f, .35f);
        hitbox.transform.position = new Vector2(.018f, -.22f);
    }

    void attackUp()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.55f, .35f);
        hitbox.transform.position = new Vector2(.006f, .12f);
    }

    void attackRight()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.31f, .18f);
        hitbox.transform.position = new Vector2(.166f, -.04f);
    }

    void attackLeft()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.31f, .18f);
        hitbox.transform.position = new Vector2(-.176f, -.049f);
    }

    void stopAttack()
    {
        hitbox.enabled = false;
    }
}
