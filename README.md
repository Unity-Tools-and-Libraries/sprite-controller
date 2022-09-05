# sprite-controller
An alternative to the SpriteResolver component provided in Unity.

I created this component because of what a pain in the ass controlling the properties of a [https://docs.unity3d.com/Packages/com.unity.2d.animation@3.0/api/UnityEngine.Experimental.U2D.Animation.SpriteResolver.html](SpriteResolver) via the animation system was.

## How to use
Attach this to the object whose Sprite Renderer will be controlled. A Sprite Library component is also required.

Add the categories and labels of the sprite library that will be used to the Categories and Labels properties. At runtime, set the `CategoryIndex` and `LabelIndex` to select the category and label to use;
these will be used to get the sprite from the library.
