using System;
using System.Net.Http;
using Refit;

namespace PointerExceptionTest.Services
{
	public class WebApiFactory: IWebApiFactory
	{
		public static Func<HttpMessageHandler> CreateHttpHandler = () => throw new NotImplementedException ();

		public T Create<T> ()
		{
			var url = "https://on-demand-cargo.herokuapp.com/api";
			var handler = CreateHttpHandler.Invoke ();
			var httpClient = new HttpClient(handler) 
			{
				BaseAddress = new Uri (url)
			};
			return RestService.For<T> (httpClient);
		}
	}
}

