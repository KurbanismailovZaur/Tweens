using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace Extensions.Editor
{
    public static class AssetCreateMenuItems
    {
        private static void CheckAndCreate(string templateName, string assetName)
        {
            #region Templates
            string namespaces =
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using System.Linq;\n" +
                "using UnityEngine;\n";

            var pluginsPath = Path.Combine(Application.dataPath, "Plugins", "Numba");

            if (Directory.Exists(Path.Combine(pluginsPath, "Extensions")))
                namespaces += "using Extensions;\n";

            if (Directory.Exists(Path.Combine(pluginsPath, "Coroutines")))
                namespaces += "using Coroutines;\n" +
                "using Coroutines.Extensions;\n" +
                "using Object = UnityEngine.Object;\n" +
                "using Coroutine = Coroutines.Coroutine;\n";

            var namespaceBegin = "\nnamespace #NAMESPACE#\n{\n";

            var before = namespaces + namespaceBegin;

            var after = "}";

            var scriptTemplate = before + "\tpublic class #SCRIPTNAME# : MonoBehaviour\n\t{\n\t}\n" + after;

            var classTemplate = before + "\tpublic class #SCRIPTNAME#\n\t{\n\t}\n" + after;

            var structTemplate = before + "\tpublic struct #SCRIPTNAME#\n\t{\n\t}\n" + after;

            var interfaceTemplate = before + "\tpublic interface #SCRIPTNAME#\n\t{\n\t}\n" + after;

            var enumTemplate = before + "\tpublic enum #SCRIPTNAME#\n\t{\n\t}\n" + after;

            Dictionary<string, string> tempaltes = new Dictionary<string, string>
            {
                { "ScriptTemplate.txt", scriptTemplate },
                { "ClassTemplate.txt", classTemplate },
                { "StructTemplate.txt", structTemplate },
                { "InterfaceTemplate.txt", interfaceTemplate },
                { "EnumTemplate.txt", enumTemplate }
            };
            #endregion

            var templatesPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Temp", "Code Templates");

            if (!Directory.Exists(templatesPath))
                Directory.CreateDirectory(templatesPath);

            var templatePath = Path.Combine(templatesPath, templateName);
            File.WriteAllText(templatePath, tempaltes[templateName]);

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, assetName);
        }

        [MenuItem("Assets/Create/C# MonoBehaviour", priority = 60)]
        private static void CreateScript() => CheckAndCreate("ScriptTemplate.txt", "NewBehaviourScript.cs");

        [MenuItem("Assets/Create/C# Class", priority = 61)]
        private static void CreateClass() => CheckAndCreate("ClassTemplate.txt", "NewClass.cs");

        [MenuItem("Assets/Create/C# Struct", priority = 62)]
        private static void CreateStruct() => CheckAndCreate("StructTemplate.txt", "NewStruct.cs");

        [MenuItem("Assets/Create/C# Interface", priority = 63)]
        private static void CreateInterface() => CheckAndCreate("InterfaceTemplate.txt", "NewInterface.cs");

        [MenuItem("Assets/Create/C# Enum", priority = 64)]
        private static void CreateEnum() => CheckAndCreate("EnumTemplate.txt", "NewEnum.cs");
    }
}