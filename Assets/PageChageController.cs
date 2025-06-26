using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PageChageController : MonoBehaviour
{
    public void chageSceneIndex(int index)
    {
        GameObject.Find("ProductSelectionManager").GetComponent<ProductSelectionController>().ChangeSceneindex(index);
        AssetBundle.UnloadAllAssetBundles(true);
    }
}
