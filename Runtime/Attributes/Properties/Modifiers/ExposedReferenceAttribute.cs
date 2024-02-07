using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Use this attribute to make a reference Property Field type appear as a foldout property i.e. ScriptableObjects in the <i><b>Inspector</b></i>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ExposedReferenceAttribute : PropertyAttribute { }
}