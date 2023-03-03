using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.position += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += new Vector3(1, 0, 0);
        }
    }
}
