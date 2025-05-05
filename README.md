# 🛒 API de Productos y Categorías

Este proyecto es una API RESTful construida con ASP.NET Core y Entity Framework Core. Permite la gestión de productos y categorías: crear, obtener, editar y eliminar registros.

## 🚀 Tecnologías utilizadas

- ASP.NET Core
- Entity Framework Core
- MySQL
- Swagger para documentación de endpoints

---

## 📦 ¿Qué hace este proyecto?

- Agregar, obtener, actualizar y eliminar productos.
- Agregar, obtener, actualizar y eliminar categorías.
- Validaciones automáticas mediante anotaciones.
- Respuestas con fromato estándar (`ResponseEntity`).
- Validaciones personalizadas con filtros globales.

---

## 🛠️ ¿Cómo ejecutar el proyecto?

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo

### 2. Cambiar la cadena de conexión

En el archivo appsettings.json, cambiar la cadena de conexión con los datos sobre su base de datos:
"ConnectionStrings": {
    "MySql": "server=localhost;port=3306;database=prueba_tecnica_encode;user=root;password=root"
}

### 3. Ejecutar migraciones

En la raiz de la solución de tu proyecto ejecutar los sigueintes comandos:
  1- dotnet ef migrations add Migrations --project Data --startup-project Api
  2- dotnet ef database update --project Data --startup-project Api

### 4. Ejecutar el proyecto
Movernos sobre la carpeta API y luego ejecutar el comando "dotnet run"
