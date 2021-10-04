using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public FreeSpaces spaces;
    public TrainSpaces trainSpaces;
    public GameObject itemPrefab, personPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // int count = spaces.allSpaces.Count;

        // we want like 5% items? and 10% people?
        Sprite[] items = GetComponent<ItemLibrary>().basicSprites;

        foreach (Vector3 s in spaces.allSpaces)
        {
            if (Random.Range(0, 20) == 0)
            {
                GameObject item = Instantiate(itemPrefab, s, Quaternion.identity);
                item.GetComponent<SpriteRenderer>().sprite = items[Random.Range(0, items.Length)];
            }
            else if (Random.Range(0, 10) == 0)
            {
                GameObject person = Instantiate(personPrefab, s, Quaternion.identity);
                person.GetComponent<MobAction>().speedModifier =
                    (Random.Range(0, 2) - 1) * Random.Range(0.7f, 1.3f);
                // person.GetComponent<MobAction>().direction = (MobAction.Direction)Random.Range(0, 2);
            }
        }

        foreach (Vector3 s in trainSpaces.allSpaces)
        {
            if (Random.Range(0, 10) == 0)
            {
                GameObject person = Instantiate(personPrefab, s, Quaternion.identity);
                person.GetComponent<MobAction>().speedModifier =
                    (Random.Range(0, 2) - 1) * Random.Range(0.7f, 1.3f);
                // person.GetComponent<MobAction>().direction = (MobAction.Direction)Random.Range(0, 2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Random.Range(0, 200) == 0) {

        // }
    }
}
