using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CameraManager CameraManager;
    public PlayerManager PlayerManager;

    private void Awake()
    {
        Instance = this;
    }
}
