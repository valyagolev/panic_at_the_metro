using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSymptom : BaseSymptomBehaviour
{


    public override string Description()
    {
        if (good)
        {
            return "people calm you down";
        }
        else
        {
            return "people scare you";
        }
    }
}
