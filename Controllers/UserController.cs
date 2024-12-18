using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        // Implement the Index method here
public ActionResult Index()
{
    return View(userlist);
}


        public ActionResult Details(int id)
{
    var user = userlist.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return NotFound();
    }
    return View(user);
}

// Implement the Create method here
public ActionResult Create()
{
    return View();
}

// Implement the Create method (POST) here
[HttpPost]
public ActionResult Create(User user)
{
    if (ModelState.IsValid)
    {
        userlist.Add(user);
        return RedirectToAction(nameof(Index));
    }
    return View(user);
}

// This method is responsible for displaying the view to edit an existing user with the specified ID.
public ActionResult Edit(int id)
{
    var user = userlist.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return NotFound();
    }
    return View(user);
}

// This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
[HttpPost]
public ActionResult Edit(int id, User user)
{
    var existingUser = userlist.FirstOrDefault(u => u.Id == id);
    if (existingUser == null)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
    
        return RedirectToAction(nameof(Index));
    }
    return View(user);
}



        // GET: User/Delete/5
        // Implement the Delete method here
public ActionResult Delete(int id)
{
    var user = userlist.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return NotFound();
    }
    return View(user);
}

// Implement the Delete method (POST) here
[HttpPost, ActionName("Delete")]
public ActionResult DeleteConfirmed(int id)
{
    var user = userlist.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return NotFound();
    }

    userlist.Remove(user);
    return RedirectToAction(nameof(Index));
}
}



// Implement the details method here
