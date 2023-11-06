using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{

    public void LoadGame() {
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level0");
    }

}
