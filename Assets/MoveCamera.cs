using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform tablePosition;
    bool _tf = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            _tf = true;
        }

        if (_tf && Vector3.Distance(transform.position, tablePosition.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, tablePosition.position, Time.deltaTime * 2);
            if (Vector3.Distance(transform.position, tablePosition.position) <= 0.1f)
            {
                _tf = false;
            }
        }
    }
}
