using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
    BoxCollider2D hitbox;
    public AttackDirection attackDirection;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum AttackDirection
    {
        left, right, up, down
    }

    public void Awake()
    {
        switch(attackDirection)
        {
            case AttackDirection.left:
                attackLeft();
                break;
            case AttackDirection.right: 
                attackRight();
                break;
            case AttackDirection.up: 
                attackUp();
                break;
            case AttackDirection.down:
                attackDown();
                break;
        }
    }

    void attackDown()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.57f, .35f);
        hitbox.transform.position = new Vector2(.018f, -.22f);
        Debug.Log("attack down");
    }

    void attackUp()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.55f, .35f);
        hitbox.transform.position = new Vector2(.006f, .12f);
        Debug.Log("attack up");
    }

    void attackRight()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.31f, .18f);
        hitbox.transform.position = new Vector2(.166f, -.04f);
        Debug.Log("attack right");
    }

    void attackLeft()
    {
        hitbox.enabled = true;
        hitbox.size = new Vector2(.31f, .18f);
        hitbox.transform.position = new Vector2(-.176f, -.049f);
        Debug.Log("attack left");
    }

    void stopAttack()
    {
        hitbox.enabled = false;
    }
}
