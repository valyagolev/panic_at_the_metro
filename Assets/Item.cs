using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ItemSymptom s = collider.gameObject.GetComponents<ItemSymptom>()[0];

        Debug.Log(s);
        if (s)
        {
            s.Trigger();
            Destroy(gameObject);
        }
    }
}
