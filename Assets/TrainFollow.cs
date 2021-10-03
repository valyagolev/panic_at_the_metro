using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainFollow : MonoBehaviour
{
    public Transform train;
    Vector3 trainLastPos;

    void Start()
    {
        trainLastPos = train.position;
    }

    void Update()
    {
        transform.position += train.position - trainLastPos;
        trainLastPos = train.position;
    }

}
