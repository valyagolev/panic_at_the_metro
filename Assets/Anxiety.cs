using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anxiety : MonoBehaviour
{
    public int value = 10;

    ParticlesAnimator animator;

    public float AsProportion
    {
        get
        {
            return value / 100.0f;
        }
    }

    public static Anxiety OfPlayer
    {
        get
        {
            return GameObject.Find("Player").GetComponent<Anxiety>();
        }
    }

    public void Change(int f)
    {
        value += f;
        value = Mathf.Clamp(value, 0, 100);

        if (f != 0 && animator)
        {
            animator.TriggerParticles(Mathf.Abs(f) >= 10, f < 0);
        }
    }

    void Start()
    {
        animator = GetComponent<ParticlesAnimator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Change(50);
        }
        if (Input.GetKeyDown("e"))
        {
            Change(-50);
        }
    }

    // 50 times/sec
    void FixedUpdate()
    {
        if (Random.Range(0, 100) == 0)
        {
            Change(-1);
        }

        if (Random.Range(0, 20) == 0 && Random.Range(0, 100) < value)
        {
            GetComponent<Screamer>().Spawn();
        }
    }
}
