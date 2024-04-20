using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightArray : MonoBehaviour
{
    [SerializeField] private List<Image> _lights;
    [SerializeField] private Color _litColor = Color.cyan;

    private int _nextLitIndex = 0;

    private MinigameSceneManager _sceneManager;

    void Start()
    {
        _sceneManager = FindFirstObjectByType<MinigameSceneManager>();
    }

    public void LightNextLight()
    {

        if (_nextLitIndex >= _lights.Count)
        {
            _sceneManager.RequestSceneUnload(1);
            return;
        }

        _lights[_nextLitIndex].color= _litColor;
        _nextLitIndex++;
    }
}
