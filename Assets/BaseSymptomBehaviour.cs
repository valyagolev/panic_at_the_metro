using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSymptomBehaviour : MonoBehaviour
{
    abstract public string Description();
    public bool good;
    public bool known;
    public int strength = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Trigger()
    {
        known = true;
        GetComponent<Anxiety>().Change((good ? -1 : 1) * strength);
    }
}
