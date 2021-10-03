using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public FreeSpaces spaces;
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
                GameObject item = Instantiate(personPrefab, s, Quaternion.identity);
                // item.GetComponent<SpriteRenderer>().sprite = items[Random.Range(0, items.Length)];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
