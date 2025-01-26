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

    float TransitionTime = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key_skip))
        {
            name = Name_Future;
            this.GetComponent<Animation_playing>().Playing_CLose();
            Invoke("LoadingScreen", TransitionTime);
        }


        if (Input.GetKeyDown(Key_o))
        {
            name = Name_Previos;
            this.GetComponent<Animation_playing>().Playing_CLose();
            Invoke("LoadingScreen", TransitionTime);
        }

        if (Input.GetKeyDown(key_M))
        {

        }


    }


    string name;
    public void LoadingScreen()
    {
        if (Name_Future == "") return;
        SceneManager.LoadScene(name);
    }
}
