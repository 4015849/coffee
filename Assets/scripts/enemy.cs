using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 1;
    public CinemachineVirtualCamera cam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Defeated();
        }
    }
    public void Defeated()
    {
        gameObject.SetActive(false);
        cam.m_Priority = 2;
        Debug.Log("defeated");
    }
}
