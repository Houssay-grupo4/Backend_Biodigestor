**Pasos para clonar proyecto y arrancarlo:**

1. git clone url del repositorio
2. En visual 2022:
   * Por las dudas, verificar que tengan la versión 8 de .NET CORE
   * Para crear automáticamente la base de datos: abrir la consola del administrador de paquetes (ir al menú Ver > Otras ventanas > Consola del Administrador de paquetes) y luego, ingresar el siguiente comando: ***update-database*** (Se crearán las tablas de las clases que estén en el proyecto).
   * Verificar en base de datos que se hayan creado la o las tablas correctamente (En este proyecto, la base de datos se llama BiodigestorDatabase).

3. Ejecutar el proyecto.

-------------------- ****** ---------------------

**Comando para crear automáticamente el código que creará la tabla en base de datos**

Cuando hayamos creado la clase que nos corresponderá a cada uno, debemos ingresar el siguiente comando en la mencionada consola por única vez: **add-migration Nombre de la entidad** (ej. Clientes)

Integrantes Paz Santangelo ,
Quimey delgado , 
Mancuello Roxana , 
Alejandro Santangelo , 
Chiara Seco , 
Juan Larcher , 
Nicolas Barrionuevo , 
Nancy Velazco 
