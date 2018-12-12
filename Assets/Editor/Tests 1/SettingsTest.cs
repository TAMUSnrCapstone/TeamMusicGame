using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public class SeetingsTest
{

    private Scene scene;

    [SetUp]
    public void LoadLevel()
    {
        scene = EditorSceneManager.OpenScene("Assets/Scenes/SettingsScreen.unity", OpenSceneMode.Single);
    }

    [Test]
    public void CheckSettingsScreen()
    {
        GameObject obj = GameObject.Find("Controller");
        var script = obj.GetComponent<Control>();
        Assert.AreEqual(scene.name, "SettingsScreen");
        Assert.NotNull(script);
    }

    [Test]
    public void CheckSettingsScreenForSlider()
    {
        GameObject obj = GameObject.Find("Slider");
        Assert.NotNull(obj);
    }

    [Test]
    public void CheckSettingsScreenForBackButton()
    {
        GameObject obj = GameObject.Find("Back");
        Assert.NotNull(obj);
    }



}
