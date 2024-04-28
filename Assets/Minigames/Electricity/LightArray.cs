using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightArray : MonoBehaviour
{
    [SerializeField] private List<Image> _lights;
    [SerializeField] private Color _litColor = Color.yellow;

    public Action OnAllLightsLit;

    private int _nextLitIndex = 0;

    public void TurnOnNextLight()
    {
        if (_nextLitIndex >= _lights.Count)
        {
            OnAllLightsLit?.Invoke();
            return;
        }

        _lights[_nextLitIndex].color = _litColor;
        _nextLitIndex++;
    }
}
