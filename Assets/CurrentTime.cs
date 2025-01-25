using UnityEngine;
using TMPro;

public class CurrentTime : MonoBehaviour
{
    private TextMeshPro _TMP;
    private float _currentTime = 0;
    private void Start()
    {
        _TMP = GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        _TMP.text = _currentTime.ToString();
    }
}
