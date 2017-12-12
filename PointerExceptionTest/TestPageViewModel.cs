using System;
using System.ComponentModel;
using PointerExceptionTest.Services;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PointerExceptionTest
{
	public class TestPageViewModel
	{
		readonly IDocApi docApi;
		readonly IWebApiFactory webFactory; 

		public TestPageViewModel ()
		{
			webFactory = new WebApiFactory ();
			docApi = webFactory.Create<IDocApi> ();
		}

		public ICommand TestCommand => new Command (() => OnTest ());

		async Task OnTest ()
		{
			System.Diagnostics.Debug.WriteLine ("Started...");
			int i = 0;
			while (i < 500)
			{
				i++;

				int k = i;
				await Task.Delay (5).ContinueWith (async t =>
				{
					System.Diagnostics.Debug.WriteLine ("Started request " + k);

					await docApi.GetApiDescription ().ContinueWith (task =>
					{
					if (task.IsFaulted)
					{
						System.Diagnostics.Debug.WriteLine ($"Failed request {k}:\n { task.Exception.InnerException}");
						}
						else if (task.IsCompleted)
						{
							System.Diagnostics.Debug.WriteLine ("Successfull request! " + k);
						}
					});
				});
			}
		}
	}
}
