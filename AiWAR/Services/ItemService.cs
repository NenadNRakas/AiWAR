// In-Memory Data Service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiWAR.Models;

namespace AiWAR.Services
{
    public static class ItemService
    {
        static List<Item> Items { get; }
        static int nextId = 9;
        static ItemService()
        {
            Items = new List<Item>
            {
                new Item { Id=1, Name="Blade Access", Price=2000.00M, Size=ItemSize.Large, IsOnStock=false },
                new Item { Id=2, Name="Energizer P-1", Price=1500.00M, Size=ItemSize.Small, IsOnStock=true },
                new Item { Id=3, Name="Inverter 5Kwh", Price=20000.00M, Size=ItemSize.Large, IsOnStock=false },
                new Item { Id=4, Name="Solar Camera 5MP", Price=1500.00M, Size=ItemSize.Small, IsOnStock=true },
                new Item { Id=5, Name="Cloud Firewall", Price=2000.00M, Size=ItemSize.Large, IsOnStock=false },
                new Item { Id=6, Name="Solar Panel", Price=2500.00M, Size=ItemSize.Small, IsOnStock=true },
                new Item { Id=7, Name="Solar AP", Price=1500.00M, Size=ItemSize.Small, IsOnStock=true },
                new Item { Id=8, Name="Battery 7Kwh", Price=35000.00M, Size=ItemSize.Small, IsOnStock=true }
            };
        }
        public static List<Item> GetAll() => Items;
        public static Item Get(int id) => Items.FirstOrDefault(p => p.Id == id);
        public static void Add(Item item)
        {
            item.Id = nextId++;
            Items.Add(item);
        }
        public static void Delete(int id)
        {
            var item = Get(id);
            if (item is null) return;
            Items.Remove(item);
        }
        public static void Update(Item item)
        {
            var index = Items.FindIndex(p => p.Id == item.Id);
            if (index == -1) return;
            Items[index] = item;
        }
    }
}