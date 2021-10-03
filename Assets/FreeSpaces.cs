using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FreeSpaces : MonoBehaviour
{
    [HideInInspector]
    public List<Vector3> allSpaces = new List<Vector3>();
    [HideInInspector]
    public List<Vector3> freeSpaces = new List<Vector3>();

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        Vector3 offsetOnTop = new Vector3(tilemap.cellSize.x / 2, tilemap.cellSize.y * 1.5f, 0);

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {

            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            if (tilemap.GetTile(localPlace)?.name == "asphalt")
            {
                Vector3 place = tilemap.CellToWorld(localPlace) + offsetOnTop;
                allSpaces.Add(place);
            }
        }

        freeSpaces = new List<Vector3>(allSpaces);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
