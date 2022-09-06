using System;
using UnityEngine;
using UnityEngine.U2D.Animation;
namespace io.github.thisisnozaku.sprites {
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(SpriteLibrary))]
	public class SpriteController : MonoBehaviour
	{
		private SpriteRenderer spriteRenderer;
		private SpriteLibrary spriteLibrary;

		[Tooltip("The index of the category. Used as the index to fetch the string from the Categories that is used to fetch from the sprite library.")]
		public int CategoryIndex;
		[Tooltip("The index of the label. Used as the index to fetch the string from the Labels that is used to fetch from the sprite library.")]
		public int LabelIndex;

		public string[] Categories;
		public string[] Labels;

		// Start is called before the first frame update
		void Start()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			spriteLibrary = GetComponent<SpriteLibrary>();
		}

		// Update is called once per frame
		void Update()
		{
			try
			{
				string spriteCategory = Categories[CategoryIndex];
				string spriteLabel = Labels.Length > 0 ? Labels[LabelIndex] : LabelIndex.ToString();
	
				spriteRenderer.sprite = spriteLibrary.GetSprite(spriteCategory, spriteLabel);
			} catch (Exception ex)
			{
				throw new InvalidOperationException(string.Format("Failed to update sprite."), ex);
			}
		}
	}
}