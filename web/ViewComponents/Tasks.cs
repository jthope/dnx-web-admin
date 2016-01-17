using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNX_Admin.Web.ViewComponents {

	public class Tasks : ViewComponent {

		public class Menu {

			public List<MenuItem> Items { get; }

			public Menu(List<MenuItem> items) {
				Items = items;
			}

		}

		public class MenuItem {

			public string Title { get; set; }
			public string Progress { get; set; }
			public string ProgressCssClass { get; set; }

			public MenuItem(string title, string progress, string progressCssClass) {
				Title = title;
				Progress = progress;
				ProgressCssClass = progressCssClass;
			}

		}

		public async Task<IViewComponentResult> InvokeAsync() {

			var items = await Task.Run(() => new List<MenuItem>() {
				new MenuItem("Design some buttons", "20", "progress-bar progress-bar-aqua"),
				new MenuItem("Create a nice theme", "40", "progress-bar progress-bar-green"),
				new MenuItem("Some task I need to do", "60", "progress-bar progress-bar-red"),
				new MenuItem("Make beautiful transitions", "80", "progress-bar progress-bar-yellow")
			});

			var viewModel = new Menu(items);

			return View(viewModel);

		}

	}

}
