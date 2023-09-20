using Web.Repositories;

namespace Blazor.WEB.Repositories
{
    public interface IRepository
    {
        //Metodo 'Get' funcionara para todos los modelos empleados en el proyecto
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        // 2 metodos 'Post' ya que aveces devuelve respuesta y aveces no
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);

    }
}
