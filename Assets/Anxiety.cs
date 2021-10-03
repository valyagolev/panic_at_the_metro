using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anxiety : MonoBehaviour
{
    public int value = 10;

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
    }

    void Start()
    {

    }

    // 50 times/sec
    void FixedUpdate()
    {
        if (Random.Range(0, 100) == 0)
        {
            Change(-1);
        }
    }
}
