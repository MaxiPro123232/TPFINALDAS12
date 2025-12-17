# Explicación del Trabajo Final - Sistema de Gestión de Ventas TechStore S.A.

## 1. Contexto y Objetivo

El problema que tuvimos que resolver era que TechStore S.A. estaba gestionando todo manualmente. Entonces diseñamos un sistema que les permita manejar múltiples sucursales, un catálogo de productos, diferentes tipos de clientes (minoristas y mayoristas), control de inventario, ventas, facturación y reportes gerenciales.

Lo que hicimos fue armar una aplicación de escritorio con Windows Forms que automatiza todos estos procesos y les permite llevar un control completo de sus operaciones.

---

## 2. Requerimientos Funcionales

### 2.1. Gestión de Productos

**Alta de productos:**
Para dar de alta un producto, creamos un formulario `FormGestionProductos` donde el usuario completa los campos: código, nombre, descripción, categoría (que se elige de un ComboBox), precio, stock y sucursal. Cuando aprieta el botón "Crear", se ejecuta el método `btnCrear_Click` que valida los datos, arma un objeto `Producto`, llama al método `Crear()` del `ProductoController`, y este guarda en la base de datos usando Entity Framework con `SaveChanges()`.

**Modificación de datos y precios:**
Para actualizar, el usuario selecciona un producto del DataGridView, se cargan los datos en los textboxes, los edita y aprieta "Actualizar". Esto llama a `btnActualizar_Click`, que toma los valores actuales de los campos, arma un objeto `Producto` con el ID del seleccionado, y llama al método `Actualizar()` del controller, que usa Entity Framework para modificar el registro en la base.

**Consulta de disponibilidad por sucursal:**
Implementamos el método `ConsultarDisponibilidad()` en el `ProductoController` que recibe un ID de sucursal opcional. Si no le pasás sucursal, muestra todos los productos con stock mayor a cero. Si le pasás una sucursal específica, filtra por esa sucursal. Usa `Include()` para traer la categoría y sucursal relacionadas, y `Where()` para filtrar por stock disponible.

**Gestión de categorías:**
Hay un formulario `FormGestionCategorias` separado para manejar las categorías. Tiene métodos `Crear()`, `Actualizar()` y `Eliminar()` en el `CategoriaController`. Cuando eliminás una categoría, valida que no tenga productos asociados antes de borrarla, para mantener la integridad de los datos.

---

### 2.2. Gestión de Clientes

**Alta de clientes minoristas y mayoristas:**
En `FormGestionClientes`, el usuario completa código, nombre, apellido, dirección, teléfono, email, y elige el tipo de cliente de un ComboBox que tiene los valores del enum `TipoCliente` (Minorista o Mayorista). En el método `Crear()` del `ClienteController`, cuando el tipo es Mayorista, automáticamente le asigna un descuento del 15% si no tiene uno configurado. Para minoristas, el descuento queda en 0 por defecto.

**Historial de compras:**
Implementamos el método `ObtenerHistorialCompras()` en el `ClienteController` que trae todas las ventas asociadas a un cliente. Cuando apretás el botón "Ver Historial" en el formulario de clientes, abre un nuevo formulario `FormHistorialCompras` que muestra todas las ventas de ese cliente en un DataGridView, mostrando número de factura, fecha, vendedor, sucursal, método de pago y totales.

**Descuentos según tipo de cliente:**
El descuento se calcula en el proceso de venta. Cuando armás una venta, el sistema identifica el tipo de cliente y aplica el descuento configurado. Esto se maneja en el método `ProcesarVenta()` del `VentaController`, que calcula el subtotal, aplica el descuento del cliente, y calcula el total final.

---

### 2.3. Gestión de Ventas

**Cálculo de totales aplicando descuentos:**
En el formulario `FormGestionVentas`, cuando agregás productos al carrito, se va calculando el subtotal. Cuando seleccionás un cliente, automáticamente se aplica su descuento. El método `CalcularTotales()` suma todos los detalles de venta, aplica el descuento del cliente sobre el subtotal, y calcula el total final. Todo esto se muestra en tiempo real en el formulario.

**Métodos de pago:**
Usamos un enum `MetodoPago` con tres valores: Efectivo, Tarjeta y Transferencia. El usuario elige el método de un ComboBox en el formulario de ventas. Cuando se procesa la venta, se guarda este valor junto con la venta en la base de datos.

**Generación de facturas:**
El método `GenerarNumeroFactura()` del `VentaController` busca la última venta, toma su número de factura, lo incrementa, y genera el siguiente número en formato secuencial. Este número se asigna automáticamente cuando se crea una nueva venta, y se muestra en el formulario antes de procesar.

**Actualización automática del inventario:**
Cuando se procesa una venta con el método `ProcesarVenta()`, este usa una transacción de Entity Framework para asegurar que todo se guarde o nada. Primero valida que todos los productos tengan stock suficiente, luego guarda la venta y sus detalles, y después, para cada producto vendido, llama al método `ActualizarStock()` del `ProductoController` que resta la cantidad vendida del stock disponible. Si algo falla, la transacción hace rollback y no se guarda nada, manteniendo la consistencia de los datos.

---

### 2.4. Reportes y Consultas

**Reportes de ventas por período:**
En `FormReportes`, hay un botón que llama a `btnVentasPorPeriodo_Click`. Este método toma las fechas de inicio y fin de los DateTimePicker, valida que la fecha de inicio sea menor a la de fin, y llama al método `ObtenerVentasPorPeriodo()` del `VentaController`. Este método usa `Where()` con Entity Framework para filtrar las ventas entre esas fechas, incluye todas las relaciones (cliente, vendedor, sucursal), y devuelve una lista que se muestra en el DataGridView.

**Reportes por producto, sucursal y vendedor:**
Similar al anterior, tenemos métodos como `ObtenerVentasPorProducto()`, `ObtenerVentasPorSucursal()` y `ObtenerVentasPorVendedor()`. Cada uno recibe un ID, filtra las ventas con `Where()` según ese criterio, y devuelve los resultados. En el formulario, los ComboBox tienen una opción "TODOS" que muestra todas las ventas sin filtrar.

**Productos más vendidos:**
El método `ObtenerProductosMasVendidos()` agrupa los `DetalleVenta` por producto usando `GroupBy()`, suma las cantidades vendidas y los totales con `Sum()`, los ordena de mayor a menor con `OrderByDescending()`, y toma los primeros 10 con `Take()`. Muestra el nombre del producto, cantidad vendida y total vendido.

**Estado de cuenta corriente:**
Cada cliente tiene una propiedad `SaldoCuentaCorriente` que se actualiza cuando se procesan ventas. El método `ObtenerSaldoCuentaCorriente()` simplemente lee este valor del cliente. En el reporte, podés filtrar por un cliente específico o ver todos los clientes con sus saldos.

---

## 3. Requerimientos No Funcionales

### 3.1. Mantenibilidad: Código Modular y Documentado

Separamos todo en proyectos distintos: `Entidades` para las clases del dominio (Producto, Cliente, Venta, etc.), `Modelo` para el `DbContext` de Entity Framework, `Controladores` para la lógica de negocio, y `Vista` para los formularios Windows Forms. Cada controlador tiene responsabilidades claras: `ProductoController` solo maneja productos, `VentaController` solo ventas, etc. Los métodos tienen nombres descriptivos como `Crear()`, `Actualizar()`, `Eliminar()`, `ObtenerTodos()`, que hacen obvio qué hace cada uno.

### 3.2. Persistencia: Entity Framework

Usamos Entity Framework Core para conectarnos a SQL Server LocalDB. En el `TechStoreDbContext`, definimos todos los `DbSet` para cada entidad. En el método `OnConfiguring()`, configuramos la cadena de conexión a la base de datos. Las entidades tienen atributos como `[Key]`, `[Required]`, `[ForeignKey]` para definir las relaciones y restricciones. Entity Framework maneja automáticamente el mapeo entre objetos y tablas, así que cuando llamás a `SaveChanges()`, todo se persiste en la base.

### 3.3. Arquitectura MVC

Implementamos el patrón MVC así: las **Vistas** son los formularios Windows Forms (`FormGestionProductos`, `FormGestionVentas`, etc.) que solo muestran datos y capturan la entrada del usuario. Los **Controladores** (`ProductoController`, `VentaController`, etc.) tienen toda la lógica de negocio y acceso a datos. El **Modelo** es el `TechStoreDbContext` que representa la base de datos, y las **Entidades** representan las tablas.

Cuando el usuario aprieta un botón en la vista, esta llama al controlador correspondiente. Por ejemplo, cuando apretás "Crear" en `FormGestionProductos`, se ejecuta `btnCrear_Click`, que toma los valores de los textboxes, arma un objeto `Producto`, y llama a `ProductoController.Crear()`. El controlador valida, interactúa con Entity Framework, y devuelve un resultado. La vista solo muestra mensajes o actualiza el DataGridView.

---

## 4. Diseño de la Arquitectura

**Estructura de capas:**
Armamos cuatro proyectos separados. El proyecto `Entidades` tiene las clases simples con sus propiedades (Producto, Cliente, Venta, etc.) y los enums (TipoCliente, MetodoPago). El proyecto `Modelo` tiene el `TechStoreDbContext` que hereda de `DbContext` de Entity Framework, define los `DbSet` para cada entidad, y configura las relaciones en `OnModelCreating()`. El proyecto `Controladores` tiene una clase controller por cada entidad principal, cada una con métodos para CRUD y operaciones específicas. El proyecto `Vista` tiene todos los formularios Windows Forms.

**Responsabilidades:**
Las entidades solo tienen propiedades y relaciones. El DbContext solo maneja la conexión y configuración de la base. Los controladores hacen toda la lógica: validaciones, cálculos, llamadas a Entity Framework. Las vistas solo muestran y capturan datos, no hacen lógica de negocio.

---

## 5. Implementación

**Construcción siguiendo MVC:**
Creamos cada capa por separado. Primero las entidades con sus propiedades y anotaciones. Después el DbContext configurando las relaciones entre entidades. Luego los controladores, cada uno recibiendo el DbContext en el constructor mediante inyección de dependencias. Y finalmente las vistas que instancian los controladores que necesitan.

**Conexión a base de datos:**
En el `TechStoreDbContext`, en `OnConfiguring()`, pusimos la cadena de conexión a SQL Server LocalDB. Entity Framework automáticamente crea las tablas cuando ejecutás las migraciones o cuando la base no existe. Usamos `Include()` para cargar relaciones (por ejemplo, cuando traés una venta, también traés el cliente, vendedor y detalles), y `AsNoTracking()` para consultas de solo lectura y mejorar el rendimiento.

**Implementación de módulos funcionales:**
Cada módulo tiene su formulario y su controlador. Para productos: `FormGestionProductos` + `ProductoController`. Para clientes: `FormGestionClientes` + `ClienteController`. Para ventas: `FormGestionVentas` + `VentaController`. Para reportes: `FormReportes` que usa varios controladores. Todos siguen el mismo patrón: la vista llama al controlador, el controlador trabaja con Entity Framework, y la vista muestra los resultados.

**Pruebas de flujos:**
Probamos el flujo completo de venta: seleccionar cliente (aplica descuento automático), agregar productos al carrito (calcula subtotales), elegir método de pago, procesar la venta (valida stock, guarda venta y detalles, actualiza stock), y generar la factura. Probamos que si un producto no tiene stock suficiente, la venta no se procesa y muestra un error. Probamos los reportes filtrando por diferentes criterios. Todo funciona correctamente.

---

## 6. Valor Agregado

**Validaciones:**
En cada formulario, antes de crear o actualizar, validamos que los campos requeridos no estén vacíos. En los controladores, validamos cosas como códigos duplicados, que no se elimine una sucursal que tiene productos o ventas, que el stock sea suficiente antes de vender. Todas las validaciones muestran mensajes claros al usuario con `MessageBox`.

**Control de stock por sucursal:**
Cada producto está asociado a una sucursal, y cada sucursal tiene su propio inventario. Cuando consultás disponibilidad, podés filtrar por sucursal o ver todas. Cuando vendés, el sistema valida que esa sucursal específica tenga stock suficiente del producto que querés vender.

**Manejo de errores:**
Todos los métodos `Crear()`, `Actualizar()`, `Eliminar()` están envueltos en bloques `try-catch`. Si algo falla (por ejemplo, un error de base de datos), el catch captura la excepción, devuelve `false`, y la vista muestra un mensaje de error genérico. En `ProcesarVenta()`, usamos transacciones para asegurar que si algo falla, se revierte todo y no quedan datos inconsistentes.

**Interfaz mejorada:**
En los DataGridViews, en lugar de mostrar objetos completos (que aparecían como "TechStore.Entidades.Producto"), creamos objetos anónimos con solo las propiedades que queremos mostrar (por ejemplo, para productos mostramos código, nombre, categoría como texto, sucursal como texto). Para mostrar listas (como productos de una categoría), usamos `string.Join()` para separarlos con guiones. Agregamos opciones "TODOS" o "Todas" en los ComboBox de filtros para permitir ver todo sin filtrar.

