using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public GameObject enemy;
    public enemy enemyScript;
    public GameObject player;
    public PlayerController playerScript;
    public Vector2 fireballStart;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = enemy.GetComponent<enemy>();
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        fireballStart = new Vector2(player.transform.position.x, 1);
        if(enemyScript.canMove == true)
        {
            StartCoroutine(fireballAttack());
        }
    }

    IEnumerator fireballAttack()
    {
        yield return new WaitForSeconds(3);
        GameObject clone;
        clone = Instantiate(gameObject);
        clone.transform.position = fireballStart;
        yield return new WaitForSeconds(1);
        Destroy(clone);
    }
}
