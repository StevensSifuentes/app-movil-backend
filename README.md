# Gestión de Trabajadores - Backend -App móvil

API REST desarrollada con **ASP.NET Core Web API** y **SQL Server**, que funciona como backend para una aplicación móvil Android nativa (**Kotlin**). Implementa autenticación propia mediante **JWT** y **BCrypt** para el hash de contraseñas, y expone los módulos de **Usuarios** (registro y autenticación) y **Trabajadores** (registro, listado), aplicando arquitectura en capas con patrón **Repository**.

## Tecnologías

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT (JSON Web Tokens)
- BCrypt (hash de contraseñas)
- Patrón Repository

## Estructura del proyecto

```
GestionTrabajadoresAPI/
├── Controllers/
├── Data/
│ ├── Repository/
│ │ └── IRepository/
│ └── ApplicationDbContext.cs
├── DTOs/
├── Models/
└── Services/
     └── IServices/
```

## Funcionalidades principales

- Registro y autenticación de usuarios
- Autenticación basada en JWT
- Registro y listado de trabajadores asociados a cada usuario
