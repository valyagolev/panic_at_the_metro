using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// doesn't work :)
public class FollowPath : MonoBehaviour
{

    public LineRenderer line;


    public float currentLocation = 0.0f;
    float[] offsets = null;

    void Start()
    {
        // Calculate line offsets
        Vector3[] positions = new Vector3[line.positionCount];
        line.GetPositions(positions);

        offsets = new float[line.positionCount];
        offsets[0] = 0.0f;
        for (int i = 1; i < line.positionCount; i++)
        {
            offsets[i] = offsets[i - 1] + Vector3.Distance(positions[i], positions[i - 1]);
        }

        // Put the object at the beginning
        transform.position = positions[0];
    }

    Vector3 PositionAt(float location)
    {
        int i = 0;
        while (location > 0 && i < offsets.Length)
        {
            location -= offsets[i];
            i++;
        }

        if (i == offsets.Length)
        {
            return line.GetPosition(line.positionCount - 1);
        }
        Vector3 prev = line.GetPosition(i - 1);
        Vector3 nxt = line.GetPosition(i);

        return prev + Vector3.Normalize(nxt - prev) * location;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Vector3.Distance(transform.position, PositionAt(currentLocation)) < 0.01f)
        // {
        //     currentLocation += 0.02f;
        // }

        // currentLocation += 0.001f;
        transform.position = PositionAt(currentLocation);
    }
}
