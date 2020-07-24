using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LesPizzas.Models;

namespace LesPizzas.Controllers
{
    public class PizzaController : Controller
    {

        private static List<Pizza> pizzas;
        public List<Pizza> Pizzas => pizzas ?? (pizzas = Pizza.getListPizza());

        // GET: Pizza
        public ActionResult Index()
        {
            return View(Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null) {
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateEditVM vm = new PizzaCreateEditVM();
            vm.Pates = Pizza.PatesDisponibles;
            vm.Ingredients = Pizza.IngredientsDisponibles;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateEditVM vm)
        {
            try
            {
                vm.Pates = Pizza.PatesDisponibles;
                vm.Ingredients = Pizza.IngredientsDisponibles;
                if (ModelState.IsValid)
                {
                    if (Pizzas.Any(p => p.Nom.ToUpper() == vm.Pizza.Nom.ToUpper()))
                    {
                        ModelState.AddModelError("", "il existe déjà une pizza avec ce nom !");
                        return View(vm);
                    }
                    if (Pizza.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdSelectedPate) == default)
                    {
                        ModelState.AddModelError("", "Il faut obligatoirement une pate !");
                        return View(vm);
                    }
                    if (vm.IdSelectedIngredients.Count() > 5 || vm.IdSelectedIngredients.Count() < 2)
                    {
                        ModelState.AddModelError("", "Une pizza doit avoir entre 2 et 5 ingredients !");
                        return View(vm);
                    }
                    vm.Pizza.Pate = Pizza.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdSelectedPate);
                    var ingredients = new List<Ingredient> { };
                    foreach (var item in vm.IdSelectedIngredients)
                    {
                        ingredients.Add(Pizza.IngredientsDisponibles.FirstOrDefault(x => x.Id == item));
                    }
                    vm.Pizza.Ingredients = ingredients;
                    Pizzas.Add(vm.Pizza);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(vm);
                }
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            }
            PizzaCreateEditVM vm = new PizzaCreateEditVM();
            vm.Pates = Pizza.PatesDisponibles;
            vm.Ingredients = Pizza.IngredientsDisponibles;
            vm.Pizza = pizza;
            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateEditVM vm)
        {
            try
            {
                vm.Pates = Pizza.PatesDisponibles;
                vm.Ingredients = Pizza.IngredientsDisponibles;
                if (ModelState.IsValid)
                {
                    if (Pizzas.Any(p=>p.Nom.ToUpper() == vm.Pizza.Nom.ToUpper()))
                    {
                        ModelState.AddModelError("", "il existe déjà une pizza avec ce nom !");
                        return View(vm);
                    }
                    if (Pizza.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdSelectedPate) == default)
                    {
                        ModelState.AddModelError("", "Il faut obligatoirement une pate !");
                        return View(vm);
                    }
                    if (vm.IdSelectedIngredients.Count() > 5 || vm.IdSelectedIngredients.Count() < 2)
                    {
                        ModelState.AddModelError("", "Une pizza doit avoir entre 2 et 5 ingredients !");
                        return View(vm);
                    }
                    var pizza = Pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                    pizza.Pate = Pizza.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdSelectedPate);
                    var ingredients = new List<Ingredient> { };
                    foreach (var item in vm.IdSelectedIngredients)
                    {
                        ingredients.Add(Pizza.IngredientsDisponibles.FirstOrDefault(x => x.Id == item));
                    }
                    pizza.Ingredients = ingredients;
                    pizza.Nom = vm.Pizza.Nom;
                    return RedirectToAction("Index");
                }
                return View(vm);
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = Pizzas.FirstOrDefault(x => x.Id == id);
                Pizzas.Remove(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
