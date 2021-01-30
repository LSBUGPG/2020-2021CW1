# Unity-Postprocess-Texture-Editor-Script-Tutorial.md
How to create a script that will turn all 2D images put into specific folder into sprites automatically

After starting up Unity, create a new folder called **Editors**, this is because the editor scripts **cannot be in the same folder as other scripts** as this will cause errors. After creating the folder open it and create a C# script and call it however you feel is the most applicable for what its intended purpose is. For this case, let's call it **SpriteProcessor**.

Next, open the script and delete the **start** and **update** functions as they are not needed. Then add in **using UnityEditor** at the top as the script will not work without it. Next write the following parenthesis below:


void OnPostprocessTexture(Texture2D texture)
    
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        bool isInSpriteDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;

        if (isInSpriteDirectory)
        {
            TextureImporter textureImporter = (TextureImporter) assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
        }
    }

When writing this script, **DO NOT WORRY** about having to write the folder containing your 2D sprites in lower case as the folder can still be called **Sprites**, but it will need to have its own space in the name if you are specifying such as **Enemy Armor Sprites**, **Ally Sprites** and so on.

When you have finished wtiting the parenthasis, the script is complete and you do not need to implement it to anything. It works automaticaly. So whenever you create a folder that contains the name Sprites in it, any 2D image you put in the folder automatically gets turned into a sprite asset so you no longer have to turn it into a sprite asset manually.
