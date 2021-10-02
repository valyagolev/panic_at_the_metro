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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
