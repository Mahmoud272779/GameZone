﻿using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModel
{
	public class CreateGameFormViewModel
	{
		[MaxLength(250)]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

		[Display(Name = "Supported Devices")]
		public List<int> SelectedDevices { get; set; } = default!;

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

		[MaxLength(2500)]
		public string Description { get; set; } = string.Empty;

		[AllowedExtensions(Settings.AllowedExtensions)]
		public IFormFile Cover { get; set; } = default!;
	}
}
