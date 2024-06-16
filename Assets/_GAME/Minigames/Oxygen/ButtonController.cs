using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private float _timeToActivate;
    [SerializeField] private bool _startActivationTimerOnLoad;
    [SerializeField] private Color _activeColor = Color.green;
    [SerializeField] private Color _timerColor = Color.gray;
    [SerializeField] private Color _inactiveColor = Color.red;
    [SerializeField] private Image _image;
    [SerializeField] private ButtonController _otherButton;
    [SerializeField] private OxygenGameController _lights;

    private float _timeOnTimer = -1f; 
    private bool _isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        if (_startActivationTimerOnLoad)
        {
            _timeOnTimer = _timeToActivate;
        }
        else
        {
            _image.color = _inactiveColor;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeOnTimer >= 0.0f)
        {
            _timeOnTimer -= Time.deltaTime;
            _image.color = Color.Lerp(_timerColor, _activeColor, (1-_timeOnTimer / _timeToActivate));
            if (_timeOnTimer <= 0.0f)
            {
                _isActive = true;
            }
        }
    }

    public void OnClick()
    {
        if(_isActive)
        {
            _isActive = false;
            _image.color = _inactiveColor;
            _otherButton.StartTimer();
            _lights.LightNextLight();
        }
    }

    public void StartTimer()
    {
        _timeOnTimer = _timeToActivate;
        _image.color = _timerColor;
    }
}
