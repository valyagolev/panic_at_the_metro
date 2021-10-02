using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class MobAction : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    // private bool m_Jump;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Character.Move(0.1f, false, false);
    }
}
