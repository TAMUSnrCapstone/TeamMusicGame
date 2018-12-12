using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public class LevelSelectTests
{

    private Scene scene;

    [SetUp]
    public void LoadLevelSelect()
    {
        scene = EditorSceneManager.OpenScene("Assets/Scenes/level select.unity", OpenSceneMode.Single);
    }

    [Test]
    public void CheckLevelSelect()
    {
        GameObject obj = GameObject.Find("Controller");
        var script = obj.GetComponent<Control>();
        Assert.AreEqual(scene.name, "level select");
    }

    [Test]
    public void CheckLevelSelectForScoreControl()
    {
        GameObject obj = GameObject.Find("ScoreController");
        Assert.AreEqual(obj.name, "ScoreController");
    }

    [Test]
    public void CheckLevelSelectForLevelOne()
    {
        GameObject obj = GameObject.Find("Level 1 High Score");
        Assert.AreEqual(obj.name, "Level 1 High Score");
    }

    [Test]
    public void CheckLevelSelectForLevelTwo()
    {
        GameObject obj = GameObject.Find("Level 2 High Score");
        Assert.AreEqual(obj.name, "Level 2 High Score");
    }

    [Test]
    public void CheckLevelSelectForLevelThree()
    {
        GameObject obj = GameObject.Find("Level 3 High Score");
        Assert.AreEqual(obj.name, "Level 3 High Score");
    }

}
