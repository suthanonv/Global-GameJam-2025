using System.Collections;
using UnityEngine;

public class imageshake : MonoBehaviour
{
    [SerializeField] Transform ObjectT;
    [SerializeField] float number;
    [SerializeField] float delay;

    private void Start()
    {
        StartCoroutine(bruh());
    }

    IEnumerator bruh()
    {
        yield return new WaitForSeconds(delay);
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, number));
        StartCoroutine(bruh());
    }
}
