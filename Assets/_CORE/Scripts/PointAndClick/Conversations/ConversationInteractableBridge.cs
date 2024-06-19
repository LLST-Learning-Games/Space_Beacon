using PointAndClick.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class ConversationInteractableBridge : BaseInteractableBridge
{
    [SerializeField] private DialogueRunner _dialogueRunner;
    [SerializeField] private string _conversationId = "Start";

    private void Start()
    {
        if (_dialogueRunner is null)
        {
            FindDialogueRunner();
        }
    }

    [ContextMenu("Find Minigame Scene Manager")]
    private void FindDialogueRunner()
    {
        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();
    }
    private void Reset()
    {
        FindDialogueRunner();
    }

    public override void OnInteractionExecute()
    {
        _dialogueRunner.StartDialogue(_conversationId);
    }
}
