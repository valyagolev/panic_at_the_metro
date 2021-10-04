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
        // Debug.Log("Anxiety changed by" + f);
        value += f;
        value = Mathf.Clamp(value, 0, 100);

        if (f != 0 && animator)
        {
            animator.TriggerParticles(Mathf.Abs(f) >= 10, f < 0);
        }

        if (value >= 90)
        {
            Log.Write("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
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
        if (Random.Range(0, 300) == 0)
        {
            Change(1);
        }

        if (Random.Range(0, 20) == 0 && Random.Range(0, 100) < value)
        {
            GetComponent<Screamer>().Spawn();
        }
        if (Random.Range(0, 50000 / (value + 1)) == 0)
        {
            BaseSymptomBehaviour[] symptoms = GetComponent<Symptoms>().symptoms;
            int symptom = Random.Range(0, symptoms.Length);
            symptoms[symptom].good = !symptoms[symptom].good;
            symptoms[symptom].strength = Random.Range(1, 10);
        }
    }
}
