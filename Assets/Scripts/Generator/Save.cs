using UnityEngine;

public class Save
{
    public void SaveTexure(Texture2D texture, string filename)
    {
        System.IO.File.WriteAllBytes(
            System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Desktop) + "/" + 
                filename, texture.EncodeToPNG()); 
    }
}
