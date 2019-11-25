using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableSprite : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);

        Invoke("ChangeToMainMenu", 2);
    }

    private void ChangeToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
