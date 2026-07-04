using System;
using System.Collections.Generic;
using Tienda_computadora.Models;

namespace Tienda_computadora.Services
{
    public class ComputadoraService
    {
private readonly List<Computadora> computadoras = new List<Computadora>()
{
    new Computadora
    {
        Id = 1,
        Nombre = "Computadora Gamer",
        Marca = "Asus",
        Procesador = "Intel Core i7",
        Tipo = "Laptop",
        Precio = 1500.00m,
        Stock = 10
    },
    new Computadora
    {
        Id = 2,
        Nombre = "Computadora de Oficina",
        Marca = "Dell",
        Procesador = "Intel Core i5",
        Tipo = "Desktop",
        Precio = 800.00m,
        Stock = 5
    }
};
               
        public ComputadoraService()
        {
        }

        public List<Computadora> ObtenerComputadoras()
        {
            return computadoras;
        }

        public void AgregarComputadora(Computadora computadora)
        {
            computadoras.Add(computadora);
        }

        public bool EliminarComputadora(int id)
        {
            var computadora = computadoras.Find(c => c.Id == id);
            if (computadora != null)
            {
                computadoras.Remove(computadora);
                return true;
            }
            return false;
        }
    }           
}