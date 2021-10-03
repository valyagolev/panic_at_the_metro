using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSymptom : BaseSymptomBehaviour
{
    public string item;

    public override string Description()
    {
        if (good)
        {
            return "you love " + item;
        }
        else
        {
            return "you hate " + item;
        }
    }
}
