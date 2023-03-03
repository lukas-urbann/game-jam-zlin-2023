using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class Anchor : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        private void Update()
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x, 2 * Time.deltaTime), Mathf.Lerp(transform.position.y, target.transform.position.y, 2 * Time.deltaTime), Mathf.Lerp(transform.position.z, target.transform.position.z, 2 * Time.deltaTime));
        }
    }
}
