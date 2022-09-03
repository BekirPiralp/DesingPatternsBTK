﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();

            stockController.TakeOrder(buyStock,sellStock,buyStock);

            stockController.PlaceOrders();

            Console.ReadLine();
            
        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock : {0}, {1} bought!",_name,_quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock : {0}, {1} sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _manager;
        public BuyStock(StockManager manager)
        {
            this._manager = manager;
        }
        public void Execute()
        {
            _manager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _manager;
        public SellStock(StockManager manager)
        {
            _manager = manager;
        }
        public void Execute()
        {
            _manager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order,params IOrder[] orders)
        {
            _orders.Add(order);
            _orders.AddRange(orders);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }
}
