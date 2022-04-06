﻿using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Redcode.ScriptsGenerator
{
    internal class ModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            path = path.Substring(0, path.Length - ".meta".Length).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            if (Path.GetExtension(path) != ".cs")
                return;

            var fullpath = Path.Combine(Path.GetDirectoryName(Application.dataPath), path);
            var template = File.ReadAllText(fullpath);

            path = path.Substring(path.IndexOf(Path.DirectorySeparatorChar) + 1);

            var index = path.LastIndexOf(Path.DirectorySeparatorChar);
            path = index == -1 ? string.Empty : path.Substring(0, index);

            index = path.LastIndexOf("Scripts");

            if (index != -1)
            {
                if ((index == 0 || path[index - 1] == Path.DirectorySeparatorChar) && (index + "Scripts".Length == path.Length || path[index + "Scripts".Length] == Path.DirectorySeparatorChar))
                    path = index + "Scripts".Length == path.Length ? string.Empty : path.Substring(index + "Scripts".Length + 1);
            }

            path = path.Replace(Path.DirectorySeparatorChar, '.');

            var @namespace = (path == string.Empty ? Application.productName : $"{Application.productName}.{path}").Replace(" ", "");
            template = template.Replace("#NAMESPACE#", @namespace);

            File.WriteAllText(fullpath, template);

            AssetDatabase.Refresh();
        }
    }
}
#endif