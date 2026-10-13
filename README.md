# Detalle Mascotas

Aplicación web en ASP.NET MVC 5 para registrar propietarios y sus mascotas. En un solo formulario se ingresan los datos del propietario y se agregan una o varias mascotas, que se guardan juntas en la base de datos.

## Tecnologías

- ASP.NET MVC 5 sobre .NET Framework 4.7.2
- Entity Framework 6 (Database First, modelo `DBModel.edmx`)
- SQL Server
- Bootstrap 5 y jQuery

## Requisitos

- Windows con Visual Studio 2022 (carga de trabajo **ASP.NET y desarrollo web**)
- SQL Server (Express, Developer o LocalDB)

## Configuración

### 1. Crear la base de datos

Ejecuta este script en SQL Server Management Studio:

```sql
CREATE DATABASE PetFinder;
GO
USE PetFinder;
GO
CREATE TABLE dbo.Owner (
    OwnerId   int IDENTITY PRIMARY KEY,
    OwnerName varchar(100),
    Direction varchar(150),
    Phone     varchar(100)
);
CREATE TABLE dbo.Pet (
    PetId   int IDENTITY PRIMARY KEY,
    PetName varchar(100),
    age     int,
    color   varchar(100),
    OwnerId int REFERENCES dbo.Owner(OwnerId)
);
```

### 2. Ajustar la cadena de conexión

En `DetalleMascotas/Web.config`, dentro de `<connectionStrings>`, cambia `data source=DESKTP-KCH` por el nombre de tu servidor SQL. Por ejemplo:

- SQL Server local: `data source=.`
- SQL Express: `data source=.\SQLEXPRESS`
- LocalDB: `data source=(localdb)\MSSQLLocalDB`

La cadena usa autenticación de Windows (`integrated security=True`).

### 3. Ejecutar

1. Abre `DetalleMascotas.sln` en Visual Studio.
2. Compila la solución. La primera vez, Visual Studio restaura los paquetes NuGet y genera las carpetas `bin/` y `obj/`, que no están en el repositorio.
3. Presiona **F5** y navega a `/Maestro/Add`.

## Uso

1. Escribe el nombre del propietario (obligatorio), su dirección y su teléfono.
2. En la sección **Mascotas**, escribe nombre, edad y color, y presiona **Add**. Repite para cada mascota. Con **Remove** quitas una de la lista.
3. Presiona **Submit**. Si todo está bien, aparece el mensaje *Register added successfully*.

El nombre del propietario y el de cada mascota son obligatorios. Si falta el del propietario, el formulario muestra el error y conserva las mascotas agregadas.

## Estructura

```
DetalleMascotas/
├── Controllers/
│   ├── HomeController.cs       Páginas de inicio, About y Contact
│   └── MaestroController.cs    Registro de propietario y mascotas
├── Models/
│   ├── DBModel.edmx            Modelo de Entity Framework (Owner, Pet)
│   ├── Owner.cs, Pet.cs        Entidades generadas
│   └── ViewModel/              Modelos del formulario
└── Views/
    └── Maestro/Add.cshtml      Formulario de registro
```

## Limitaciones conocidas

- ASP.NET rechaza cualquier campo que contenga `<` y muestra una página de error.
- Por ahora solo se pueden agregar registros; no hay pantallas para listarlos, editarlos ni eliminarlos.
