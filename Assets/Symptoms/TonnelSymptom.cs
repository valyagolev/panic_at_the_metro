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
            return "tonnels are scary af";
        }
    }

    void Update()
    {
        if (transform.position.y < -2.5)
        {
            Debug.Log("trigger tonnel");
            TriggerDebounced(2);
        }
    }
}
