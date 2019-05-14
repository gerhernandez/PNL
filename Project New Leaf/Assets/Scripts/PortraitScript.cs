using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitScript : MonoBehaviour {

    public GameManager gameManager;
    public int resWidth;
    public int resHeight;

    private Camera portraitCamera;

    private void Awake()
    {
        portraitCamera = GetComponent<Camera>();
        StartCoroutine(TakeScreenShot());
    }

    private IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        portraitCamera.targetTexture = rt;
        Texture2D _screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        portraitCamera.Render();
        RenderTexture.active = rt;
        _screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        _screenShot.Apply();
        portraitCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        Sprite tempSprite = Sprite.Create(_screenShot, new Rect(0, 0, resWidth, resHeight), new Vector2(0, 0));

        //if(portraitCamera.name == "PlayerCamera")
        //{
        gameManager.SetPlayerPortrait(tempSprite);
        //}
        //else if(portraitCamera.name == "ParamourCamera")
        //{
        //    gameManager.SetParamourPortrait(tempSprite);
        //}

    }
}
