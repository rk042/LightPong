using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(COR_LoadMainScene());
    }

    private IEnumerator COR_LoadMainScene()
    {
        yield return new WaitForSeconds(3f);

        //change scene
        SceneManager.LoadScene(1);
    }   
}
