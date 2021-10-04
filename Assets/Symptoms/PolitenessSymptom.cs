using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolitenessSymptom : BaseSymptomBehaviour
{
    public override string Description()
    {
        if (good)
        {
            return "politeness is a nice virtue";
        }
        else
        {
            return "politeness is for losers";
        }
    }

    // void Update()
    // {
        
        
        
    // }
}
