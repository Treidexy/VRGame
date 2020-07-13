using UnityEngine;

class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public static bool countGVRClick = true;

    public void ChangeGVRClick(bool countGVR) => countGVRClick = countGVR;

    public void Exit() => Application.Quit();
}
