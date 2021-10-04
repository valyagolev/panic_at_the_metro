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
        if (!known)
        {
            if (Random.Range(0, 5) == 0)
            {
                known = true;
                Log.Write("You realise that " + Description());
            }
            else
            {
                if (good)
                {
                    Log.Write("You feel calmer for some reason");
                }
                else
                {
                    Log.Write("You feel worried for some reason");
                }
            }
        }

        GetComponent<Anxiety>().Change((good ? -1 : 1) * strength);
    }
}
