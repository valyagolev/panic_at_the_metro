using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAnimation : MonoBehaviour
{
    public float animationLength;
    public float animationStart;
    public float animationSpeed;
    public Transform[] particles;

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - animationStart;

        if (t > animationLength)
        {
            foreach (Transform tr in particles)
            {
                Destroy(tr.gameObject);
            }
            Destroy(this);
        }
        else
        {
            float dist = Time.deltaTime * animationSpeed;
            foreach (Transform tr in particles)
            {
                foreach (Transform particle in tr.GetComponentsInChildren<Transform>())
                {
                    Vector3 direction = particle.localPosition;
                    particle.Translate(direction * dist);
                }
            }
        }
    }
}
