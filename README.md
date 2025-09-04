# RealState - README

* Autor: Juan Hernández
* Rol: Senior .NET Developer

Teniendo en cuenta el documento con el ejercicio práctico a resolver se construye un MVP con APIs para la Compañía Real Estate con información de propiedades en los Estados Unidos.

Para este fin, se diseñó y desarrollo APIs con .NET 9 aplicando Arquitectura Hexagonal, CQRS con MediatR, EF Core, validaciones con FluentValidation y autenticación JWT. Enfocado en mantenibilidad, pruebas automatizadas (NUnit) y buenas prácticas (SOLID, separación de capas, DTOs, mapeo automático, recursos/strings localizables).

# Arquitectura

Se hizo uso de Arquitectura Hexagonal (Puertos y adaptadores) con las siguientes capas:

* Domain
* Infrastructure
* Application
* Contracts
* Api
 
# Patrones y prácticas

* SOLID y separación de responsabilidades.
* CQRS (Commands/Queries + Handlers).
* Repository + UoW (UoW via behavior/SaveChanges).
* DTOs + Mapeo automático (Mapster).
* Validaciones (FluentValidation en Application).
* Resources para mensajes/códigos (localizables).
* Seguridad: JWT (HS256)
* Performance: consultas AsNoTracking

# Herramientas utilizadas

* .NET 9 (C# 13)
* Entity Framework Core
* SQL Server
* MediatR
* FluentValidation
* Mapster
* JWT
* Swagger
* Options & Binder
* NUnit

# Pasos de ejecución del proyecto (MVP)

## Requisitos
* .NET SDK 9
* SQL Server (Local)

## Pasos
* Clonar repositorio
* Limpiar y compilar solución
* Ejecutar el siguiente comando para crear la base de datos desde cero (CodeFirst)

```bash
dotnet ef database update --project src/RealState.Infrastructure --startup-project src/RealState.Api

```
* Una vez ejecutado el comando, desplegar el MVP teniendo como proyecto de Arranque RealState.Api.
* Una vez ejecutado, los datos semillas se insertarán en las tablas de base de datos incluyendo los datos de Usuario Administrador para obtener el Token de seguridad.
* Usuario: admin@realstate.com | Contraseña: RealState$123
* Copiar AccessToken de la respuesta.
* En Swagger, click Authorize → pegar el token (solo el valor, sin “Bearer ”).
* Consumir endpoints protegidos.

# Endpoint principales
## Owner
* Create
* Deactivate
* Delete
* GetAll
* Update

## Property
* AddImage
* ChangePrice
* Create
* GetAll
* Update
* UploadImage

## User
* Login
