using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private AILerp _aiLerp;
    private bool _isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        BindComponents();

        _aiLerp.OnDestinationReached += OnPathEnd;
        _aiLerp.onSearchPath += OnPathStarted;
    }

    [ContextMenu("Bind Components")]
    public void BindComponents()
    {
        if (_animator is null)
        {
            _animator = GetComponent<Animator>();
        }

        if (_aiLerp is null)
        {
            _aiLerp = GetComponent<AILerp>();
        }

        if(_sprite is null)
        {
            _sprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            if(_aiLerp.destination.x > transform.position.x)
            {
                _sprite.flipX = false;
            }
            else
            {
                _sprite.flipX = true;
            }
        }
    }

    private void OnPathStarted()
    {
        _animator.SetTrigger("StartWalk");
        _isMoving = true;
    }

    private void OnPathEnd()
    {
        _animator.SetTrigger("StartIdle");
        _isMoving = false;
    }
}
