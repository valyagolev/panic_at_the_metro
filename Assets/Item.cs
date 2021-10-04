using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    // Update is called once per frame
    void Start()
    {
        itemName = GetComponent<SpriteRenderer>().sprite.name;
    }


}
