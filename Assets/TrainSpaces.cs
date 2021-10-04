using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrainSpaces : MonoBehaviour
{
    [HideInInspector]
    public List<Vector3> allSpaces = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "ClosedDoors" || child.name == "TrainFloor") continue;
            if (child.name == "OpenDoors")
            {
                foreach (Transform door in child)
                {
                    allSpaces.Add(door.position);
                }
                continue;
            }
            allSpaces.Add(child.position);
        }
    }

}
