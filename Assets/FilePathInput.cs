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
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = gameObject.name;
        button = GetComponent<Button>();
    }
    public void SetFolderName()
    {
        BottonSpawner.partsName = this.folderName;
        BottonSpawner.maskFlg = this.maskFlg;
        if(!button.interactable)button.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
