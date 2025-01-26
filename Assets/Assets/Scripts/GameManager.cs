using Assets.Assets.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CameraManager CameraManager;
    public PlayerManager PlayerManager;
    public UIManager UIManager;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        //fix for attach to unity issue
        if (Instance == null) 
            Instance = this;
    }
}
