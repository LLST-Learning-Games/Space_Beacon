using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private DialogueRunner _dialogueRunner;
    [SerializeField] private string _conversationId;

    public void StartConversation()
    {
        _dialogueRunner.StartDialogue(_conversationId);
    }
}
