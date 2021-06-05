using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Reflection;
using EasyMobile.Internal;

namespace EasyMobile.Editor
{
    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var flagSettings = (EnumFlagsAttribute) attribute;
            var targetEnum = GetBaseProperty<Enum>(property);
            var propName = flagSettings.enumName;
            Enum enumNew;

            EditorGUI.BeginProperty(position, label, property);

            if (string.IsNullOrEmpty(propName))
            {
#if UNITY_2017_3_OR_NEWER
                enumNew = EditorGUI.EnumFlagsField(position, label, targetEnum);
#else
                enumNew = EditorGUI.EnumMaskField(position, label, targetEnum);
#endif
            }
            else
            {
#if UNITY_2017_3_OR_NEWER
                enumNew = EditorGUI.EnumFlagsField(position, propName, targetEnum);
#else
                enumNew = EditorGUI.EnumMaskField(position, propName, targetEnum);
#endif
            }

            property.intValue = (int) Convert.ChangeType(enumNew, targetEnum.GetType());
            EditorGUI.EndProperty();
        }

        private static T GetBaseProperty<T>(SerializedProperty prop)
        {
            var separatedPaths = prop.propertyPath.Split('.');
            var reflectionTarget = prop.serializedObject.targetObject as object;

            foreach (var path in separatedPaths)
            {
                var fieldInfo = reflectionTarget.GetType().GetField(path,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                reflectionTarget = fieldInfo.GetValue(reflectionTarget);
            }

            return (T) reflectionTarget;
        }
    }
}