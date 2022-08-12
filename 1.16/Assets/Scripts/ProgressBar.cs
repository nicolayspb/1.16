using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public PlayerController player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float AcceptFinishPlayer = 1f;

    private float _startY;
    private float _minReachedY;

    private void Start()
    {
        _startY = player.transform.position.y;
    }

    private void Update()
    {
        _minReachedY = Mathf.Min(_minReachedY, player.transform.position.y);
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + AcceptFinishPlayer, _minReachedY);
        Slider.value = t;
    }
}
