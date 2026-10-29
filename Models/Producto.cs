using System;
using System.ComponentModel.DataAnnotations;

namespace FerreteriaValdivia.Models
{
    public class Producto
    {
        [Key]
        public string CodigoBarras { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        public decimal PrecioVenta { get; set; }

        public int StockMinimo { get; set; }

        // Permitimos el set público para que el formulario y Entity Framework puedan llenarlo
        private int _stockActual;
        public int StockActual
        {
            get => _stockActual;
            set => _stockActual = value >= 0 ? value : 0;
        }

        public int CantidadVendida { get; set; } // <--- Campo necesario para la pestaña del más vendido

        // Constructor vacío (obligatorio para Entity Framework Core)
        public Producto()
        {
        }

        // Constructor con parámetros
        public Producto(string codigoBarras, string nombre, decimal precioVenta, int stockMinimo, int stockActual, int cantidadVendida = 0)
        {
            CodigoBarras = codigoBarras;
            Nombre = nombre;
            PrecioVenta = precioVenta;
            StockMinimo = stockMinimo;
            StockActual = stockActual >= 0 ? stockActual : 0;
            CantidadVendida = cantidadVendida;
        }

        // Métodos de la clase
        public bool DescontarStock(int cantidad)
        {
            if (cantidad <= 0 || _stockActual < cantidad)
                return false;

            _stockActual -= cantidad;
            CantidadVendida += cantidad; // Registra automáticamente la venta para el reporte
            return true;
        }

        public bool AgregarStock(int cantidad)
        {
            if (cantidad <= 0) 
                return false;

            _stockActual += cantidad;
            return true;
        }

        public bool RequiereReposicion()
        {
            return _stockActual <= StockMinimo;
        }
    }
}