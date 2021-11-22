using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shadow : MonoBehaviour
{
    public SpriteRenderer castObject;
    public RenderTexture texture;
    Texture2D renderTextureToTexture2D()
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);

        return texture2D;
    }
    private void Update()
    {
        Texture2D tempTexture = renderTextureToTexture2D();
        castObject.sprite = Sprite.Create(tempTexture, new Rect(0, 0, tempTexture.width, tempTexture.height), Vector2.zero); ;    
    }
}
