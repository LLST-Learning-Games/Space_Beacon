using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _highlightedSpriteRenderer;
    [SerializeField] private GameObject _walkToPosition;
    [SerializeField] private int _minigameSceneIndex;
    [SerializeField] private MinigameSceneManager _sceneManager;

    private Color _startingColor;
    private Color _highlightColor = Color.yellow;
    private bool _interactionActive = false;

    public Vector3 WalkToPosition => _walkToPosition.transform.position;

    private void Start()
    {
        _startingColor = _highlightedSpriteRenderer.color;    
        if(_sceneManager is null)
        {
            FindMinigameSceneManager();
        }
    }

    [ContextMenu("Find Minigame Scene Manager")]
    private void FindMinigameSceneManager()
    {
        _sceneManager = FindFirstObjectByType<MinigameSceneManager>();
    }

    private void Reset()
    {
        FindMinigameSceneManager();
    }

    public void OnInteractionBegin()
    {
        _interactionActive = true;
        _highlightedSpriteRenderer.color = _highlightColor;
    }

    public void OnInteractionExecute()
    {
        Debug.Log("You've arrived at your interactable!");
        _highlightedSpriteRenderer.color = _startingColor;
        _interactionActive = false;
        _highlightedSpriteRenderer.enabled = false;
        _sceneManager.RequestSceneLoad(_minigameSceneIndex);
    }    

    public void OnInteractionAbandoned()
    {
        Debug.Log("You've abandonded your interactable!");
        _highlightedSpriteRenderer.color = _startingColor;
        _interactionActive = false;
        _highlightedSpriteRenderer.enabled = false;
    }

    private void OnMouseEnter()
    {
        _highlightedSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        if (!_interactionActive)
        {
            _highlightedSpriteRenderer.enabled = false;
        }
    }

}
