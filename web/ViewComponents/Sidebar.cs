using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNX_Admin.Web.ViewComponents {

	public class Sidebar : ViewComponent {

		public class ViewModel {

			public string Name { get; set; }
			public string UserImageUrl { get; set; }
			public string UserImageCssClass { get; set; }
			public string NavigationHeaderTitle { get; set; }

			public ViewModel(string name, string userImageUrl, string userImageCssClass, string navigationHeaderTitle) {
				Name = name;
				UserImageUrl = userImageUrl;
				UserImageCssClass = userImageCssClass;
				NavigationHeaderTitle = navigationHeaderTitle;
			}

		}

		public async Task<IViewComponentResult> InvokeAsync() {

			var viewModel = new ViewModel("Alexander Pierce", "~/lib/admin-lte/dist/img/user2-160x160.jpg", "img-circle", "Main Navigation");

			return View(viewModel);

		}

	}


}
