using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public class TutorialTest
{

    private Scene scene;

    [SetUp]
    public void LoadLevel()
    {
        scene = EditorSceneManager.OpenScene("Assets/Scenes/Tutorial.unity", OpenSceneMode.Single);
    }

    [Test]
    public void CheckSettingsScreen()
    {
        GameObject obj = GameObject.Find("Control");
        var script = obj.GetComponent<Control>();
        Assert.AreEqual(scene.name, "Tutorial");
        Assert.NotNull(script);
    }

 

}
