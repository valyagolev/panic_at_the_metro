using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainFloorAttachFollow : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        TrainFollow t = collider.gameObject.AddComponent<TrainFollow>();
        t.train = transform;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(collider.gameObject.GetComponent<TrainFollow>());
    }
}
