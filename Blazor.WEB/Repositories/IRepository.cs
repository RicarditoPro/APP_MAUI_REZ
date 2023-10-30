using Web.Repositories;

namespace Blazor.WEB.Repositories
{
    public interface IRepository
    {
        //Metodo 'Get' funcionara para todos los modelos empleados en el proyecto
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        // 2 metodos 'Post' ya que aveces devuelve respuesta y aveces no
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);

        //POST que devuele respuesta
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);

        //DELETE
        Task<HttpResponseWrapper<object>> Delete(string url);

        //PUT
        Task<HttpResponseWrapper<object>> Put<T>(string url, T model);

        //PUT QUE DEVUELVE RESPUESTA
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model);




    }
}
