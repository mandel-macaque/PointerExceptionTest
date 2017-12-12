namespace PointerExceptionTest.Services
{
	public interface IWebApiFactory
	{
		T Create<T> ();
	}
}

