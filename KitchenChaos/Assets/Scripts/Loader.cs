using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    #region FIELDS
    public enum Scene
    {
        MainMenuScene,
        LoadingScene,
        GameScene,
    }

    private static Scene _sceneToLoad;
    #endregion

    #region FUNCTIONS
    public static void Load(Scene scene)
    {
        Loader._sceneToLoad = scene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_sceneToLoad.ToString());
    }
    #endregion
}
