using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSymptom : BaseSymptomBehaviour
{
    public override string Description()
    {
        if (good)
        {
            return "trains feel so cozy";
        }
        else
        {
            return "trains make you claustrophobic";
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "TrainFloor")
        {
            TriggerDebounced(1);
        }
    }
}
