using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointAndClick.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;

        private Vector2 _targetPos;
        private bool _isMoving;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
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

                if (Vector2.Distance(pos2D, _targetPos) < _stopDistance)
                {
                    _isMoving = false;
                    _animator.SetTrigger("StartIdle");
                }
            }

        }
    }
}