using System;
using UnityEngine;
using UnityEngine.U2D.Animation;
namespace io.github.thisisnozaku.sprites {
	[ExecuteAlways]
	public class SpriteController : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		[SerializeField]
		private SpriteLibrary spriteLibrary;

		[Tooltip("The index of the category. Used as the index to fetch the string from the Categories that is used to fetch from the sprite library.")]
		public int CategoryIndex;
		[Tooltip("The index of the label. Used as the index to fetch the string from the Labels that is used to fetch from the sprite library.")]
		public int LabelIndex;

		public string[] Categories;
		public string[] Labels;

		[Tooltip("This controller will also control these controllers.")]
		public SpriteController[] descendentControllers;

		// Update is called once per frame
		void Update()
		{
			if (Categories.Length > 0)
			{
				string spriteCategory = Categories[CategoryIndex];
				string spriteLabel = Labels.Length > 0 ? Labels[LabelIndex] : LabelIndex.ToString();
				if (spriteRenderer != null && spriteLibrary != null)
				{
					UpdateSprite(spriteCategory, spriteLabel);
				}
				foreach (var controlled in descendentControllers)
				{
					controlled.CategoryIndex = CategoryIndex;
					controlled.LabelIndex = LabelIndex;
					controlled.UpdateSprite(spriteCategory, spriteLabel);
				}
			}
		}

		public void UpdateSprite(string spriteCategory, string spriteLabel)
        {
			try
			{
				if(Application.isEditor)
                {
					// Trigger a regeneration of the cache. Avoids a Null ref exception in the editor.
					var original = spriteLibrary.spriteLibraryAsset;
					spriteLibrary.spriteLibraryAsset = null;
					spriteLibrary.spriteLibraryAsset = original;
				}
				
				spriteRenderer.sprite = spriteLibrary.GetSprite(spriteCategory, spriteLabel);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(string.Format("Failed to update sprite."), ex);
			}
		}
	}
}