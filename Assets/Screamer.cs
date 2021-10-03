using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using EasyButtons;

public class Screamer : MonoBehaviour
{
    public GameObject a;
    int size;
    int pixelsPerUnit;

    // Start is called before the first frame update
    void Start()
    {
        Rect spr = a.GetComponent<SpriteRenderer>().sprite.rect;
        size = Mathf.CeilToInt(Mathf.Max(spr.width, spr.height));

        pixelsPerUnit = Camera.main.GetComponent<PixelPerfectCamera>().assetsPPU;
    }

    [Button(Mode = ButtonMode.EnabledInPlayMode)]
    public void Spawn()
    {
        Vector3 closestPoint = Vector3Int.CeilToInt((transform.position + new Vector3(0.16f, 0.33f, 0)) * pixelsPerUnit / size);
        closestPoint += new Vector3(Random.Range(-2, 3), 0, 0);
        closestPoint.z = a.transform.position.z;

        GameObject newA = GameObject.Instantiate(a);
        newA.transform.position = closestPoint * size / pixelsPerUnit;
        newA.SetActive(true);
    }
}
