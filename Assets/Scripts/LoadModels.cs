using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadModels : MonoBehaviour
{
    
    
    [SerializeField]
    GameObject LoadingCanvas, MainCanvas;
    [SerializeField]
    Text PersentageText;
    [SerializeField]
    Slider ProgressSlider;

    
    

    [SerializeField]
    PlaceObjectsOnPlane placeObjectsOnPlane;

    
    bool clearCache = false;
    private GameObject placementARObject = null;
    private AssetBundle assetBundle = null;
    
    private string assetBundleLink = null;
    private string AssetName = null;

    private void GetAssetDetails()
    {
        
        assetBundleLink = GameObject.Find("ProductSelectionManager").GetComponent<ProductSelectionController>().productLink;
        AssetName = GameObject.Find("ProductSelectionManager").GetComponent<ProductSelectionController>().productName;
        
    }

    private void Awake()
    {
        GetAssetDetails();
        MainCanvas.SetActive(false);
        Caching.compressionEnabled = false;
        Caching.ClearCache();
        //if (clearCache)
        StartCoroutine(DownloadAndLoad());
        
    }
    private IEnumerator DownloadAndLoad()
    {
        while (!Caching.ready)
        {
            yield return null;
        }
        yield return GetBundle();
        if (!assetBundle)
        {
            Debug.Log("Bundle Failed to Load");
            yield break;
        }
        placementARObject = assetBundle.LoadAsset<GameObject>(AssetName);
        placeObjectsOnPlane.UpdateModel(placementARObject);
        

    }

    private IEnumerator GetBundle()
    {
        
        WWW request = WWW.LoadFromCacheOrDownload(assetBundleLink, 0);
        while (!request.isDone)
        {
            ProgressSlider.value = request.progress;
            string persentateTemp = "" + request.progress * 100;
            Debug.Log("" + request.progress * 100);
            string[] strArray = persentateTemp.Split(char.Parse("."));
            PersentageText.text = strArray[0] + "%";
            yield return null;
        }
        Debug.Log("" + request.progress * 100);
        if(request.error == null)
        {
            assetBundle = request.assetBundle;
            LoadingCanvas.SetActive(false);
            MainCanvas.SetActive(true);
            Debug.Log("Success!!!");
        }
        else
        {
            Debug.Log("Error"+request.error);
        }
        yield return null;
    }
}
