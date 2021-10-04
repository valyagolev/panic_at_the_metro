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

    void OnTriggerEnter2D(Collider2D collider)
    {
        var i = collider.GetComponent<Item>();
        if (i.itemName == item)
        {
            Trigger();
            Destroy(collider.gameObject);
        }
    }
}
