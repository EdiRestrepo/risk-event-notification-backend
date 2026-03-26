# Risk event notification backend

## Reto 1.
En Medellín y el Valle de Aburrá, las lluvias intensas generan emergencias como inundaciones y deslizamientos. Aunque el SIATA emite alertas en tiempo real, muchas personas no las reciben, comprenden o atienden oportunamente, lo que aumenta el riesgo. El reto del curso es crear una plataforma que permita notificar a las personas sobre eventos de riesgo.

## Descripción:

Aplicación web que muestra alertas de riesgo en tiempo real, permite a los usuarios gestionar sus zonas de interés y recibir notificaciones claras y oportunas mediante interfaces intuitivas, mapas y paneles informativos. 

## Arquitectura general del sistema

**Cliente-Servidor + Monolito modular + enfoque orientado a eventos**

Se selecciona una arquitectura **cliente-servidor** porque la solución requiere una interfaz de usuario separada del procesamiento centralizado de alertas y notificaciones.

## Arquitectura del backend

Para el backend se propone un **monolito modular con arquitectura por capas**, ya que permite mantener una separación clara entre la lógica de negocio y los detalles técnicos, facilitando pruebas, mantenimiento y evolución futura.
Además, se adopta un **enfoque orientado a eventos** para gestionar la emisión de alertas y el envío de notificaciones en tiempo real, lo cual se ajusta naturalmente al problema planteado.

### Beneficios: 
  * Desarrollar más rápido
  * Desplegar más fácil
  * Entender mejor el sistema
  * Separar responsabilidades correctamente

---
## Estructura de carpetas  para Backend

## C# (.NET)

```bash
/src
├── 1.Domain        (Núcleo: Entidades, Lógica de Negocio)
│   ├── Entities/   (Pedido.cs, Cliente.cs)
│   ├── Exceptions/
│   └── Interfaces/ (IPedidoRepository.cs - Puerto)
├── 2.Application   (Casos de Uso)
│   ├── UseCases/   (CrearPedidoUseCase.cs)
│   └── DTOs/
├── 3.Infrastructure(Adaptadores Externos)
│   ├── Persistence/(EF Core, Repositorios, DBContext)
│   └── Services/   (API Clientes Externa, Notificadores)
└── 4.API           (Adaptadores de Entrada/Presentación)
    └── Controllers/(PedidoController.cs)
```

---



