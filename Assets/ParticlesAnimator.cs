using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using System.Linq;

public class ParticlesAnimator : MonoBehaviour
{
    public float animationLength = 2;
    public float animationSpeed = 0.1f;
    public Sprite badPixel;
    public Sprite goodPixel;

    Transform fewParticles;
    Transform manyParticles;



    void Start()
    {
        fewParticles = transform.Find("ParticlesSmall");
        manyParticles = transform.Find("ParticlesMore");
    }

    [Button(Mode = ButtonMode.EnabledInPlayMode)]
    public void TriggerFewBadParticles()
    {
        TriggerParticles(false, false);
    }

    [Button(Mode = ButtonMode.EnabledInPlayMode)]
    public void TriggerManyGoodParticles()
    {
        TriggerParticles(true, true);
    }

    public void TriggerParticles(bool many, bool good)
    {
        // Create and save the particles
        Transform[] particles;

        Transform few = GameObject.Instantiate(fewParticles, transform);
        few.gameObject.SetActive(true);

        if (many)
        {
            Transform more = GameObject.Instantiate(manyParticles, transform);
            more.gameObject.SetActive(true);
            particles = new Transform[] { few, more };
        }
        else
        {
            particles = new Transform[] { few };
        }

        foreach (var R in particles.SelectMany(p => p.GetComponentsInChildren<SpriteRenderer>()))
        {
            R.sprite = good ? goodPixel : badPixel;
        }

        // Create the animation object
        ParticlesAnimation anim = gameObject.AddComponent<ParticlesAnimation>();
        anim.animationLength = animationLength;
        anim.animationSpeed = animationSpeed;
        anim.animationStart = Time.time;
        anim.particles = particles;
    }

}
