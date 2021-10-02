using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridSnap : MonoBehaviour
{
    public Vector2Int pixelOffset = new Vector2Int(0, 0);
    public bool editorOnly = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (editorOnly && Application.IsPlaying(gameObject))
            return;

        Vector3 corrected = new Vector3(
            Mathf.Floor(transform.position.x - pixelOffset.x / 32f) + pixelOffset.x / 32f,
            Mathf.Floor(transform.position.y + pixelOffset.y / 32f) - pixelOffset.y / 32f, // 2 pixels
            0
        );

        if (corrected != this.transform.position)
        {
            this.transform.position = corrected;
        }
        this.transform.localScale = Vector3.one;

    }
}
