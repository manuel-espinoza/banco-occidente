
# Prueba Tecnica Tarjeta de Credito

Soy Manuel Espinoza, desarrollador de software senior e ingeniero de sistemas informáticos.

He desarrollado este ejercicio practico para cumplir los requerimientos estipulados en la prueba técnica enviada.

El proyecto contiene:

- Colecciones de postman
- Un archivo .bak para restaurar en la base de datos
- la solución de web api en net 6
- un frontend hecho en Nuxt 3 para consumir la api desarrollada
- un archivo docker-compose para orquestar toda la solución

Pasos para la ejecución:

1. ejecutar por comando o por algun asistente en vs code o similares el archivo docker compose, para que levante todos los servicios
2. por cuestiones de tiempo no pude generar automaticamente el backup de la base de datos, por lo tanto habria que meterse a un gestor de base de datos como sql server management studio y crear la base de datos con nombre exacto: bancooccidentedb, posteriormente proceder a restaruar el archivo .bak que se encontrara en el volumen del contenedor de sql server.
3. Una vez restarurado se puede visistar http://localhost:5020/swagger para consultar la información de la web api
4. Puede ingresar al http://localhost:3000 para ver y usar el frontend.

De igual forma que la base de datos por cuesitones de tiempo no pude hacer mas dinamica la app y las llamadas a las api se hacen con datos quemados como id de cliente o de tarjeta de credito, ver en el codigo fuente los que se pueden consultar y hacer el cambio manualmente y volver a lanzar.

