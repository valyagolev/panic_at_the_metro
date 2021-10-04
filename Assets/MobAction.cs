using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class MobAction : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;

    public enum Direction { Up, Down };
    public Direction direction;
    public float speedModifier = 1.0f;

    bool atTrainDoor = false;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Character.Move(speedModifier * 0.1f, false, Random.Range(0, atTrainDoor ? 50 : 400) == 0);
        if (Random.Range(0, 1000) == 0) speedModifier = -speedModifier;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log(gameObject.ToString() + " " + collider.gameObject.ToString());


        if (collider.transform.parent?.name == "OpenDoors")
        {
            Debug.Log("Doors enter");
            atTrainDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log(gameObject.ToString() + " " + collider.gameObject.ToString());


        if (collider.transform.parent?.name == "OpenDoors")
        {
            Debug.Log("Doors exit");
            atTrainDoor = false;
        }
    }
}
