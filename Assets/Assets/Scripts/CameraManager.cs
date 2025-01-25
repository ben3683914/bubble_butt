using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Camera MainCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position = GameManager.Instance.PlayerManager.Player.transform.position + new Vector3(0,0, MainCamera.transform.position.z);
    }
}
