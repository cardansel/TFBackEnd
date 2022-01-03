using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Models;


namespace TFBackEnd.Api.Data
{
    public class TFBackEndApiContext : DbContext
    {
        public TFBackEndApiContext (DbContextOptions<TFBackEndApiContext> options)
            : base(options)
        {
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Cargo datos generados para Sensores*/
            var sensor1 = new Sensor() {Id=1, Nombre = "Sensor Giroscopio" };
            var sensor2 = new Sensor() {Id=2, Nombre = "Sensor de Movimiento" };
            var sensor3 = new Sensor() {Id=3, Nombre = "Sensor de Luz" };
            var sensor4 = new Sensor() {Id=4, Nombre = "Sensor de Proximidad" };
            modelBuilder.Entity<Sensor>().HasData(new Models.Sensor[] { sensor1, sensor2, sensor3, sensor4 });

            /*Cargo datos generados para Apps*/
            var app1 = new App() {Id=1, Nombre = "Whatsapp" };
            var app2 = new App() {Id=2, Nombre = "Facebook" };
            var app3 = new App() {Id=3, Nombre = "Instagran" };
            var app4 = new App() {Id=4, Nombre = "Telegran" };
            modelBuilder.Entity<App>().HasData(new App[] { app1, app2, app3, app4 });

            /*Cargo datos generados para Operarios*/
            var operario1 = new Operario() {Id=1, Nombre = "Testing", Apellido = "Testing" };
            var operario2 = new Operario() {Id=2, Nombre = "Testing 2", Apellido = "Testing 2" };
            modelBuilder.Entity<Operario>().HasData(new Operario[] { operario1, operario2 });



            //Propiedades de configuracion

            /*Relacion instalacion con app*/

            modelBuilder.Entity<Instalacion>()
                .HasOne<App>(i => i.App)
                .WithMany(a => a.Instalaciones)
                .HasForeignKey(i => i.AppId);

            /*Relacion instalacion con Operarios*/

            modelBuilder.Entity<Instalacion>()
                .HasOne<Operario>(i => i.Operario)
                .WithMany(o => o.Instalaciones)
                .HasForeignKey(i => i.OperarioId);

            /*Relaciones Instalacion Telefonos*/

            modelBuilder.Entity<Instalacion>()
                .HasOne<Telefono>(i => i.Telefono)
                .WithMany(t => t.Instalaciones)
                .HasForeignKey(i => i.TelefonoId);


            /*Relacion de Muchos a Muchos*/

        
                
        }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<App> Apps { get; set; }

        public DbSet<Instalacion> Instalaciones { get; set; }

        public DbSet<Operario> Operarios { get; set; }

        public DbSet<Sensor> Sensor { get; set; }

        
 
    }
}
