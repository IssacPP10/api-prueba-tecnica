
# 🚀 **API de Gestión de Fallas de Equipos** 🖥️

Este proyecto tiene como objetivo resolver la problemática de gestionar y registrar las fallas en equipos de una organización, permitiendo un seguimiento eficiente de los problemas técnicos que puedan surgir.

## 📜 **Descripción del Proyecto**:
La API fue desarrollada utilizando **ASP.NET Core** y permite realizar operaciones **CRUD** (Crear, Leer, Actualizar, Eliminar) sobre las fallas de los equipos, facilitando el registro, actualización y consulta de las fallas por parte de los usuarios de la organización.

## 🛠️ **Generación de la API**:
La API fue desarrollada con **ASP.NET Core** y proporciona un conjunto de endpoints RESTful que permiten interactuar con los datos de las fallas de manera eficiente. Las principales funcionalidades son:
- Registrar nuevas fallas.
- Consultar detalles de fallas existentes.
- Actualizar el estado de las fallas.
- Eliminar registros de fallas cuando ya no son necesarios.

## 🗄️ **Base de Datos Utilizada**:
La API utiliza **SQL Server** como base de datos, gestionada a través de **Entity Framework Core**. Esto asegura que la persistencia de los datos sea eficiente y segura.

Para restaurar la base de datos, puedes utilizar el archivo **pt_RegistroFallasEquipos.bak**. Si deseas ver las consultas realizadas, también puedes revisar el archivo **QueryPruebaTecnica.sql**.

## 🔧 **Tecnologías Utilizadas**:
- **ASP.NET Core**: Para la creación de la API RESTful.
- **Entity Framework Core**: Para la gestión de la base de datos.
- **SQL Server**: Como sistema de gestión de bases de datos.
- **Swashbuckle**: Para la documentación automática de la API, facilitando la integración con Swagger y proporcionando una interfaz de usuario para probar los endpoints de la API.

## 🌐 **Consumo de la API**:
La API es consumida por un **frontend** desarrollado en otro proyecto, permitiendo a los usuarios interactuar con el sistema de registro de fallas de manera eficiente. Los usuarios pueden acceder a las funcionalidades de la API a través de una interfaz gráfica que facilita la interacción con los datos.

## 📈 **Diagrama de Flujo**:
Aquí puedes ver el diagrama de flujo del proyecto:

![Diagrama de flujo](https://github.com/user-attachments/assets/3a760c31-b156-4406-83a1-5c84e1197c72)


## 🚀 **Instrucciones para Ejecutar el Proyecto**:

1. **Clona el repositorio**:

   ```bash
   git clone https://github.com/tu_usuario/gestion-fallas-api.git
   ```

2. **Navega al directorio del proyecto**:

   ```bash
   cd gestion-fallas-api
   ```

3. **Restaura las dependencias**:

   ```bash
   dotnet restore
   ```

4. **Configura la base de datos**:
   Asegúrate de que SQL Server esté instalado y configurado. Luego, ejecuta las migraciones para crear las tablas necesarias:

   ```bash
   dotnet ef database update
   ```

   Si prefieres restaurar la base de datos desde un archivo `.bak`, utiliza SQL Server Management Studio (SSMS) o una herramienta similar para restaurar la base de datos a partir del archivo **pt_RegistroFallasEquipos.bak**.

5. **Ejecuta la API**:

   ```bash
   dotnet run
   ```

   La API estará disponible en `http://localhost:5000` (o el puerto configurado).

## 📜 **Licencia**:
Este proyecto está bajo la **Licencia MIT**. Si deseas contribuir o utilizar este código, por favor revisa los términos de la licencia.
