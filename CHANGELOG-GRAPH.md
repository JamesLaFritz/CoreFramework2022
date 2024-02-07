* commit d42fc82666f58a1dc092f1e460a9d30782dc6511
| Author: James LaFritz <ktmarine1999+git@gmail.com>
| Date:   Thu Sep 1 08:56:35 2022 -0400
| 
|     feat: Add Scriptable Object Events and Variables
|     
|     This commit introduces the ScriptableObjectArchitecture feature, which includes the following changes:
|     
|     Addition of editor scripts and inspectors for managing scriptable object variables.
|     Creation of runtime scripts for defining events and listeners using scriptable objects.
|     Implementation of various typed events and corresponding listener classes.
|     Introduction of base variable and event classes for extensibility.
|     Creation of utility scripts for common functionalities.
|     These changes enable the usage of scriptable objects for defining events and variables, providing a flexible architecture for managing game data and logic.
| 
* commit 5d0683a468bbe6e2f258d9b975d15dee2e492b30
| Author: James LaFritz <ktmarine1999+git@gmail.com>
| Date:   Thu Sep 1 08:55:42 2022 -0400
| 
|     refactor: Update Code Refactoring Changes
|     
|     This commit focuses on updating code refactoring changes, primarily consisting of modifying variable names and improving code readability.
|     
|     The changes include:
|      - Correcting variable naming conventions to adhere to PascalCase.
|      - Improving consistency in variable names across different files.
|     
|     These updates aim to enhance code clarity and maintainability.
| 
* commit 75f99be5314158b0a3749606b7d282ade6c63199
| Author: James LaFritz <ktmarine1999+git@gmail.com>
| Date:   Thu Sep 1 07:11:09 2022 -0400
| 
|     docs: Add XML Documentation Comments for Auto Documentation Generation
|     
|     This commit focuses on adding XML documentation comments to the codebase to facilitate auto documentation generation.
|     These comments are essential for documenting the purpose, parameters, return values, and other relevant information about methods, classes, and properties.
| 
* commit 86d36377fda7f6342bc3894e929577abdf184d4c
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Thu Aug 18 16:20:01 2022 -0400
| 
|     docs: Update Asset Licenses documentation
|     
|     This commit modifies the docs/License/Asset Licenses.html file to reflect changes in asset licenses.
|     It ensures that the documentation accurately represents the licenses associated with project assets.
| 
* commit af56a967933f3af647f2312f1f46adf6d9ee6f88
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Thu Aug 18 16:08:25 2022 -0400
| 
|     docs(API, Manual): Generate Attribute Documentation with DocFX
|     
|     This commit focuses on generating documentation using Docfx for both the API and manual sections.
|     It includes updates to documentation templates, integration of Docfx for generating attribute manual and API documentation,
|     addition of image assets, modifications to various files for template integration,
|     and adjustments to styles and scripts for the documentation website.
|     
|     These updates aim to enhance the clarity, usability, and comprehensiveness of the project's documentation,
|     providing developers with comprehensive resources for understanding and utilizing the project's attributes.
| 
* commit a9617a60073672e3a3f86e1b071ac5c137d001d8
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sun Aug 14 00:35:42 2022 -0400
| 
|     feat(Samples, Attributes): Complete Attribute Samples
|     
|     This commit completes the attribute samples in the project.
|     It modifies the `Editor/Attributes/Properties/FolderPathAttributeDrawer.cs`, `Editor/Inspector/AttributeMonoBehaviourInspector.cs`,
|     and `Runtime/Attributes/Properties/ShowIfBoolAttribute.cs` files to finalize the attribute implementations.
|     
|     Additionally, it modifies the `Samples/Attributes/AttributesExample.unity` file to include the newly added attribute samples.
|      The following new files are introduced:
|     
|     - `ButtonExample.cs` and its corresponding meta file `ButtonExample.cs.meta`
|     - `FolderPathExample.cs` and its corresponding meta file `FolderPathExample.cs.meta`
|     - `RequiredReferenceExample.cs` and its corresponding meta file `RequiredReferenceExample.cs.meta`
|     - `ShowIfBoolExample.cs` and its corresponding meta file `ShowIfBoolExample.cs.meta`
|     - `ShowIfEnumExample.cs` and its corresponding meta file `ShowIfEnumExample.cs.meta`
|     - `ShowIfMulti.cs` and its corresponding meta file `ShowIfMulti.cs.meta`
|     
|     These examples provide developers with practical demonstrations of various attribute functionalities,
|      such as button attributes, folder path attributes, required reference attributes, boolean show-if attributes,
|      enum show-if attributes, and multi-condition show-if attributes.
|     
|     Furthermore, the `README.md` file in the `docs` directory is updated to reflect the completion of the attribute samples.
| 
* commit 1b74aae802abf66ce0a8fe029703cd7e544bb08c
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 21:27:36 2022 -0400
| 
|     feat(Samples, Attributes): Add Icon and Read-Only Examples
|     
|     This commit adds Icon and Read-Only Examples to the project.
|     It modifies the `Samples/Attributes/AttributesExample.unity` file to incorporate these examples.
|     Additionally, it introduces `IconExample.cs` and `ReadOnlyExample.cs`, along with their corresponding meta files,
|     under `Samples/Attributes/Scripts/Properties/Modifiers/`.
|     
|     The Icon Example demonstrates how to use icons with attribute modifiers, providing developers with
|     a practical demonstration of enhancing the visual representation of properties in their Unity projects.
|     
|     The Read-Only Example showcases how to apply the read-only attribute to properties, ensuring they cannot be modified at runtime.
|     This example offers developers insight into controlling property behavior effectively.
|     
|     Furthermore, the `README.md` file in the `docs` directory is updated to reflect the addition of the Icon and Read-Only Examples.
| 
* commit 19e61663205b68bd99f770776bbe1ec022ea9053
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 21:15:21 2022 -0400
| 
|     fix(Editor, Samples): Fix Issue with Icons Display
|     
|     This commit addresses an issue where icons were not displaying correctly if a property has other attributes.
|     
|     Changes include modifications to several files:
|     - `Editor/Animation/AnimationParameterDrawer.cs`
|     - `Editor/Attributes/Properties/DropDownSelection/InputAxisPropertyDrawer.cs`
|     - `Editor/Attributes/Properties/DropDownSelection/SceneAttributePropertyDrawer.cs`
|     - `Editor/Attributes/Properties/DropDownSelection/TagAttributePropertyDrawer.cs`
|     - `Editor/Attributes/Properties/FolderPathAttributeDrawer.cs`
|     - `Editor/Attributes/Properties/Modifiers/ReadOnlyPropertyDrawer.cs`
|     - `Editor/Attributes/Properties/RequiredReferencePropertyDrawer.cs`
|     - `Editor/Attributes/Properties/ShowIfBoolPropertyDrawer.cs`
|     - `Editor/Attributes/Properties/ShowIfEnumPropertyDrawer.cs`
|     - `Editor/Inspector/ButtonAttributeHelper.cs` (previously Inspector Button/ButtonAttributeHelper.cs)
|     - `Editor/Inspector/ScriptableObjectButtonsEditor.cs`
|     - `Editor/Inspector/UIElementsCustomEditor.cs`
|     - `Editor/PropertyDrawerHelper.cs`
|     
|     Additionally, the following changes were made:
|     - `Editor/Inspector/AttributeMonoBehaviourInspector.cs` and its corresponding meta file were added.
|     - `Editor/Inspector/AttributeScriptableObjectInspector.cs` and its corresponding meta file were added.
|     - `Editor/Inspector/ButtonAttributeHelper.cs` (previously Inspector Button/ButtonAttributeHelper.cs) and its corresponding meta file were renamed.
|     - `Samples/Attributes/Scripts/AttributesExample.cs` was modified.
|     
|     These modifications ensure that icons are properly displayed even when properties have other attributes.
| 
* commit 4549e8226617e97357b1974ef5224f30fd9a12a7
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 19:53:11 2022 -0400
| 
|     feat(Samples, Attributes): Add Tag Example
|     
|     This commit introduces a Tag Example to the project.
|     It modifies the `Samples/Attributes/AttributesExample.unity` file to incorporate the Tag Example.
|     Additionally, it adds `TagExample.cs` along with its corresponding meta file, `TagExample.cs.meta`,
|     under `Samples/Attributes/Scripts/Properties/Drop Down Selection/`.
|     
|     The Tag Example showcases how to utilize tag properties with attributes
|     providing developers with a practical demonstration of integrating tag-related functionality into their Unity projects.
|     
|     Furthermore, the `README.md` file in the `docs` directory is updated to reflect the addition of the Tag Example.
| 
* commit 191376f132605b55e10f74dd4c8519bde561159f
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 19:37:51 2022 -0400
| 
|     feat(Samples, Attributes): Add Scene Example
|     
|     This commit adds a Scene Example to the project.
|     It modifies the `Samples/Attributes/AttributesExample.unity` file to include the Scene Example.
|     Additionally, it introduces `SceneExample.cs` and its corresponding meta file
|      `SceneExample.cs.meta` under `Samples/Attributes/Scripts/Properties/Drop Down Selection/`.
|     
|     The Scene Example demonstrates how to utilize scene properties with
|     attributes, offering developers a practical demonstration of integrating
|     scene-related functionality into their Unity projects.
|     
|     Furthermore, the `README.md` file in the `docs` directory is updated to reflect
|     the addition of the Scene Example.
| 
* commit e370bbdfa78b785a91d860a63175eaaf86839e9e
| Author: James LaFritz <ktmarine1999+git@gmail.com>
| Date:   Tue Feb 6 19:43:20 2024 -0500
| 
|     chore: Update Rider IDE config files
| 
* commit c319d2a38c75edc30f03f5ac37b86b4d12b6b53e
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 19:23:45 2022 -0400
| 
|     feat(Samples, Attributes): Create Input Axis Example
|     
|     This commit adds an Input Axis Example to the project. It modifies the Samples/Attributes/AttributesExample.unity file to include the Input Axis Example. Additionally, it introduces InputAxisExample.cs and its corresponding meta file InputAxisExample.cs.meta under Samples/Attributes/Scripts/Properties/Drop Down Selection/.
|     
|     This example demonstrates how to use input axis properties with attributes, providing developers with a practical reference for implementing input handling in their Unity projects.
|     
|     Furthermore, the README.md file in the docs directory is modified to reflect the addition of the Input Axis Example.
| 
* commit 0eab5a580a47b06a80c998388cee33e306838bc5
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 19:23:10 2022 -0400
| 
|     refactor(AnimatorParameterAttribute.cs): Move Animator Parameter Attribute with Animation related files
|     
|     This commit refactors the project structure by relocating the AnimatorParameterAttribute.cs file
|     from the Runtime/Attributes/Properties/Drop Down Selection/ directory to the Runtime/Animation/ directory.
|     
|     This change ensures better organization and alignment of files related to animation within the project.
| 
* commit fdd6764a3e0a2b439c4edb40d0e8d8ffb80d59ca
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Sat Aug 13 14:47:30 2022 -0400
| 
|     feat(Attribute, Destroy, Interactable, Extensions, Functional)!: Add new files related to attribute decorators and properties, Destroy system, Interactable system, and Extension methods
|     
|     This commit introduces several new files related to attribute decorators and properties in the editor and runtime sections of the project.
|     These files include implementations for various attribute decorators such as HeaderAttribute and InfoBoxAttribute, as well as property drawers
|     for handling specific types of attributes like DropDownSelection and FolderPathAttribute.
|     
|     Additionally, this update includes the implementation of the Destroy system, which consists of DestroyAfterTime.cs and DestroyNoChildren.cs.
|     These components provide functionality to destroy game objects in Unity, offering flexibility in managing object lifecycles.
|     
|     Furthermore, the Interactable system is introduced, featuring Interactable.cs,
|     which allows for interaction with objects within the Unity game environment, enhancing user engagement and gameplay dynamics.
|     
|     Lastly, extension methods such as ArrayExtensions.cs, QuaternionExtensions.cs, TextExtensions.cs, and Vector4Extensions.cs are added.
|     These extensions augment the project with additional functionality, making development tasks more streamlined and efficient.
|     
|     This major update ensures compatibility with Unity 2022 and enhances the project's extensibility, usability, and overall functionality.
|     
|     BREAKING CHANGE: This update introduces significant changes to the project structure and functionality. Developers relying on the previous implementation may need to update their code and configurations to accommodate these changes.
| 
* commit 755436346000f481c58fc3ed305052266ffd8b07
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Tue Jul 19 03:50:39 2022 -0400
| 
|     docs: Update README
| 
* commit 1f95977f42d5fee2f05fc81a70406663d0780d8e
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Tue Jul 19 03:38:36 2022 -0400
| 
|     docs: Edit "Asset Licenseses" and "Third Party Notices"
| 
* commit be8f491e028e6e5be8122ee1bc61c3596672d761
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Tue Jul 19 02:44:45 2022 -0400
| 
|     docs: Change Log Update
| 
* commit 368f0e795b147566fd218acc6cb4aea7a2b5cc4e
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Tue Jul 19 02:36:12 2022 -0400
| 
|     doc: Documentation Configuration.
|     
|     docfx change documentation
| 
* commit a2babc9c16d8fbf1e9826823545da7db80d22e76
| Author: James LaFritz <ktmarine1999@gmail.com>
| Date:   Mon Jul 18 19:45:43 2022 -0400
| 
|     doc: Initial documentation Commit
| 
* commit 8c10ff2ca30ae6cbe591bafa3c6d35fcea718017
  Author: James LaFritz <ktmarine1999@gmail.com>
  Date:   Mon Jul 18 16:30:47 2022 -0400
  
      Initial commit
