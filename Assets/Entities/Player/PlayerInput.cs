using UnityEngine;
using System.Linq;
using Pathfinding;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Player {
	public class PlayerInput : MonoBehaviour {
        [SerializeField] private Transform _movementTarget;
		[SerializeField] private AILerp _playerAi;
        [SerializeField] private MinigameSceneManager _sceneManager;

        private Camera _cam;
		private InteractableController _currentInteractable;

        [ContextMenu("Find Minigame Scene Manager")]
        private void FindMinigameSceneManager()
        {
            _sceneManager = FindFirstObjectByType<MinigameSceneManager>();
        }

        private void Reset()
        {
            FindMinigameSceneManager();
        }

        public void Start () {
			_cam = Camera.main;
		}


		void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                if (_sceneManager.IsMinigameLoaded  // block input if minigame is loaded - todo - probably should exit if we're clicking off the UI
                    || EventSystem.current.IsPointerOverGameObject()    // early exit if over UI
                    )
                {
                    return;     
                }

                Vector3 newPosition = _cam.ScreenToWorldPoint(Input.mousePosition);

                var hit = Physics2D.Raycast(newPosition, Vector2.zero);
                if (hit && hit.collider.gameObject.layer == 6)
                {
                    _currentInteractable = hit.collider.gameObject.GetComponent<InteractableController>();
                    _currentInteractable.OnInteractionBegin();

                    //todo - this is hack, and it also doesn't work. Sort out why the distance calcuation is failing
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                    if (Vector3.Distance(_currentInteractable.WalkToPosition, transform.position) > Mathf.Epsilon)
                    {
                        UpdateTargetPosition(_currentInteractable.WalkToPosition);
                        _playerAi.OnDestinationReached += OnDestinationReached;
                    }
                    else
                    {
                        OnDestinationReached();
                    }
                    return;
                }

                if (hit && hit.collider.gameObject.layer == 7) 
                {
                    var conversationStarter = hit.collider.gameObject.GetComponent<ConversationStarter>();
                    conversationStarter.StartConversation();
                    return;
                }

                if (!hit || hit && hit.collider.gameObject.layer == 3)
                {
                    CancelInteraction();

                    UpdateTargetPosition(newPosition);
                }
            }
        }

        private void CancelInteraction()
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.OnInteractionAbandoned();
                _playerAi.OnDestinationReached -= OnDestinationReached;
                _currentInteractable = null;
            }
        }

        private void OnDestinationReached()
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.OnInteractionExecute();
                _playerAi.OnDestinationReached -= OnDestinationReached;
                _currentInteractable = null;
            }
        }

        public void UpdateTargetPosition (Vector3 newPosition) {

            newPosition.z = 0f;
            if (newPosition != _movementTarget.position) {
				_movementTarget.position = newPosition;
                _playerAi.SearchPath();
			}
		}
	}
}
