using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectrictyGameController : MonoBehaviour
{
    [SerializeField] private SpinDial _dial;
    [SerializeField] private LightArray _lights;

    [SerializeField] private float _electricityChange = 0.3f;
    [SerializeField] private Button _chargeButton;

    private MinigameSceneManager _sceneManager;
    private WorldResource _electricitySystem;

    // Start is called before the first frame update
    void Start()
    {
        _sceneManager = FindFirstObjectByType<MinigameSceneManager>();
        var shipSystemManager = FindAnyObjectByType<WorldResourceManager>();
        _electricitySystem = shipSystemManager?.GetResourceByName("Electricity");

        _dial.OnDialSpinComplete += OnDialSpinComplete;
        _lights.OnAllLightsLit += OnAllLightsLit;
    }

    private void OnDialSpinComplete()
    {
        _lights.TurnOnNextLight();
    }

    private void OnAllLightsLit()
    {
        _chargeButton.interactable = true;
    }

    public void OnChargeButtonPressed()
    {
        _electricitySystem.AddResource(_electricityChange);

        _sceneManager.RequestSceneUnload(2);
        return;
    }

}
