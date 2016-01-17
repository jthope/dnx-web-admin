using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNX_Admin.Web.ViewComponents {

	public class Users : ViewComponent {

		public class Menu {

			public string Name { get; set; }
			public string Title { get; set; }
			public string ImageUrl { get; set; }

			public List<MenuItem> Items { get; }
			
			public Menu(string name, string title, string imageUrl, List<MenuItem> items) {
				Name = name;
				Title = title;
				ImageUrl = imageUrl;
				Items = items;
			}

		}

		public class MenuItem {

			public string Name { get; set; }
			public string Controller { get; set; }
			public string Action { get; set; }

			public MenuItem(string name, string controller, string action) {
				Name = name;
				Controller = controller;
				Action = action;
			}

		}

		public async Task<IViewComponentResult> InvokeAsync() {

			var items = await Task.Run(() => new List<MenuItem>() {
				new MenuItem("Profile", "Profile", "Index"),
				new MenuItem("Signout", "Signout", "Index")
			});
			
			var viewModel = new Menu("Alexander Pierce",
									 "Web Developer",
									 "~/lib/admin-lte/dist/img/user2-160x160.jpg",
									 items);

			return View(viewModel);

		}

	}

}
