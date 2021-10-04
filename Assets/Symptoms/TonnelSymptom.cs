using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonnelSymptom : BaseSymptomBehaviour
{
    public override string Description()
    {
        if (good)
        {
            return "tonnels remind you of home";
        }
        else
        {
            return "tonnels as scary af";
        }
    }

    void Update()
    {
        if (transform.position.y < 0.2)
        {
            TriggerDebounced(2000);
        }
    }
}
