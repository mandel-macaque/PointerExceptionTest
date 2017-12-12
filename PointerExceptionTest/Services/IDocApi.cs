using System.Threading.Tasks;
using Refit;

namespace PointerExceptionTest.Services
{
	public interface IDocApi
	{
		[Get ("/")]
		Task<string> GetApiDescription ();
	}
}
