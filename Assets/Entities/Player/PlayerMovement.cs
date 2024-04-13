using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;

    private Vector2 _targetPos;
    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _targetPos = mousePos;
            _isMoving = true;
            _animator.SetTrigger("StartWalk");
        }

        if (_isMoving)
        {
            var pos2D = new Vector2(transform.position.x, transform.position.y);
            var direction = _targetPos - pos2D;
            var movement = direction.normalized * _speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y);
            _sprite.flipX = direction.x < 0;

            if(Vector2.Distance(pos2D,_targetPos) < _stopDistance)
            {
                _isMoving = false;
                _animator.SetTrigger("StartIdle");
            }
        }

        //var movement = Vector2.zero;
        //if (Input.GetKey(KeyCode.A))
        //{
        //    movement.x = transform.position.x + _speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    movement.x = transform.position.x - _speed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    movement.y = transform.position.y - _speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    movement.y = transform.position.y + _speed * Time.deltaTime;
        //}
        //if(movement != Vector2.zero)
        //{
        //    _animator.SetTrigger("StartWalk");
        //    transform.position = movement;
        //}
        //else
        //{
        //    _animator.SetTrigger("StartIdle");
        //}
    }
}
