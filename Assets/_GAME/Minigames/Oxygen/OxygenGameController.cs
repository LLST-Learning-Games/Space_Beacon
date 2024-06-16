using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenGameController : MonoBehaviour
{
    [SerializeField] private List<Image> _lights;
    [SerializeField] private Color _litColor = Color.cyan;
    [SerializeField] private float _electricityCost = 0.1f;
    [SerializeField] private float _oxygenProduced = 0.5f;

    private int _nextLitIndex = 0;

    private MinigameSceneManager _sceneManager;
    private WorldResource _oxygenSystem;
    private WorldResource _electricitySystem;

    void Start()
    {
        _sceneManager = FindFirstObjectByType<MinigameSceneManager>();
        var shipSystemManager = FindAnyObjectByType<WorldResourceManager>();
        _oxygenSystem = shipSystemManager.GetResourceByName("Oxygen");
        _electricitySystem = shipSystemManager.GetResourceByName("Electricity");

    }

    public void LightNextLight()
    {
        if(_electricitySystem.GetResourceAmount < _electricityCost)
        {
            return;
        }

        if (_nextLitIndex >= _lights.Count)
        {
            _oxygenSystem.AddResource(_oxygenProduced);
            _electricitySystem.RemoveResource(_electricityCost);

            _sceneManager.RequestSceneUnload(1);
            return;
        }

        _lights[_nextLitIndex].color= _litColor;
        _nextLitIndex++;
    }
}
