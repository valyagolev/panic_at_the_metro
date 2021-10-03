using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreParentScale : MonoBehaviour
{
    Vector3 originalParentScale, originalScale;

    void Start()
    {
        originalParentScale = transform.parent.localScale;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // globalScale = parentScale * localScale;
        // globalScale = parentScale' * ( (1/parentScale') * parentScale * localScale );
        transform.localScale = Vector3.Scale(originalScale,
            new Vector3(
                originalParentScale.x / transform.parent.localScale.x,
                originalParentScale.y / transform.parent.localScale.y,
                originalParentScale.z / transform.parent.localScale.z));
    }
}
