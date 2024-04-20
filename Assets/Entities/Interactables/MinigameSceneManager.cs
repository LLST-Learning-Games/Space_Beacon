
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSceneManager : MonoBehaviour
{
    public bool IsMinigameLoaded { get; private set; }

    public void RequestSceneLoad(int index)
    {
        if (IsMinigameLoaded)
        {
            return;
        }

        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        IsMinigameLoaded = true;
    }

    public void RequestSceneUnload(int index)
    {
        SceneManager.UnloadSceneAsync(index);
        IsMinigameLoaded = false;
    }
}
