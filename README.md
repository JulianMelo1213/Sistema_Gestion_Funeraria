# Sistema de Gestión de Funeraria

El **Sistema de Gestión de Funeraria** es una aplicación web desarrollada con .NET que ofrece funcionalidades para la reserva de salas de velatorios de forma online. La aplicación permite a los usuarios reservar salas de velatorio de diferentes categorías y obtener servicios personalizados, junto con la digitalización de la famosa hoja de firmas de velatorios usada en República Dominicana.

## Participantes 👩‍🎓👨‍🎓

<a href="https://github.com/JulianMelo1213/Sistema_Gestion_Funeraria/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=JulianMelo1213/Sistema_Gestion_Funeraria" />
</a>

## Configuración del Entorno

### Requisitos

- C# (versión 12).
- .NET (versión 8.0).
- SQL Server (versión 2019).

### Instalación

1. Crear un directorio para el proyecto:

```sh
mkdir Proyecto
cd Proyecto
```

2. Clonar el repositorio:

```sh
git clone https://github.com/JulianMelo1213/Sistema_Gestion_Funeraria.git
```

3. Navegar al directorio del proyecto:

```sh
cd 'Sistema_Gestion_Funeraria'
```

4. Restaurar los paquetes NuGet si es necesario:

```sh
dotnet restore
```

5. Implementar las migraciones:

```sh
dotnet ef database update
```

6. Ejecutar el proyecto:

```sh
dotnet watch run
```

## Pendientes del Proyecto

### BackEnd

- [x] Análisis de requirimiento para la construcción de la Base de Datos.
- [ ] Implementación de los DTO de cada modelo y su respectivo mapeo con AutoMapper.
- [x] Creación de los Controladores de los Modelos.
- [x] Implementación de capa de autenticación con JWT (JSON Web Token).
- [x] Implementación de Politicas de Autorización y Roles.

### FrontEnd

- [ ] Implementación de formularios de reserva
- [ ] Visualización de disponibilidad de salas

## Stack Tecnológico

- **C#**: Un lenguaje de programación moderno y de propósito general.
- **.NET**: Una plataforma de desarrollo gratuita y de código abierto para la creación de diferentes tipos de aplicaciones.
- **SQL Server**: Un sistema de gestión de bases de datos relacional desarrollado por Microsoft.
- **JWT**: (JSON Web Token) Un estándar abierto para la creación de tokens de acceso que permiten la transmisión segura de información entre partes como un objeto JSON.

[![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)](https://dotnet.microsoft.com/en-us/languages/csharp)
[![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
[![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)](https://jwt.io/)
