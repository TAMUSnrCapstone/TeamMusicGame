using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public class ControlTestsGood
{

    private Scene scene;

    [SetUp]
    public void LoadMain()
    {
        scene = EditorSceneManager.OpenScene("Assets/Scenes/Main menu.unity", OpenSceneMode.Single);
    }

    [Test]
    public void CheckMainMenu()
    {
        GameObject obj = GameObject.Find("Controller");
        var script = obj.GetComponent<Control>();
        Assert.AreEqual(scene.name , "Main menu");
    }

    [Test]
    public void CheckMainMenuForKeyboard()
    {
        GameObject obj = GameObject.Find("Keyboard");
        Assert.AreEqual(obj.name, "Keyboard");
    }

    [Test]
    public void CheckMainMenuForSoundBanks()
    {
        GameObject obj = GameObject.Find("TriggeredSoundBanks");
        Assert.AreEqual(obj.name, "TriggeredSoundBanks");
        obj = GameObject.Find("triggeredSounds");
        Assert.AreEqual(obj.name, "triggeredSounds");
    }


}
