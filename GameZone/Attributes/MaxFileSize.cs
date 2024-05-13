using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class MaxFileSize :ValidationAttribute
	{
		private readonly int _maxFileSize;

		public MaxFileSize(int maxFileSize)
		{
			_maxFileSize = maxFileSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile; 

			if (file != null) 
			{
				if (file.Length > _maxFileSize)
				
				{
					return new ValidationResult($"Max size allowed={Settings.MaxFileSizeInBytes} bytes!");
				}
			}

			return ValidationResult.Success;
		}
	}
}
