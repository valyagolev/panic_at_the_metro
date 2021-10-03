using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    public float lifeSpan = 1;

    float created;
    // Start is called before the first frame update
    void Start()
    {
        created = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - created > lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
