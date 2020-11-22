using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BottonSpawner : MonoBehaviour
{
    SpriteRenderer sprite;
    Sprite[] sprites;
    public Transform container;
    RawImage image;
    public GameObject prefab;
    public GameObject removeButton;
    public static string partsName;
    public static string[] URIs;
    public static bool maskFlg = false;


    public void LoadParts()
    {

        image = prefab.GetComponentInChildren<RawImage>();

        string[] files = ReadSpriteFiles();

        Debug.Log("PartsName =" + BottonSpawner.partsName);
        foreach (string filename in files)
        {
            StartCoroutine(hoge(filename));
        }
        GameObject blank = Instantiate(removeButton, Vector3.zero, Quaternion.identity);
        blank.transform.SetParent(container);
        blank.transform.localScale = new Vector3(1, 1, 1);
    }

    public void DestroyButton()
    {
        foreach (Transform button in container)
        {
            Destroy(button.gameObject);
        }
    }

    IEnumerator hoge(string filename)
    {
        Debug.Log("dataPath : " + filename);
        UnityWebRequest spriteTexture = UnityWebRequestTexture.GetTexture(filename);
        Debug.Log("処理してる:" + filename);
        yield return spriteTexture.SendWebRequest();

        if (spriteTexture.isNetworkError)
        {
//            Debug.LogError(filename);
        }
        else
        {

            GameObject button = this.prefab;
            Texture spriteTex = ((DownloadHandlerTexture)spriteTexture.downloadHandler).texture;
            if (spriteTex == null)
            {
                yield break;
            }
            else
            {
                image.texture = spriteTex;
                GameObject buttonElement;
                buttonElement = Instantiate(button, Vector3.zero, Quaternion.identity);
                if (maskFlg)
                {
                    string maskBuffer = filename.Insert(filename.LastIndexOf("\\"), "/mask");
                    string maskPath = maskBuffer.Insert(maskBuffer.LastIndexOf("."), "_マスク");
                    Debug.Log("fileName=" + maskPath);
                    if (File.Exists(maskPath))
                    {
                        yield return StartCoroutine(SetMaskToButton(maskPath, buttonElement));
                    }
                }
                buttonElement.transform.SetParent(container);
                buttonElement.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
    IEnumerator SetMaskToButton(string filename, GameObject contextButton)
    {

        Debug.Log("dataPath : " + filename);
        UnityWebRequest maskTexture = UnityWebRequestTexture.GetTexture(filename);
        Debug.Log("処理してる:" + filename);
        yield return maskTexture.SendWebRequest();

        if (maskTexture.isNetworkError)
        {
//            Debug.LogError(filename);
        }
        else
        {
            Texture maskTex = ((DownloadHandlerTexture)maskTexture.downloadHandler).texture;
            if (maskTex == null)
            {
                yield break;
            }
            else
            {
                contextButton.GetComponent<SpriteChanger>().maskTex = maskTex as Texture2D;

            }
        }
    }


    //string[] urlList;
    //while( (Application.dataPath + "*.png") != null )
    //{
    //
    //};
    //UnityWebRequestTexture.GetTexture();
    IEnumerator GetSpriteUri()
    {
        UnityWebRequest uri = UnityWebRequest.Get(Application.dataPath + "/Parts/" + partsName);
        yield return uri.SendWebRequest();
        string[] files = Directory.GetFiles(uri.downloadHandler.text, "*.png", SearchOption.TopDirectoryOnly);

        URIs = files;

    //    Debug.LogError(uri.downloadHandler.text);
    }

    string[] ReadSpriteFiles()
    {
        string path = Application.dataPath + "/Parts/" + partsName;
#if UNITY_STANDALONE_WIN
        string[] files = Directory.GetFiles(path, "*.png", SearchOption.TopDirectoryOnly);
        foreach (var file in files)
        {
//            Debug.LogError(file);
        }
        return files;
#endif

#if UNITY_WEBGL

        StartCoroutine(GetSpriteUri());
#endif

        return null;
    }

    public void fuga(string folderName)
    {
        partsName = folderName;
    }
}
