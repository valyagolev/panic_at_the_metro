using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    public Vector2 accel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        collider.GetComponent<Rigidbody2D>().AddForce(accel);
    }
}
