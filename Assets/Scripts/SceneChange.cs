using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LastScene()
    {
        SceneManager.LoadScene("Ending");
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToOutsideScene()
    {
        SceneManager.LoadScene("Outside");
    }

    public void ToPosterBoard()
    {
        SceneManager.LoadScene("Board");
    }

    public void ToBoss()
    {
        SceneManager.LoadScene("CactusBoss");
    }
}
