using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilePathInput : MonoBehaviour
{
    [SerializeField]
    string folderName;
    [SerializeField]
    bool maskFlg;
    Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = gameObject.name;
    }
    public void SetFolderName()
    {
        BottonSpawner.partsName = this.folderName;
        BottonSpawner.maskFlg = this.maskFlg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
