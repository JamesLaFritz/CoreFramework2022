#### 2024-02-06 03ea804
##### docs(API): Merge branch 'main' of https://github.com/JamesLaFritz/CoreFramework2022

cherry-picking commit 5a009b3.

Date: Tue Feb 6 04:15:54 2024 -0500

This commit merges changes from the 'main' branch of the CoreFramework2022 repository into the current branch.

#### 2024-02-06 3837463
##### style: Refactor and Update XML Dociumentation Comments

This commit is the result of cherry-picking commit 54c8459.

Date: Tue Feb 6 03:19:57 2024 -0500

 - Updated XML Documentation comments for variables, methods, and classes.
 - Added Author and Description tags to the file header.
 - Improved comments for clarity and consistency.
 - Updated region headers for clarity and organization.

The following files were modified:
 - Runtime/Extensions/ArrayExtensions.cs
 - Runtime/Extensions/ObjectExtensions.cs
 - Runtime/Extensions/QuaternionExtensions.cs
 - Runtime/Extensions/TextExtensions.cs
 - Runtime/Extensions/TransformExtensions.cs
 - Runtime/Extensions/Vector4Extensions.cs
 - Runtime/Functional/Option.cs

#### 2024-02-06 7ec5f78
##### style: Refactor and Updated Comments

This commit is the result of cherry-picking commit 54c8459.

Date: Tue Feb 6 03:19:57 2024 -0500

- Updated XML Documentation comments for variables, methods, and classes.
- Added Author and Description tags to the file header.
- Improved comments for clarity and consistency.
- Updated region headers for clarity and organization.

The following files were modified:
- Runtime/Extensions/ArrayExtensions.cs
- Runtime/Extensions/ObjectExtensions.cs
- Runtime/Extensions/QuaternionExtensions.cs
- Runtime/Extensions/TextExtensions.cs
- Runtime/Extensions/TransformExtensions.cs
- Runtime/Extensions/Vector4Extensions.cs
- Runtime/Functional/Option.cs

#### 2024-02-06 a043ade
##### style: Refactor and Updated Comments

This commit is the result of cherry-picking commit 54c8459.

Date: Tue Feb 6 03:19:57 2024 -0500

 - Updated XML Documentation comments for variables, methods, and classes.

 - Added Author and Description tags to the file header.

 - Improved comments for clarity and consistency.

 - Updated region headers for clarity and organization.

The following files were modified:
 - Runtime/Extensions/ArrayExtensions.cs
 - Runtime/Extensions/ObjectExtensions.cs
 - Runtime/Extensions/QuaternionExtensions.cs
 - Runtime/Extensions/TextExtensions.cs
 - Runtime/Extensions/TransformExtensions.cs
 - Runtime/Extensions/Vector4Extensions.cs
 - Runtime/Functional/Option.cs

#### 2024-02-06 f819190
##### docs(API): Merge branch 'main' of https://github.com/JamesLaFritz/CoreFramework2022

This was a result of creating a commit to update the Documentation and then ammending that commit.

Date:      Tue Feb 6 02:36:07 2024 -0500

Update the API documentation with Docfx.

#### 2024-02-05 0f03332
##### style: Add Header Comments

This commit is the result of cherry-picking commit e379acc.

Date: Mon Feb 5 23:37:42 2024 -0500

 - Added header comments to several files to provide clarity on authorship and functionality.

 - Updated Bootstrapper.cs with a header comment describing its purpose in the application.

 - Updated CoreFrameworkMenu.cs with a header comment detailing its role in providing menu path constants.

 - Updated Interactable.cs with a header comment explaining its purpose as a base class for interactable GameObjects.

 - Updated Singleton.cs with a header comment describing its role as a generic Singleton class.

 - Updated Application.cs with a header comment outlining its purpose in managing the game application.

 - Updated Timer.cs with a header comment explaining its role in managing timers within Unity applications.

#### 2024-02-05 165c3ab
##### feat(SaveSystem)!: Refactor and Introduce ScriptableSingleton and SettingsProvider

This commit is the result of cherry-picking commit 2f9cf0c due to loss of data during a rebase.

Date: Mon Feb 5 22:52:58 2024 -0500

 - Updated XML Documentation comments for variables, methods, and classes.

 - Updated Unity Messages region with clearer method names and comments.

 - Renamed 'includeInactive' to '_includeInactive' for consistency with naming convention.

 - Renamed 'strategy' to '_strategy' for consistency with naming convention.

 - Improved error handling and logging in LoadFile method.

The following changes significantly alter the architecture and usage of the SaveSystem and related classes:
 - Updated `VersionControl.cs` to use Version type for 'CurrentFileVersion' and 'MinFileVersion'.
 - Introduced ScriptableSingleton for SaveSystem to ensure a single instance across all scenes.
 - Implemented SettingsProvider instead of `CoreFrameworkSettingSO.cs` to centralize configuration settings.

Ensure to review and update existing implementations to accommodate these changes.

BREAKING CHANGE: This commit changes the architecture and usage of the SaveSystem and VersionControl.

#### 2024-02-05 88a0d39
##### style: Add XML Documentation to Code

This commit is part of a rebase to update commit messages to new standards.
 cherry-picking commit e0f3ac3

Date: Mon Feb 5 22:20:48 2024 -0500

This commit enhances the code styling by adding XML documentation to improve readability and maintainability.

#### 2024-02-05 2a43f35
##### feat(Settings): Add Menu for Enhanced Navigation and Display Order

This commit introduces a new feature as part of a rebase to update commit messages to new standards and cherry-picking commit 01bcf31.

Date: Mon Feb 5 21:52:54 2024 -0500

This feature adds a menu to enhance navigation to the relevant project settings and user preferences.

Additionally, it updates the CoreFrameworkProjectSettingsProvider to display before other project settings in the Core Path.

#### 2024-02-05 7070fa2
##### refactor(Debugging): Move Debug Logging into an Extension method for Objects

This commit is part of a rebase to update commit messages to new standards and cherry-picking commit d59d9e2.

Date: Mon Feb 5 00:55:05 2024 -0500

This commit refactors the codebase by organizing debug logging functionality into an extension method for objects.
 It enhances code modularity and readability by encapsulating logging operations within extension methods, making them easily accessible from any object.

Changes:
 - Deleted: Runtime/DebugMonoBehaviour.cs.meta
 - Deleted: Runtime/DebugScriptableObject.cs.meta
 - New file: Runtime/Extensions/ObjectExtensions.cs
 - New file: Runtime/Extensions/ObjectExtensions.cs.meta
 - Modified: Runtime/Interactable.cs
 - Deleted: Runtime/Log.cs
 - Deleted: Runtime/Log.cs.meta

#### 2024-02-04 3530bff
##### feat(CoreFrameWorkSettings)!: Update settings to use User Prefferances and Project Settings

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 505bb30.

Date: Sun Feb 4 23:38:22 2024 -0500

Affects how settings are managed and accessed by using User Prefferances and Project Settings instead of relying on a scriptable object.

Changes:
 - Modified: Editor/Attributes/Properties/DropDownSelection/SceneAttributePropertyDrawer.cs
 - New file: Editor/Settings/CoreFrameworkPreferences.cs
 - New file: Editor/Settings/CoreFrameworkPreferencesProvider.cs
 - New file: Editor/Settings/CoreFrameworkProjectSettings.cs
 - New file: Editor/Settings/CoreFrameworkProjectSettingsProvider.cs
 - New file: Editor/Settings/CoreFrameworkSettingInitialization.cs
 - Deleted: Editor/Settings/CoreFrameworkSettingsEditor.cs.meta
 - Modified: Runtime/Bootstrapper.cs
 - Modified: Runtime/Settings/CoreFrameWorkSettings.cs

BREAKING CHANGE: Affects how settings are managed and accessed.

#### 2024-02-04 e3bfcaf
##### refactor: Remove unused using statements

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 989e312.

Date: Sun Feb 4 21:20:43 2024 -0500

Remove unused using statements from several files:
 - Editor/Attributes/Properties/DropDownSelection/InputAxisPropertyDrawer.cs
 - Editor/Saving/SaveEditorWindow.cs
 - Runtime/Attributes/ButtonAttribute.cs
 - Runtime/Attributes/Decorators/HeaderAttribute.cs

#### 2024-02-04 da34c60
##### fix: Fix issue with GameObject creation when the component requires a generic type

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 726d99d.

Date: Sun Feb 4 18:57:27 2024 -0500

Resolve an issue where GameObject creation was failing when the component required a generic type in the `Editor/CreateGameObjectFromUnityScript.cs` file.

Changes:
 - modified:   Editor/CreateGameObjectFromUnityScript.cs

#### 2024-02-04 c27fbb7
##### fix: Add undo functionality for GameObject creation, move component to top, and enable component renaming

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 022799c.

Date: Sun Feb 4 18:26:07 2024 -0500

Implemented the following features:
 - Added undo functionality for GameObject creation
 - Moved the component to the top of the hierarchy
 - Enabled renaming of the component

Changes:
 - modified:   Editor/CreateGameObjectFromUnityScript.cs

#### 2023-12-26 b5a347b
##### fix: Add conditional compilation for logging in Editor or Debug Build

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit c2cc819.

Date: Tue Dec 26 05:14:19 2023 -0500

Added `#IF UNITY_EDITOR || DEBUG` preprocessor directive to ensure that Info and Warnings are displayed only in the Editor or if this is a Debug Build.

Changes:
 - modified:   Runtime/Log.cs

#### 2023-12-23 fe17557
##### fix: Fix `null reference` error when script type is not a class

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit f23e2fb.

Date: Sat Dec 23 04:45:38 2023 -0500

Fixed an issue where a `null reference` error was being set when the type of a script is not a class.

Changes:
 - modified:   Editor/CreateGameObjectFromUnityScript.cs

#### 2023-12-21 df80b47
##### fix: Update `FindField` to use `System.Reflection GetField`

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 2eb9211.

Date: Thu Dec 21 06:17:08 2023 -0500

Update the `FindField` method to utilize `System.Reflection GetField` instead of `GetFields()`,
 eliminating the need to loop through all fields to check their names.

Changes:
 - modified:   Editor/SerializedPropertyExtensions.cs

#### 2023-12-19 fe163a4
##### fix: Rename GetProperty to getSerializedProperty

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 921e4f0.

Date: Tue Dec 19 22:19:40 2023 -0500

Rename `GetProperty` to `getSerializedProperty`
Add the ability to get the targeted object that a Serialized Property belongs to, as well as the ability to get the fields, find a field, and get the value of a field.

Changes:
 - modified:   Editor/Attributes/Properties/ShowIfBoolPropertyDrawer.cs
 - modified:   Editor/Attributes/Properties/ShowIfEnumPropertyDrawer.cs
 - modified:   Editor/SerializedPropertyExtensions.cs

#### 2023-12-19 6af53a5
##### fix: Rename PropertyDrawerHelper to SerializedPropertyExtensions.cs

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit 54bd998.

Date: Tue Dec 19 19:21:12 2023 -0500

Rename PropertyDrawerHelper to be SerializedPropertyExtensions.cs and update usages to properly reference.

Changes:
 - modified:   Editor/Attributes/Properties/ShowIfBoolPropertyDrawer.cs
 - modified:   Editor/Attributes/Properties/ShowIfEnumPropertyDrawer.cs
 - modified:   Editor/Inspector/AttributeMonoBehaviourInspector.cs
 - renamed:    Editor/PropertyDrawerHelper.cs -> Editor/SerializedPropertyExtensions.cs
 - renamed:    Editor/PropertyDrawerHelper.cs.meta -> Editor/SerializedPropertyExtensions.cs.meta

#### 2023-12-19 4976b09
##### fix: Change `findProperty` to be an Extension of `SerializedProperty`

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit f372d60.

Date:      Tue Dec 19 19:07:06 2023 -0500

Updates the `findProperty` method to be an extension of `SerializedProperty` in the `Editor/PropertyDrawerHelper.cs` file.

Changes:
 - modified:   Editor/PropertyDrawerHelper.cs

#### 2023-12-19 25ae930
##### fix: Update Transform Extensions, fix errors, simplify code

This is part of a rebase to update commit messages to new standard and git cherry-pick --strategy-option=theirs 7360023

Date:      Tue Dec 19 18:37:53 2023 -0500

This commit updates the TransformExtensions.cs file, addressing errors and simplifying the code for better readability and efficiency.

Changes:
 - Corrected errors in TransformExtensions
 - Simplified code structure for clarity

#### 2023-12-17 8b622ec
##### feat: Add useful Transformation extensions to GameObject

Date:      Sun Dec 17 05:54:13 2023 -0500

This commit introduces Transformation extensions to GameObject in `GameObjectExtensions.cs`, providing convenient methods for common transformation tasks.
 - Added Transformation extensions
 - Improved functionality for GameObject

This is part of a rebase to update commit messages to new standard and git cherry-pick --strategy-option=theirs ef18156

#### 2023-12-17 d2c367b
##### fix: Add `OrNull` suffix to prevent `NullReferenceExceptions`

This commit adds the `OrNull` suffix to methods in `GameObjectExtensions.cs` to address `NullReferenceExceptions` that occur when a `GameObject` is slated to be destroyed.
 - Added `OrNull` suffix to methods
 - Prevented `NullReferenceExceptions`

This is part of a rebase to update commit messages to new standard. git cherry-pick --strategy-option=theirs 31e61e6

#### 2023-12-17 9cc1eac
##### feat(docs): Update documentation format and structure

This commit updates the format and structure of the documentation files to adhere to the new standard and . git cherry-pick --strategy-option=theirs d83ebaf
 The documentation files have been organized into appropriate directories and meta files have been added for each HTML file.

 - Updated documentation format
 - Organized documentation into directories
 - Added meta files for HTML files

#### 2023-12-17 5ad4574
##### fix(Settings): Default Start Scene and Boot Scene to null if no Settings ScriptableObject

This commit updates the CoreFrameWorkSettings.cs file to
 default the Start Scene and Boot Scene to null if there is no Settings ScriptableObject present.
 This prevents errors and allows for more flexibility in project configuration.

This is part of a rebase to update commit messages to the new standard and git cherry-pick --strategy-option=theirs 4d9608e.

#### 2023-12-17 84682e7
##### ix(Bootstrapper): Add null checking to prevent errors

This commit adds null checking to the Bootstrapper class to prevent errors.
 Now, it allows having the Core Framework in your project without being forced to use the bootstrapper.

This is part of a rebase to update commit messages to the new standard and git cherry-pick --strategy-option=theirs faf8979.

#### 2023-11-20 169f4cc
##### doc(Manual, API): Modify Unity Types for documentation

This commit is part of a rebase to fix commit messages to new standards and cherry-picking commit c5de31c.
 It modifies Unity Types for documentation purposes.

Date: Mon Nov 20 12:46:12 2023 -0500

Changes:
- Modified Vector4GameEventListener.cs in Unity Event Inspector/Typed Unity Events/Unity Types
- Added ExposedReferenceAttribute documentation
- Modified various documentation files related to logging, attributes, and properties

#### 2023-11-03 6fa6de9
##### fix(Attributes)!: Fix properties display for Scriptable Objects

This commit implements major changes and bug fixes, starting the transition to use UIElements.
 It is part of a rebase process to fix an old commit message to conform to new standards.

Date: Fri Nov 3 20:07:33 2023 -0400

Changes:
- Modified ExposedReferencePropertyDrawer.cs (Editor)

BREAKING CHANGE: This commit introduces a breaking change to resolve conflicts and ensure proper display of Scriptable Object properties.

#### 2023-11-03 bdefc4d
##### feat!: Implement major changes and bug fixes, start transitioning to use UIElements

This commit implements major changes and bug fixes, starting the transition to use UIElements.
 It is part of a rebase process to fix an old commit message to conform to new standards.

Date: Fri Nov 3 07:36:24 2023 -0400

Changes:
- Modified SceneAttributePropertyDrawer.cs (Editor)
- Modified AttributeMonoBehaviourInspector.cs (Editor)
- Modified ButtonAttributeHelper.cs (Editor)
- Modified PropertyDrawerHelper.cs (Editor)
- Added Settings.meta (Editor)
- Added CoreFrameworkSettingsEditor.cs (Editor)
- Added CoreFrameworkSettingsEditor.cs.meta (Editor)
- Added Bootstrapper.cs (Runtime)
- Added Bootstrapper.cs.meta (Runtime)
- Modified DebugMonoBehaviour.cs (Runtime)
- Added DebugScriptableObject.cs (Runtime)
- Added DebugScriptableObject.cs.meta (Runtime)
- Modified Interactable.cs (Runtime)
- Added Log.cs (Runtime)
- Added Log.cs.meta (Runtime)
- Modified CodedGameEventListener.cs (Runtime)
- Modified BaseReference.cs (Runtime)
- Modified BaseVariable.cs (Runtime)
- Added Settings.meta (Runtime)
- Added CoreFrameWorkSettings.cs (Runtime)
- Added CoreFrameWorkSettings.cs.meta (Runtime)
- Added CoreFrameworkSettingsSO.cs (Runtime)
- Added CoreFrameworkSettingsSO.cs.meta (Runtime)
- Added Singleton.cs (Runtime)
- Added Singleton.cs.meta (Runtime)
- Modified package.json (Root)

BREAKING CHANGE: This commit introduces breaking changes due to the transition to UIElements.

#### 2024-02-07 eb4c74b
##### feat: Add icons for different scripts

Add icons for different scripts, allowing them to be displayed as the chosen icon in both the inspector and the project view.

Modified:
 - ExposedReferencePropertyDrawer.cs

Added:
 - VariableIcon.png
 - Vector2VariableIcon.png
 - Vector3VariableIcon.png
 - Vector4VariableIcon.png

Modified meta files:
 - SavableEntity.cs.meta
 - SaveSystem.cs.meta
 - JsonStrategy.cs.meta
 - SavingStrategy.cs.meta
 - VersionControl.cs.meta
 - BaseGameEvent.cs.meta
 - GameEvent.cs.meta
 - IGameEvent.cs.meta
 - Combination/GameObjectBoolGameEvent.cs.meta
 - Combination/GameObjectFloatGameEvent.cs.meta
 - Combination/GameObjectIntGameEvent.cs.meta
 - System/BoolGameEvent.cs.meta
 - System/ByteGameEvent.cs.meta
 - System/CharGameEvent.cs.meta
 - System/DoubleGameEvent.cs.meta
 - System/FloatGameEvent.cs.meta
 - System/IntGameEvent.cs.meta
 - System/LongGameEvent.cs.meta
 - System/SByteGameEvent.cs.meta
 - System/ShortGameEvent.cs.meta
 - System/StringGameEvent.cs.meta
 - System/UIntGameEvent.cs.meta
 - System/ULongGameEvent.cs.meta
 - System/UShortGameEvent.cs.meta
 - Unity/AnimationCurveGameEvent.cs.meta
 - Unity/AudioClipGameEvent.cs.meta
 - Unity/BoundsGameEvent.cs.meta
 - Unity/Color32GameEvent.cs.meta
 - Unity/ColorGameEvent.cs.meta
 - Unity/GameObjectGameEvent.cs.meta
 - Unity/LayerMaskGameEvent.cs.meta
 - Unity/ObjectGameEvent.cs.meta
 - Unity/QuaternionGameEvent.cs.meta
 - Unity/SceneGameEvent.cs.meta
 - Unity/Vector2GameEvent.cs.meta
 - Unity/Vector3GameEvent.cs.meta
 - Unity/Vector4GameEvent.cs.meta
 - CodedGameEventListener.cs.meta
 - IGameEventListener.cs.meta
 - GameEventListener.cs.meta
 - Typed Unity Events/System Types/BoolGameEventListener.cs.meta
 - Typed Unity Events/System Types/ByteGameEventListener.cs.meta
 - Typed Unity Events/System Types/DoubleGameEventListener.cs.meta
 - Typed Unity Events/System Types/FloatGameEventListener.cs.meta
 - Typed Unity Events/System Types/IntGameEventListener.cs.meta
 - Typed Unity Events/System Types/LongGameEventListener.cs.meta
 - Typed Unity Events/System Types/SByteGameEventListener.cs.meta
 - Typed Unity Events/System Types/ShortGameEventListener.cs.meta
 - Typed Unity Events/System Types/StringGameEventListener.cs.meta
 - Typed Unity Events/System Types/UIntGameEventListener.cs.meta
 - Typed Unity Events/System Types/ULongGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/AudioClipGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/BoundsGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/Color32GameEventListener.cs.meta
 - Typed Unity Events/Unity Types/ColorGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/GameObjectGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/LayerMaskGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/ObjectGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/QuaternionGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/SceneGameEventListener.cs.meta
 - Typed Unity Events/Unity Types/Vector2GameEventListener.cs.meta
 - Typed Unity Events/Unity Types/Vector3GameEventListener.cs.meta
 - Typed Unity Events/Unity Types/Vector4GameEventListener.cs.meta
 - UnityGameEventListener.cs.meta
 - System/BoolUnityEvent.cs.meta
 - System/ByteUnityEvent.cs.meta
 - System/CharUnityEvent.cs.meta
 - System/DoubleUnityEvent.cs.meta
 - System/FloatUnityEvent.cs.meta
 - System/IntUnityEvent.cs.meta
 - System/LongUnityEvent.cs.meta
 - System/SByteUnityEvent.cs.meta
 - System/ShortUnityEvent.cs.meta
 - System/StringUnityEvent.cs.meta
 - System/UIntUnityEvent.cs.meta
 - System/ULongUnityEvent.cs.meta
 - System/UShortUnityEvent.cs.meta
 - Unity/AnimationCurveUnityEvent.cs.meta
 - Unity/AudioClipUnityEvent.cs.meta
 - Unity/BoundsUnityEvent.cs.meta
 - Unity/Color32UnityEvent.cs.meta
 - Unity/ColorUnityEvent.cs.meta
 - Unity/GameObjectUnityEvent.cs.meta
 - Unity/LayerMaskUnityEvent.cs.meta
 - Unity/ObjectUnityEvent.cs.meta
 - Unity/QuaternionUnityEvent.cs.meta
 - Unity/SceneUnityEvent.cs.meta
 - Unity/Vector2UnityEvent.cs.meta
 - Unity/Vector3UnityEvent.cs.meta
 - Unity/Vector4UnityEvent.cs.meta
 - BaseVariable.cs.meta
 - System/BoolVariable.cs.meta
 - System/ByteVariable.cs.meta
 - System/CharVariable.cs.meta
 - System/DoubleVariable.cs.meta
 - System/FloatVariable.cs.meta
 - System/IntVariable.cs.meta
 - System/LongVariable.cs.meta
 - System/SByteVariable.cs.meta
 - System/ShortVariable.cs.meta
 - System/StringVariable.cs.meta
 - System/UIntVariable.cs.meta
 - System/ULongVariable.cs.meta
 - System/UShortVariable.cs.meta
 - Unity/AnimationCurveVariable.cs.meta
 - Unity/AudioClipVariable.cs.meta
 - Unity/BoundsVariable.cs.meta
 - Unity/Color32Variable.cs.meta
 - Unity/ColorVariable.cs.meta
 - Unity/GameObjectVariable.cs.meta
 - Unity/LayerMaskVariable.cs.meta
 - Unity/ObjectVariable.cs.meta
 - Unity/QuaternionVariable.cs.meta
 - Unity/SceneVariable.cs.meta
 - Unity/Vector2Variable.cs.meta
 - Unity/Vector3Variable.cs.meta
 - Unity/Vector4Variable.cs.meta

#### 2024-02-07 adfa8fb
##### feat: Add ExposedReferenceAttribute

This commit adds the ExposedReferenceAttribute, which can be applied to fields or properties to make reference types appear as foldout properties in the Inspector.
This is particularly useful for ScriptableObjects.

#### 2024-02-07 aa82158
##### feat: Add saving system implementation

This commit introduces a comprehensive saving system to the project, including the following features:

 - SaveEditorWindow.cs: A custom editor window for managing save settings.
 - ISavable.cs: An interface to implement in any component that has state to save/restore.
 - JsonStatics.cs: Utility methods for converting between UnityEngine.Vector3 and JsonObject.
 - SavableEntity.cs: A MonoBehaviour for all game objects that need to save data.
 - SaveSystem.cs: A MonoBehaviour that provides the interface to the Json saving system.
 - JsonStrategy.cs: A saving strategy that saves and loads in the form of a JSON string.
 - SavingStrategy.cs: An abstract class that saving strategies inherit from.
 - VersionControl.cs: A class to manage version control for the saving system.

This implementation allows for efficient saving and loading of game state, with support for multiple saving strategies and version control.

#### 2024-02-07 c9d8f1f
##### feat(Runtime): Add DebugMonoBehaviour for logging debug information

This commit introduces a new MonoBehaviour class, `DebugMonoBehaviour`, designed to facilitate logging of debug information within MonoBehaviour scripts.
It provides methods for logging informational, error, and warning messages, along with the method and behaviour names.
The class includes an option to toggle the display of debug information.

#### 2024-02-06 8953d0b
##### feat(Runtime/ScriptableObjectArchitecture/Events): Add typed game events and listeners

This commit introduces typed game events and listeners to the ScriptableObjectArchitecture:
1. Added new base classes `BaseGameEvent<T1, T2>` and `IGameEvent<T1, T2>` for game events with two type parameters.
2. Implemented `BaseGameEvent<T1, T2>` for combination typed events with two parameters.
3. Added typed game event assets and their meta files.
4. Implemented `IGameEventListener<T1, T2>` for listeners with two type parameters.
5. Updated existing listeners (`CodedGameEventListener`, `UnityGameEventListener`) to support typed events with one and two parameters.

#### 2024-02-06 f7b5709
##### refactor(Runtime/Attributes): Refactor ButtonAttribute.cs and BaseVariable.cs

This commit refactors the ButtonAttribute.cs and BaseVariable.cs files:
1. In ButtonAttribute.cs, removed the assertion check for ButtonMode.Both as it is now a valid mode.
2. In BaseVariable.cs:
   - Changed the declaration of the 'clampable' field to have consistent formatting.
   - Updated the usage of 'm_isClamped' to 'isClamped' in the 'ShowIfBool' attribute for 'minValue' and 'maxValue' fields.
   - Fixed the return statement in the SetValue method to correctly return the variable's value when it is read-only.

#### 2024-02-06 f35ff7f
##### fix: Fix issue in package.json preventing loading in Unity from PackageManager

This commit addresses an issue in the package.json file that was causing it to not load correctly in Unity from the PackageManager.
The "name" field in the package.json file has been corrected to "com.jameslafritz.coreframework" to match the expected naming convention.

#### 2024-02-06 1f8859e
##### feat(Samples): Add new game objects and components to scene

This commit adds several new game objects and their corresponding components to the Unity scene file. Each component includes various properties and settings.

Here's a summary of the changes:

1. HeaderExample GameObject:
   - Added a GameObject named "HeaderExample" with a MonoBehaviour component attached to it. The MonoBehaviour component has several "health" properties defined.

2. ShowIfEnumExample GameObject:
   - Added a GameObject named "ShowIfEnumExample" with a MonoBehaviour component attached to it. The MonoBehaviour component contains properties related to enumerations.

3. SceneExample GameObject:
   - Added a GameObject named "SceneExample" with a MonoBehaviour component attached to it. The MonoBehaviour component specifies a scene name and index.

4. AttributeUIElementsExample GameObject:
   - Added a GameObject named "AttributeUIElementsExample" with a MonoBehaviour component attached to it. The MonoBehaviour component defines various properties such as health, maxHealth, someFloat, someOtherFloat, someBool, someString, and animator, along with animation parameters.

5. InputAxisExample GameObject:
   - Added a GameObject named "InputAxisExample" with a MonoBehaviour component attached to it. The MonoBehaviour component specifies input-related properties.

6. Directional Light GameObject:
   - Added a GameObject named "Directional Light" representing a light source in the scene.

7. InfoBoxExample GameObject:
   - Added a GameObject named "InfoBoxExample" with a MonoBehaviour component attached to it. The MonoBehaviour component contains someFloat, someOtherFloat, someBool, and someString properties.

These changes are related to adding game objects and defining their properties within the Unity scene.

#### 2024-02-06 56c0bcd
##### feat(ScriptableObjectArchitecture): Added Reference Variables

This commit introduces a set of reference variables to the ScriptableObjectArchitecture.
Reference variables are designed to hold references to various types of Unity objects and primitives.
This addition aims to provide a flexible and convenient way to manage references within the architecture.

- Added reference variables for different data types, including bool, byte, char, double, float, int, long, sbyte, short, string, uint, ulong, ushort, Vector2, Vector3, Vector4, Color, Color32, Bounds, Quaternion, GameObject, AudioClip, AnimationCurve, LayerMask, Object, and Scene.
- Implemented reference variables for Unity types, providing robust support for managing references to Unity-specific objects.
- Created base reference class to encapsulate common functionalities and facilitate extensibility.
- Organized reference variables into appropriate namespaces and folders for better project organization and maintainability.

This enhancement expands the capabilities of the ScriptableObjectArchitecture, allowing developers to easily work with references across different parts of their Unity projects.

#### 2022-09-01 d42fc82
##### feat: Add Scriptable Object Events and Variables

This commit introduces the ScriptableObjectArchitecture feature, which includes the following changes:

Addition of editor scripts and inspectors for managing scriptable object variables.
Creation of runtime scripts for defining events and listeners using scriptable objects.
Implementation of various typed events and corresponding listener classes.
Introduction of base variable and event classes for extensibility.
Creation of utility scripts for common functionalities.
These changes enable the usage of scriptable objects for defining events and variables, providing a flexible architecture for managing game data and logic.

#### 2022-09-01 5d0683a
##### refactor: Update Code Refactoring Changes

This commit focuses on updating code refactoring changes, primarily consisting of modifying variable names and improving code readability.

The changes include:
 - Correcting variable naming conventions to adhere to PascalCase.
 - Improving consistency in variable names across different files.

These updates aim to enhance code clarity and maintainability.

#### 2022-09-01 75f99be
##### docs: Add XML Documentation Comments for Auto Documentation Generation

This commit focuses on adding XML documentation comments to the codebase to facilitate auto documentation generation.
These comments are essential for documenting the purpose, parameters, return values, and other relevant information about methods, classes, and properties.

#### 2022-08-18 86d3637
##### docs: Update Asset Licenses documentation

This commit modifies the docs/License/Asset Licenses.html file to reflect changes in asset licenses.
It ensures that the documentation accurately represents the licenses associated with project assets.

#### 2022-08-18 af56a96
##### docs(API, Manual): Generate Attribute Documentation with DocFX

This commit focuses on generating documentation using Docfx for both the API and manual sections.
It includes updates to documentation templates, integration of Docfx for generating attribute manual and API documentation,
addition of image assets, modifications to various files for template integration,
and adjustments to styles and scripts for the documentation website.

These updates aim to enhance the clarity, usability, and comprehensiveness of the project's documentation,
providing developers with comprehensive resources for understanding and utilizing the project's attributes.

#### 2022-08-14 a9617a6
##### feat(Samples, Attributes): Complete Attribute Samples

This commit completes the attribute samples in the project.
It modifies the `Editor/Attributes/Properties/FolderPathAttributeDrawer.cs`, `Editor/Inspector/AttributeMonoBehaviourInspector.cs`,
and `Runtime/Attributes/Properties/ShowIfBoolAttribute.cs` files to finalize the attribute implementations.

Additionally, it modifies the `Samples/Attributes/AttributesExample.unity` file to include the newly added attribute samples.
 The following new files are introduced:

- `ButtonExample.cs` and its corresponding meta file `ButtonExample.cs.meta`
- `FolderPathExample.cs` and its corresponding meta file `FolderPathExample.cs.meta`
- `RequiredReferenceExample.cs` and its corresponding meta file `RequiredReferenceExample.cs.meta`
- `ShowIfBoolExample.cs` and its corresponding meta file `ShowIfBoolExample.cs.meta`
- `ShowIfEnumExample.cs` and its corresponding meta file `ShowIfEnumExample.cs.meta`
- `ShowIfMulti.cs` and its corresponding meta file `ShowIfMulti.cs.meta`

These examples provide developers with practical demonstrations of various attribute functionalities,
 such as button attributes, folder path attributes, required reference attributes, boolean show-if attributes,
 enum show-if attributes, and multi-condition show-if attributes.

Furthermore, the `README.md` file in the `docs` directory is updated to reflect the completion of the attribute samples.

#### 2022-08-13 1b74aae
##### feat(Samples, Attributes): Add Icon and Read-Only Examples

This commit adds Icon and Read-Only Examples to the project.
It modifies the `Samples/Attributes/AttributesExample.unity` file to incorporate these examples.
Additionally, it introduces `IconExample.cs` and `ReadOnlyExample.cs`, along with their corresponding meta files,
under `Samples/Attributes/Scripts/Properties/Modifiers/`.

The Icon Example demonstrates how to use icons with attribute modifiers, providing developers with
a practical demonstration of enhancing the visual representation of properties in their Unity projects.

The Read-Only Example showcases how to apply the read-only attribute to properties, ensuring they cannot be modified at runtime.
This example offers developers insight into controlling property behavior effectively.

Furthermore, the `README.md` file in the `docs` directory is updated to reflect the addition of the Icon and Read-Only Examples.

#### 2022-08-13 19e6166
##### fix(Editor, Samples): Fix Issue with Icons Display

This commit addresses an issue where icons were not displaying correctly if a property has other attributes.

Changes include modifications to several files:
- `Editor/Animation/AnimationParameterDrawer.cs`
- `Editor/Attributes/Properties/DropDownSelection/InputAxisPropertyDrawer.cs`
- `Editor/Attributes/Properties/DropDownSelection/SceneAttributePropertyDrawer.cs`
- `Editor/Attributes/Properties/DropDownSelection/TagAttributePropertyDrawer.cs`
- `Editor/Attributes/Properties/FolderPathAttributeDrawer.cs`
- `Editor/Attributes/Properties/Modifiers/ReadOnlyPropertyDrawer.cs`
- `Editor/Attributes/Properties/RequiredReferencePropertyDrawer.cs`
- `Editor/Attributes/Properties/ShowIfBoolPropertyDrawer.cs`
- `Editor/Attributes/Properties/ShowIfEnumPropertyDrawer.cs`
- `Editor/Inspector/ButtonAttributeHelper.cs` (previously Inspector Button/ButtonAttributeHelper.cs)
- `Editor/Inspector/ScriptableObjectButtonsEditor.cs`
- `Editor/Inspector/UIElementsCustomEditor.cs`
- `Editor/PropertyDrawerHelper.cs`

Additionally, the following changes were made:
- `Editor/Inspector/AttributeMonoBehaviourInspector.cs` and its corresponding meta file were added.
- `Editor/Inspector/AttributeScriptableObjectInspector.cs` and its corresponding meta file were added.
- `Editor/Inspector/ButtonAttributeHelper.cs` (previously Inspector Button/ButtonAttributeHelper.cs) and its corresponding meta file were renamed.
- `Samples/Attributes/Scripts/AttributesExample.cs` was modified.

These modifications ensure that icons are properly displayed even when properties have other attributes.

#### 2022-08-13 4549e82
##### feat(Samples, Attributes): Add Tag Example

This commit introduces a Tag Example to the project.
It modifies the `Samples/Attributes/AttributesExample.unity` file to incorporate the Tag Example.
Additionally, it adds `TagExample.cs` along with its corresponding meta file, `TagExample.cs.meta`,
under `Samples/Attributes/Scripts/Properties/Drop Down Selection/`.

The Tag Example showcases how to utilize tag properties with attributes
providing developers with a practical demonstration of integrating tag-related functionality into their Unity projects.

Furthermore, the `README.md` file in the `docs` directory is updated to reflect the addition of the Tag Example.

#### 2022-08-13 191376f
##### feat(Samples, Attributes): Add Scene Example

This commit adds a Scene Example to the project.
It modifies the `Samples/Attributes/AttributesExample.unity` file to include the Scene Example.
Additionally, it introduces `SceneExample.cs` and its corresponding meta file
 `SceneExample.cs.meta` under `Samples/Attributes/Scripts/Properties/Drop Down Selection/`.

The Scene Example demonstrates how to utilize scene properties with
attributes, offering developers a practical demonstration of integrating
scene-related functionality into their Unity projects.

Furthermore, the `README.md` file in the `docs` directory is updated to reflect
the addition of the Scene Example.

#### 2024-02-06 e370bbd
##### chore: Update Rider IDE config files


#### 2022-08-13 c319d2a
##### feat(Samples, Attributes): Create Input Axis Example

This commit adds an Input Axis Example to the project. It modifies the Samples/Attributes/AttributesExample.unity file to include the Input Axis Example. Additionally, it introduces InputAxisExample.cs and its corresponding meta file InputAxisExample.cs.meta under Samples/Attributes/Scripts/Properties/Drop Down Selection/.

This example demonstrates how to use input axis properties with attributes, providing developers with a practical reference for implementing input handling in their Unity projects.

Furthermore, the README.md file in the docs directory is modified to reflect the addition of the Input Axis Example.

#### 2022-08-13 0eab5a5
##### refactor(AnimatorParameterAttribute.cs): Move Animator Parameter Attribute with Animation related files

This commit refactors the project structure by relocating the AnimatorParameterAttribute.cs file
from the Runtime/Attributes/Properties/Drop Down Selection/ directory to the Runtime/Animation/ directory.

This change ensures better organization and alignment of files related to animation within the project.

#### 2022-08-13 fdd6764
##### feat(Attribute, Destroy, Interactable, Extensions, Functional)!: Add new files related to attribute decorators and properties, Destroy system, Interactable system, and Extension methods

This commit introduces several new files related to attribute decorators and properties in the editor and runtime sections of the project.
These files include implementations for various attribute decorators such as HeaderAttribute and InfoBoxAttribute, as well as property drawers
for handling specific types of attributes like DropDownSelection and FolderPathAttribute.

Additionally, this update includes the implementation of the Destroy system, which consists of DestroyAfterTime.cs and DestroyNoChildren.cs.
These components provide functionality to destroy game objects in Unity, offering flexibility in managing object lifecycles.

Furthermore, the Interactable system is introduced, featuring Interactable.cs,
which allows for interaction with objects within the Unity game environment, enhancing user engagement and gameplay dynamics.

Lastly, extension methods such as ArrayExtensions.cs, QuaternionExtensions.cs, TextExtensions.cs, and Vector4Extensions.cs are added.
These extensions augment the project with additional functionality, making development tasks more streamlined and efficient.

This major update ensures compatibility with Unity 2022 and enhances the project's extensibility, usability, and overall functionality.

BREAKING CHANGE: This update introduces significant changes to the project structure and functionality. Developers relying on the previous implementation may need to update their code and configurations to accommodate these changes.

#### 2022-07-19 7554363
##### docs: Update README


#### 2022-07-19 1f95977
##### docs: Edit "Asset Licenseses" and "Third Party Notices"


#### 2022-07-19 be8f491
##### docs: Change Log Update


#### 2022-07-19 368f0e7
##### doc: Documentation Configuration.

docfx change documentation

#### 2022-07-18 a2babc9
##### doc: Initial documentation Commit


#### 2022-07-18 8c10ff2
##### Initial commit


