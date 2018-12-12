using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class LevelThreeTest
{

    private Scene scene;

    [SetUp]
    public void LoadSampleScene2()
    {
        scene = EditorSceneManager.OpenScene("Assets/Scenes/SampleScene2.unity", OpenSceneMode.Single);
    }

    [Test]
    public void CheckSampleScene()
    {
        Assert.AreEqual(scene.name, "SampleScene2");
    }

    [Test]
    public void CheckSampleSceneForEnemyManager()
    {
        GameObject obj = GameObject.Find("EnemyManager");
        var script = obj.GetComponent<EnemyManager>();
        Assert.NotNull(script);
    }

    [Test]
    public void CheckSampleSceneForProgressBar()
    {
        GameObject obj = GameObject.Find("topper bar");
        var script = obj.GetComponent<progress_bar>();
        Assert.NotNull(script);
    }

    [Test]
    public void CheckSampleSceneForSidePanel()
    {
        GameObject obj = GameObject.Find("Score Label");
        Assert.NotNull(obj);
        obj = GameObject.Find("ScoreText");
        Assert.NotNull(obj);
        obj = GameObject.Find("StatusText");
        Assert.NotNull(obj);
        obj = GameObject.Find("FleeceButton");
        Assert.NotNull(obj);
        obj = GameObject.Find("SandalButton");
        Assert.NotNull(obj);
        obj = GameObject.Find("BeatCoinText");
        Assert.NotNull(obj);
    }

}