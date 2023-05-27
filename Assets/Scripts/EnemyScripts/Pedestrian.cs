using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    [SerializeField] private float pedSpeed;
    [SerializeField] private GameObject pedestrian;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pedestrian.transform.position += Vector3.up * pedSpeed * Time.deltaTime;
    }
}