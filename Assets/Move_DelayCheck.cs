using UnityEngine;
using UnityEngine.Events;

public class Move_DelayCheck : MonoBehaviour
{
    public static Move_DelayCheck instance;

    public UnityEvent MovingCall = new UnityEvent();

    float CurrentCd;
    [SerializeField] float Cd;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && (PlayerInput.instance.Input_Direction() != Vector2.zero && CurrentCd <= 0))
        {
            MovingCall.Invoke();
            CurrentCd = Cd;
        }

        if (CurrentCd > 0)
        {
            CurrentCd -= Time.deltaTime;
        }
    }
}
