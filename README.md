# Documentación del Proyecto: Servicio-backend

## Arquitectura General

El proyecto `Servicio-backend` está estructurado siguiendo un enfoque clásico de **arquitectura en capas (layered architecture)**, dividiendo claramente las responsabilidades en diferentes módulos o librerías. Este tipo de organización facilita el mantenimiento, la escalabilidad y la reutilización de código.

### Capas Principales

1. **DomainModel**
   - Aquí se encuentran las entidades y modelos de dominio, es decir, las representaciones de los datos y objetos principales del negocio. 
   - Esta capa es independiente de frameworks externos, asegurando que los objetos del dominio no dependan de detalles de implementación.

2. **Repository**
   - Define las interfaces y las implementaciones para el acceso a datos.
   - Su responsabilidad es abstraer la interacción con las fuentes de datos (por ejemplo, bases de datos, archivos, servicios externos).
   - Se utilizan interfaces como `ICityRepository` para desacoplar la lógica de acceso a datos del resto del sistema.

3. **BusinessLayer**
   - Contiene la lógica de negocio de la aplicación.
   - Implementa los servicios que orquestan y aplican las reglas del dominio, utilizando los repositorios definidos en la capa anterior.
   - Ejemplo de servicios: `ClientService`, `DistanceService`.

4. **API/Web Layer (Servicio-backend)**
   - Es el punto de entrada de la aplicación y expone los endpoints HTTP (usando ASP.NET Core).
   - En este nivel se configuran los servicios, la inyección de dependencias y la documentación Swagger. 
   - Se encarga de recibir las solicitudes, delegar la lógica al BusinessLayer y devolver las respuestas apropiadas al cliente.

### Diagrama de Capas (Conceptual)

```
[Cliente HTTP]
      |
      v
[API/Web Layer] <-----> [BusinessLayer] <-----> [Repository] <-----> [DomainModel]
```

- **API/Web Layer**: Recibe peticiones, controla el acceso, y expone documentación (Swagger).
- **BusinessLayer**: Procesa la lógica de negocio y coordina operaciones.
- **Repository**: Acceso a datos, ya sea base de datos, archivos o servicios externos.
- **DomainModel**: Define las entidades del dominio y las reglas básicas.

---

## Funcionamiento General

1. **Configuración e Inicio**
   - El arranque de la aplicación se realiza en `Program.cs`, donde se configuran los servicios, se habilita CORS, y se inicializan herramientas como Swagger para documentación.
   - Se aplican políticas de CORS para permitir el acceso desde orígenes específicos.

2. **Inyección de Dependencias**
   - Se registra cada interfaz con su implementación correspondiente (por ejemplo, `ICityRepository` con `CityRepository`).
   - Esto permite desacoplar las dependencias, facilitando pruebas y mantenimiento.

3. **Manejo de Solicitudes**
   - Cuando un cliente realiza una petición HTTP, la capa API la recibe y redirige la operación al servicio correspondiente en el BusinessLayer.
   - Los servicios del BusinessLayer aplican la lógica de negocio y utilizan la capa Repository para acceder o modificar datos.
   - Finalmente, la respuesta se retorna al cliente en el formato adecuado.

4. **Documentación y Herramientas**
   - Swagger está integrado para facilitar la exploración y prueba de los endpoints.
   - Se utiliza un logger de consultas (ejemplo: `FileQueryLogger`) para registrar operaciones y facilitar auditoría o debugging.

---

## Resumen

- **Separación clara de responsabilidades**: Cada capa tiene un rol definido (modelado de dominio, acceso a datos, lógica de negocio, exposición de endpoints).
- **Escalabilidad y mantenibilidad**: Gracias al uso de interfaces y la inyección de dependencias, se pueden agregar nuevas funcionalidades o adaptar las existentes con mínimo impacto en el resto del sistema.
- **Buenas prácticas de desarrollo**: Uso de políticas de CORS, documentación Swagger, y patrones de diseño estándar.

---

### Ejemplo de Registro de Servicios en `Program.cs`

```csharp
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDistanceService, DistanceService>();
builder.Services.AddScoped<IQueryLogger, FileQueryLogger>();
```
