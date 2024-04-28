using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityGameDial : MonoBehaviour
{
    [SerializeField] private Image _dialImage;

    private Camera _cam;
    private bool _isMouseDown = false;

    private Vector3 _mousePosition = Vector3.zero;
    private Vector3 _dialCenterPos;

    private float _currentAngle;
    private float _lastAngle;

    public void Start()
    {
        _cam = Camera.main;
        _dialCenterPos = new Vector3(_dialImage.rectTransform.position.x, _dialImage.rectTransform.position.y, 0);
    }

    public void OnPointerDown()
    {
        Debug.Log("MouseDown");
        _isMouseDown = true;
    }
    public void OnPointerReleased()
    {
        Debug.Log("MouseUp");
        _isMouseDown = false;
    }

    private void Update()
    {
        if(_isMouseDown)
        {
            Vector3 relative = Input.mousePosition - _dialCenterPos; 
            _currentAngle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            _dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, -_currentAngle);
            
            if(_lastAngle > 100 && _currentAngle < -100)
            {
                Debug.Log("Did a spin!");
            }

            _lastAngle = _currentAngle;

            //Debug.Log("Mouse Pos " + Input.mousePosition);
            Debug.Log("Relative Mouse Pos " + relative);
            //Debug.Log("Dial pos " + _dialImage.rectTransform.position);
            Debug.Log("Start pos " + _dialCenterPos);
            Debug.Log("Angle " + _currentAngle);
        }
    }

}
