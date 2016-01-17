using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNX_Admin.Web.ViewComponents {

	public class Messages : ViewComponent {

		public class Menu {

			public List<MenuItem> Items { get; }

			public Menu(List<MenuItem> items) {
				Items = items;
			}

		}

		public class MenuItem {

			public string Title { get; set; }
			public string Text { get; set; }
			public string CssClass { get; set; }
			public string ImageUrl { get; set; }
			public DateTime Date { get; set; }

			public MenuItem(string title, string text, string cssClass = "", string imageUrl = "", DateTime date = default(DateTime)) {
				Title = title;
				Text = text;
				CssClass = cssClass;
				ImageUrl = imageUrl;
				Date = date;
			}

		}

		public async Task<IViewComponentResult> InvokeAsync() {

			var items = await Task.Run(() => new List<MenuItem>() {
				new MenuItem("Support Team", "Why not buy a new awesome theme?", "img-circle", "~/lib/admin-lte/dist/img/user2-160x160.jpg", DateTime.Now),
				new MenuItem("AdminLTE Design Team", "Why not buy a new awesome theme?", "img-circle", "~/lib/admin-lte/dist/img/user3-128x128.jpg", DateTime.Now),
				new MenuItem("Developers", "Why not buy a new awesome theme?", "img-circle", "~/lib/admin-lte/dist/img/user4-128x128.jpg", DateTime.Now),
				new MenuItem("Sales Department", "Why not buy a new awesome theme?", "img-circle", "~/lib/admin-lte/dist/img/user3-128x128.jpg", DateTime.Now),
				new MenuItem("Reviewers", "Why not buy a new awesome theme?", "img-circle", "~/lib/admin-lte/dist/img/user2-160x160.jpg", DateTime.Now)
			});

			var viewModel = new Menu(items);

			return View(viewModel);

		}

	}

}
