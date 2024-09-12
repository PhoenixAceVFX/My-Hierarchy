// Copyright (C) 2023 INF

// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using UnityEditor;
using UnityEngine;

namespace Components
{


    public class MyHierarchyGroup : MonoBehaviour
    {
        public Color fontColor = Color.white;
        public Color backgroundColor = Color.gray;

#if UNITY_EDITOR
        [MenuItem("GameObject/My Hierarchy/Group", false, 9)]
        public static void CreateHeaderGroup(MenuCommand menu)
        {
            var go = new GameObject();
            go.AddComponent<MyHierarchyGroup>();
            GameObjectUtility.SetParentAndAlign(go, menu.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Created MyHierarchy GO: " + go.name);
            Selection.activeObject = go;
            EditorApplication.RepaintHierarchyWindow();
        }
#endif

#if UNITY_EDITOR
        private void OnValidate() => EditorApplication.RepaintHierarchyWindow();
#endif
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MyHierarchyGroup)), CanEditMultipleObjects]
    public class MyHierarchyGroupEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Created By: (╯°□°)╯︵ INF", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Refactored by: RunaXR", EditorStyles.boldLabel);
        }
    }
#endif
}