using UnityEngine;
using UnityEngine.Events;

public class Function_Ququreing : MonoBehaviour
{

    public static Function_Ququreing Instance;

    [SerializeField] float Timer = 0.1f;

    private void Awake()
    {
        Instance = this;
    }

    public UnityEvent QuqureingEvent = new UnityEvent();

    public UnityEvent FInish_move_Change_State = new UnityEvent();


    private void Start()
    {
        FInish_move_Change_State.AddListener(CountDown);
    }

    void CountDown()
    {
        Invoke("InvokeQuqureingEvent", Timer);
    }

    void InvokeQuqureingEvent()
    {
        FInish_move_Change_State.Invoke();
    }


}

