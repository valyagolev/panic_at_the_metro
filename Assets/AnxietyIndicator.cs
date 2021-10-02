using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyIndicator : MonoBehaviour
{
    private Anxiety anxiety;
    private RectTransform rectTransform;
    private float maxWidth;
    // Start is called before the first frame update
    void Start()
    {
        anxiety = GameObject.Find("Player").GetComponent<Anxiety>();
        rectTransform = GetComponent<RectTransform>();
        maxWidth = transform.parent.GetComponent<RectTransform>().rect.width;
        Debug.Log(maxWidth);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(anxiety.AsProportion);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, anxiety.AsProportion * maxWidth);
    }
}
