using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary : MonoBehaviour
{
    public Sprite[] basicSprites;

    public string[] ItemNames()
    {
        return basicSprites.Select(s => s.name).ToArray();
    }


    // SINGLETON
    private static ItemLibrary _instance;

    public static ItemLibrary Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    // /SINGLETON
}
