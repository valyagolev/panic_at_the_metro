using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public enum State
    {
        DoorsOpen,
        Moving
    };

    public State state = State.DoorsOpen;
    public int currentStop = 0;

    public float openDoorsFor = 3;
    public float moveSpeed = 0.04f;

    public float minX = -7.5f;
    public float maxX = 26.5f;

    public GameObject stops;
    public Transform stopDoor;

    Vector3[] path;
    // Vector3 stopOffset;

    GameObject openDoors, closedDoors;

    public int moveDirection = 1;

    float lastStateChange;

    // Start is called before the first frame update
    void Start()
    {
        openDoors = transform.Find("OpenDoors").gameObject;
        closedDoors = transform.Find("ClosedDoors").gameObject;

        Vector3 stopOffset = stopDoor.position - transform.position;
        path = stops.transform.Cast<Transform>().Select(t => t.position - stopOffset).ToArray();

    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.DoorsOpen:
                openDoors.SetActive(true);
                closedDoors.SetActive(false);

                if (lastStateChange < Time.time - openDoorsFor)
                {
                    state = State.Moving;
                    if (moveDirection > 0)
                    {
                        currentStop++;
                        if (currentStop >= path.Length)
                        {
                            currentStop = path.Length - 2;
                            moveDirection = -1;
                        }
                    }
                    else
                    {
                        currentStop--;
                        if (currentStop < 0)
                        {
                            currentStop = 1;
                            moveDirection = 1;
                        }
                    }

                }
                break;

            case State.Moving:
                openDoors.SetActive(false);
                closedDoors.SetActive(true);

                transform.Translate(moveDirection * moveSpeed, 0, 0);
                if (moveDirection == -1)
                {
                    if (transform.position.x <= path[currentStop].x)
                    {
                        state = State.DoorsOpen;
                        lastStateChange = Time.time;
                    }
                }
                else
                {
                    if (transform.position.x >= path[currentStop].x)
                    {
                        state = State.DoorsOpen;
                        lastStateChange = Time.time;
                    }
                }

                break;
        }
    }
}
