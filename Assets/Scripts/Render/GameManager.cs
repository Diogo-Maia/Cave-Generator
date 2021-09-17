using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RawImage imageMap;
    [SerializeField] private InputField iWidth;
    [SerializeField] private InputField iHeight;
    [SerializeField] private Slider slider;

    private int[,] map;
    private int width;
    private int height;
    private GeneratorController gen;
    private Save save;
    private Texture2D texture;

    public void OnClick()
    {
        if(iWidth.text != "" && iHeight.text != "")
        {
            width = Convert.ToInt32(iWidth.text);
            height = Convert.ToInt32(iHeight.text);

            if(height > 0 && width > 0)
            {
                imageMap.rectTransform.sizeDelta = new Vector2(width, height);
                gen = new GeneratorController(width, height);

                map = gen.GenerateMap(slider.value);

                GenerateTexture();
            }
        }
    }

    private void GenerateTexture()
    {
        texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++)
            {
                texture.SetPixel(x, y, map[x, y] == 1 ? Color.black : Color.white);
            }
        }
        texture.Apply();

        imageMap.texture = texture;
    }

    public void OnSmoothClick()
    {
        if(texture != null)
        {
            map = gen.FormMap(map);

            GenerateTexture();
        }
        
    }

    public void OnSaveClick()
    {
        save = new Save();

        save.SaveTexure(texture, "generated.png");
    } 

}
