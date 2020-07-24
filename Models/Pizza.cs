﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LesPizzas.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Nom { get; set; }
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public static List<Ingredient> IngredientsDisponibles => new List<Ingredient>
        {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
        };

        public static List<Pate> PatesDisponibles => new List<Pate>
        {
            new Pate{ Id = 1, Nom = "Pate fine, base crême"},
            new Pate{ Id = 2, Nom = "Pate fine, base tomate"},
            new Pate{ Id = 3, Nom = "Pate épaisse, base crême"},
            new Pate{ Id = 4, Nom = "Pate épaisse, base tomate"}
        };

        public static List<Pizza> getListPizza()
        {
            return new List<Pizza> {
                new Pizza{
                    Id = 1,
                    Nom = "Reine",
                    Pate = new Pate{ Id = 1, Nom = "Pate fine, base crême"},
                    Ingredients = new List<Ingredient> {
                        new Ingredient { Id = 1, Nom = "Mozzarella"},
                        new Ingredient{ Id = 3, Nom = "Tomate"},
                        new Ingredient{ Id = 4, Nom = "Oignon"},
                        new Ingredient{ Id = 5, Nom = "Cheddar"},
                        new Ingredient{ Id = 8, Nom = "Poulet"}
                        }
                },
                new Pizza{
                    Id = 1,
                    Nom = "Jambon fromage",
                    Pate=new Pate{ Id = 2 , Nom = "Pate fine, base tomate"},
                    Ingredients= new List<Ingredient> {
                        new Ingredient{ Id = 1, Nom = "Mozzarella"},
                        new Ingredient{ Id = 3, Nom = "Tomate"},
                        new Ingredient{ Id = 4, Nom = "Oignon"},
                        new Ingredient{ Id = 5, Nom = "Cheddar"},
                        new Ingredient{ Id = 2, Nom = "Jambon"}
                        }
                }
            };
        }
    }
}