# Functional Testing

Además de tests unitarios, es importante que garanticemos a nivel funcional que nuestro sistema funciona. Para ello dentro del ecosistema de AspNetCore tenemos el paquete `Microsoft.AspNetCore.TestHost` con la clase TestServer que utilizaremos para crear nuestro servidor en los tests.

Lo primero que haremos será crear un Startup para los tests:

``` csharp

public class TestStartup
{
  public void ConfigureServices(IServiceCollection services)
  {
  }

  public void Configure(IApplicationBuilder app)
  {
  }
}

```

A este Startup necesitamos añadirle la configuración de la API y la configuración específica para los tests. En este ejemplo solo tenemos la cadena de conexión a la base de datos pero en una aplicación real podríamos tener múltiples variables de configuración. Esta configuración la podemos añadir por medio de algún provider (en memoria, json, environment variables...). Para este ejemplo utilizaremos el provider de `Microsoft.Extensions.Configuration.Json` y añadiremos un appsettings.json quedando finalmente la clase TestStartup:

``` cs
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

                CarShopApiConfiguration.ConfigureServices(services, configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            CarShopApiConfiguration.Configure(app, host => host);
        }
    }

```

``` json
{
  "ConnectionStrings": {
    "CarShop": "Server=(localdb)\\mssqllocaldb;Database=CarShop; Integrated Security = SSPI;MultipleActiveResultSets=true;Connect Timeout=10;"
  }
}
```

Una vez tenemos configurado un TestStartup ya podemos comenzar a desarrollar un test funcional.

## Respawn

Un test no debería ser afectado por el resultado de otro test. Evitar esto, cuando trabajamos con bases de datos, puede ser algo tedioso. Respawn es una librería desarrollada por Jimmy Bogard que nos permite restaurar la base de datos a un punto anterior.

``` cs
private static Checkpoint _checkpoint = new Checkpoint
{
    TablesToIgnore = new[]
    {
        "__EFMigrationsHistory"
    }
};
```
