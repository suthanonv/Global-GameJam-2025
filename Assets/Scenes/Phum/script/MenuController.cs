using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform tablePosition;
    public float zoomSpeed = 2f;
    public GameObject stageSelectionUI;
    private bool isZooming = false;

    void Update()
    {
        if (Input.anyKeyDown && !isZooming)
        {
            StartZoom();
        }
    }

    void StartZoom()
    {
        isZooming = true;
        StartCoroutine(ZoomToTable());
    }

    IEnumerator ZoomToTable()
    {
        while (Vector3.Distance(mainCamera.transform.position, tablePosition.position) > 0.1f)
        {
            mainCamera.transform.position = Vector3.Lerp(
                mainCamera.transform.position,
                tablePosition.position,
                Time.deltaTime * zoomSpeed
            );
            yield return null;
        }

        mainCamera.transform.position = tablePosition.position;
        stageSelectionUI.SetActive(true);
    }
}
