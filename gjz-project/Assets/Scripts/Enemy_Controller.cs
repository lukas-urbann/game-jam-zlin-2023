using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public GameObject enemy;
    
    public Vector3 startPosition;
    public Vector3 endPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // This is the code that moves the enemy from the start position to the end position while the player is moving
    }
}
