using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public class ItemShopTest
{

    private Scene scene;

    [SetUp]
    public void LoadLevel()
    {
        scene = EditorSceneManager.OpenScene("Assets/Scenes/ItemShop.unity", OpenSceneMode.Single);
    }

    [Test]
    public void CheckItemShop()
    {
        GameObject obj = GameObject.Find("Control_Items");
        var script = obj.GetComponent<Control>();
        Assert.AreEqual(scene.name, "ItemShop");
        Assert.NotNull(script);
    }

    [Test]
    public void CheckItemShopForAmbrosia()
    {
        GameObject obj = GameObject.Find("Ambrosia");
        Assert.NotNull(obj);
    }

    [Test]
    public void CheckItemShopForSandal()
    {
        GameObject obj = GameObject.Find("Hermes's Sandals");
        Assert.NotNull(obj);
    }

    [Test]
    public void CheckItemShopForFleece()
    {
        GameObject obj = GameObject.Find("Golden Fleece");
        Assert.NotNull(obj);
    }

    [Test]
    public void CheckItemShopForBack()
    {
        GameObject obj = GameObject.Find("BackButton_Yellow");
        Assert.NotNull(obj);
    }

    [Test]
    public void CheckItemShopForCoinDisplay()
    {
        GameObject obj = GameObject.Find("BeatCoinDisplay");
        Assert.NotNull(obj);
    }

}
