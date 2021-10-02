using System.Collections;
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

    public float openDoorsFor = 3;
    public float moveSpeed = 0.04f;

    public float minX = -7.5f;
    public float maxX = 26.5f;

    GameObject openDoors, closedDoors;

    float moveDirection;

    float lastStateChange;

    // Start is called before the first frame update
    void Start()
    {
        openDoors = transform.Find("OpenDoors").gameObject;
        closedDoors = transform.Find("ClosedDoors").gameObject;
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
                }
                break;

            case State.Moving:
                openDoors.SetActive(false);
                closedDoors.SetActive(true);

                transform.Translate(moveDirection * moveSpeed, 0, 0);
                if (moveDirection == -1)
                {
                    if (transform.position.x <= minX)
                    {
                        state = State.DoorsOpen;
                        moveDirection = 1;
                        lastStateChange = Time.time;
                    }
                }
                else
                {
                    if (transform.position.x >= maxX)
                    {
                        state = State.DoorsOpen;
                        moveDirection = -1;
                        lastStateChange = Time.time;
                    }
                }

                break;
        }
    }
}
