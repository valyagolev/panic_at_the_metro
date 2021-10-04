using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleToucher : MonoBehaviour
{
    public float sorryLength = 1;
    public float sorryRegenerate = 1; // how's it called lol?
    public float collisionRegenerate = 1; // how's it called lol?

    GameObject sorry;
    float lastSorry = -10;
    float lastCollision = -10;
    ContactFilter2D contactFilter = new ContactFilter2D();

    void Start()
    {
        contactFilter.SetLayerMask(LayerMask.GetMask("Mobs"));
        sorry = transform.Find("Sorry").gameObject;
    }

    bool IsSorry()
    {
        return lastSorry > Time.time - sorryLength;
    }

    void Update()
    {
        // Say sorry?
        if (Input.GetButtonDown("Sorry"))
        {
            if (lastSorry < Time.time - sorryLength - sorryRegenerate)
            {
                lastSorry = Time.time;
                Anxiety.OfPlayer.Change(1);
            }
        }

        sorry.gameObject.SetActive(IsSorry());

        if (lastCollision < Time.time - collisionRegenerate) {
        
            // Check Collisions with mobs
            Collider2D[] results = new Collider2D[1];

            if (GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, results) > 0)
            {
                lastCollision = Time.time;
                // Debug.Log("Collided");
                //Debug.Log(results[0].gameObject);

                if (!IsSorry())
                {
                    PeopleSymptom s = GetComponent<PeopleSymptom>();
                    s.Trigger();
                }
                } else {
                    PolitenessSymptom s = GetComponent<PolitenessSymptom>();
                    s.TriggerDebounced(3000);
                }
        }
    }

}
