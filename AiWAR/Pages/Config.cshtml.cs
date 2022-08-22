using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiWAR.Models;
using AiWAR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Extensions.Logging;

namespace AiWAR.Pages
{
    public class ItemModel : PageModel
    {
        // [BindProperty]
        // public ItemModel? NewItem { get; set; }
        [BindProperty]
        public Item NewItem { get; set; } = new();
        public List<Item> items = new();
        public void OnGet()
        {
            items = ItemService.GetAll();
        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }
            ItemService.Add(NewItem);
            return RedirectToAction("Get");
        }
        public string StockText(Item item)
        {
            if (item.IsOnStock) return "Available";
            return "Preorder";
        }
        public IActionResult OnPostDelete(int id)
        {
            ItemService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}