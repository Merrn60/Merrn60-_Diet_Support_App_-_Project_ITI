using IV.Models;
using Microsoft.AspNetCore.Mvc;

namespace IV.Controllers
{
    public class CalorieCalculatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalorieCalculatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display the Calculate view
        public IActionResult Calculate()
        {
            var model = new CalorieCalculation(); // Initialize the model when the page loads for the first time
            return View(model);
        }

        // POST: Handle form submission
        [HttpPost]
        public IActionResult Calculate(CalorieCalculation model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    double bmr;

                    // Mifflin-St Jeor Equation
                    if (model.Gender == "Male")
                    {
                        bmr = 10 * model.Weight + 6.25 * model.Height - 5 * model.Age + 5;
                    }
                    else
                    {
                        bmr = 10 * model.Weight + 6.25 * model.Height - 5 * model.Age - 161;
                    }

                    // Calculate daily calories based on activity level
                    switch (model.ActivityLevel)
                    {
                        case "Sedentary":
                            model.DailyCalories = bmr * 1.2;
                            break;
                        case "Lightly Active":
                            model.DailyCalories = bmr * 1.375;
                            break;
                        case "Moderately Active":
                            model.DailyCalories = bmr * 1.55;
                            break;
                        case "Very Active":
                            model.DailyCalories = bmr * 1.725;
                            break;
                        case "Extra Active":
                            model.DailyCalories = bmr * 1.9;
                            break;
                        default:
                            model.DailyCalories = bmr;
                            break;
                    }

                    // Save the data to the database
                    _context.CalorieCalculations.Add(model);

                    // Attempt to save changes
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Add error to the model state to display it in the view
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }

                // Return the same view with calculated results or errors
                return View(model);
            }

            // If validation fails, return the same view with errors
            return View(model);
        }
    }
}
