using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class MobAction : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;

    public enum Direction { Up, Down };
    public Direction direction;
    public float speedModifier = 1.0f;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Character.Move(speedModifier * 0.1f, false, false);
    }
}
