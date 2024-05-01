using UnityEditor.AssetImporters;
using UnityEngine;
using System.IO;

[ScriptedImporter(1, "dat")]
public class DatImporter : ScriptedImporter {
    public override void OnImportAsset(AssetImportContext ctx) {
        TextAsset subAsset = new TextAsset(System.IO.File.ReadAllText(ctx.assetPath));
        ctx.AddObjectToAsset("text", subAsset);
        ctx.SetMainObject(subAsset);
    }
}
