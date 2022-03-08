using Common.Data;
using Microsoft.Extensions.DependencyInjection;

public static class ITodoServiceFactory {

    public static ITodoService Create() =>  new TodoService(null, null);
}

public static class ServiceCollectionExtensions_EfLibrary {
    public static IServiceCollection AddDataServices(this IServiceCollection svc) {
        svc.AddTransient<ITodoService, TodoService>();
        return svc;
    }
}