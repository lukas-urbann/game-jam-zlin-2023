using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Controller : MonoBehaviour
{
    public GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        level.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //While player movement is true, the level moves in cycles
    }
}
