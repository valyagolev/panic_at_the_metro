using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSymptom : BaseSymptomBehaviour
{

    public override string Description()
    {
        if (good)
        {
            return "trains are good";
        }
        else
        {
            return "trains are claustrophobic";
        }
    }
}
