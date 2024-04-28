using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinDial : MonoBehaviour
{
    [SerializeField] private Image _dialImage;

    public Action OnDialSpinComplete;

    private Camera _cam;
    private bool _isMouseDown = false;

    private Vector3 _mousePosition = Vector3.zero;
    private Vector3 _dialCenterPos;

    private float _angleOffset;
    private float _currentAngle;
    private float _lastAngle;

    public void Start()
    {
        _cam = Camera.main;
        _dialCenterPos = new Vector3(_dialImage.rectTransform.position.x, _dialImage.rectTransform.position.y, 0);
    }

    public void OnPointerDown()
    {
        //_angleOffset = GetCurrentAngle() - _dialImage.rectTransform.rotation.z;
        _isMouseDown = true;
    }
    public void OnPointerReleased()
    {
        _isMouseDown = false;
    }

    private void Update()
    {
        if(_isMouseDown)
        {
            _currentAngle = GetCurrentAngle() + _angleOffset;
            _dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, -_currentAngle);
            
            if(_lastAngle > 100 && _currentAngle < -100)
            {
                OnDialSpinComplete?.Invoke();
            }

            _lastAngle = _currentAngle;
        }
    }

    private float GetCurrentAngle()
    {
        Vector3 relative = Input.mousePosition - _dialCenterPos;
        return Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
    }

}
