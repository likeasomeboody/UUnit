using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UUnit.Unity.Editor
{
    public class UUnitEditorTestRunner : EditorWindow
    {
        #region Static

        [MenuItem("UTest/Test Runner")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(UUnitEditorTestRunner));
        }

        #endregion

        #region Fields



        #endregion

        #region Methods

        #region Methods.Behaviours

        private void OnEnable()
        {
            
        }

        private void OnGUI()
        {

        }

        #endregion

        #endregion
    }
}