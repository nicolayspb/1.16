using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerController Player;
    public Vector3 PlatforfToCameraOffset;
    public float Speed;

    void Update()
    {
        if (Player.CurrentPlatform == false)
        {
            return;
        }

        Vector3 targetposition = Player.CurrentPlatform.transform.position + PlatforfToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position,targetposition,Speed*Time.deltaTime); 
    }
}
