using UnityEngine;
using UnityEngine.SceneManagement;

public class Skiping : MonoBehaviour
{
    [SerializeField] KeyCode Key_skip = KeyCode.O;
    [SerializeField] KeyCode Key_o = KeyCode.P;
    [SerializeField] KeyCode key_M = KeyCode.M;

    [SerializeField] string Name_Previos = "";
    [SerializeField] string Name_Future = "";
    [SerializeField] string name_lastTIle = "Cooked11";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key_skip))
        {

        }


        if (Input.GetKeyDown(Key_o))
        {

        }

        if (Input.GetKeyDown(key_M))
        {

        }


    }



    public void LoadingScreen(string name)
    {
        SceneManager.LoadScene(name);
    }
}
