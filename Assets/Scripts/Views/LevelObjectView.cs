using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectView : MonoBehaviour
{
    public Transform Transform;
    public Collider2D Collider2D;
    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody2D;

    public Action<LevelObjectView> OnLevelObjectContact { get; set; }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
        OnLevelObjectContact?.Invoke(levelObject);
    }

}
