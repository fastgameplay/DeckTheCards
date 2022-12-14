using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardImageDownloader : MonoBehaviour
{
    [SerializeField] Image _cardImage;

    void Start(){
        UpdateImage();
    }
    void UpdateImage(){
        if(_cardImage == null){
            Debug.LogWarning("_cardImage is null!");
            return;
        }
        StartCoroutine(IEGetCardImage("https://picsum.photos/256"));
    }
    IEnumerator IEGetCardImage(string url){
        UnityWebRequest reg = UnityWebRequestTexture.GetTexture(url);
        yield return reg.SendWebRequest();

        if(reg.result == UnityWebRequest.Result.ConnectionError || reg.result == UnityWebRequest.Result.ProtocolError){
            Debug.LogWarning(reg.error);
        }
        else{
            Texture2D img = ((DownloadHandlerTexture)reg.downloadHandler).texture;
            _cardImage.sprite = Sprite.Create(img, new Rect(0,0,256,256), Vector2.zero);
        }
    }
}
