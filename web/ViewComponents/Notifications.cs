using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNX_Admin.Web.ViewComponents {

	public class Notifications : ViewComponent {

		public class Menu {

			public List<MenuItem> Items { get; }

			public Menu(List<MenuItem> items) {
				Items = items;
			}

		}

		public class MenuItem {

			public string Title { get; set; }
			public string IconCssClass { get; set; }

			public MenuItem(string title, string iconCssClass = "") {
				Title = title;
				IconCssClass = iconCssClass;
			}

		}

		public async Task<IViewComponentResult> InvokeAsync() {

			var items = await Task.Run(() => new List<MenuItem>() {
				new MenuItem("5 new members joined today", "fa fa-users text-aqua"),
				new MenuItem("Very long description here that may not fit into the page and may cause design problems", "fa fa-warning text-yellow"),
				new MenuItem("5 new members joined", "fa fa-users text-red"),
				new MenuItem("25 sales made", "fa fa-shopping-cart text-green"),
				new MenuItem("You changed your username", "fa fa-user text-red")
			});

			var viewModel = new Menu(items);

			return View(viewModel);

		}

	}

}
