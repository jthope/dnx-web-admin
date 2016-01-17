using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNX_Admin.Web.ViewComponents {
	
	public class Navigation : ViewComponent {

		public class Menu {
			
			public List<MenuItem> Items { get; }

			public Menu(List<MenuItem> items) {
				Items = items;
			}

		}

		public class MenuItem {

			private List<MenuItem> _children;

			public string Name { get; }
			public string Controller { get; }
			public string Action { get; }
			public string IconCssClass { get; set; }
			public MenuItem Parent { get; set; }

			public List<MenuItem> Children {

				get { return _children; }

				set {

					if (value != null) {

						if (_children == null) {
							_children = new List<MenuItem>();
						}

						value.ForEach(item => {

							item.Parent = this;
							_children.Add(item);

						});

					}

				}

			}

			public MenuItem(string name, string controller, string action, string iconCssClass, MenuItem parent = null, List<MenuItem> children = null) {
				Name = name;
				Controller = controller;
				Action = action;
				IconCssClass = iconCssClass;
				Parent = parent;
				Children = children;
			}

		}

		public async Task<IViewComponentResult> InvokeAsync() {

			var navigationItems = await Task.Run(() => new List<MenuItem>() {

				new MenuItem("Home", "Home", "Index", "fa fa-home"),
				new MenuItem("Sandbox", "Sandbox", "Index", "fa fa-cogs"),
				new MenuItem("Multi", "Multi", "Index", "fa fa-home") {
					Children = new List<MenuItem>() {
						new MenuItem("Multi 1", "Multi1", "Index", "fa fa-home") {
							Children = new List<MenuItem>() {
								new MenuItem("Multi 2", "Multi2", "Index", "fa fa-home")
							}
						}
					}
				},			

			});

			var viewModel = new Menu(navigationItems);

			return View(viewModel);

		}

		public async Task<IViewComponentResult> InvokeAsync(List<MenuItem> items = null) {

			var navigationItems = await Task.Run(() => new List<MenuItem>());

			if (items != null) {
				
				navigationItems = items;

			}

			var viewModel = new Menu(navigationItems);

			return View(viewModel);

		}

	}

}
